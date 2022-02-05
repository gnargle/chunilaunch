using System;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class SliderTestWindow : Form {

        private const byte SLIDER_ESCAPE = 0xfd;
        private const byte RESET_CMD = 0x10;
        private const byte HW_INFO_CMD = 0xf0;
        private const byte AUTOSCAN_CMD = 0x03;
        private const byte LED_CMD = 0x02;

        private SerialPort serialPort;
        private bool active = true;

        struct Command {
            public byte sync; //always ff
            public byte command;
            public byte length; //00 or 08?
            public byte[] data;
            public byte checksum;
        }

        public SliderTestWindow() {
            InitializeComponent();
        }

        private void SliderTestWindow_Load(object sender, EventArgs e) {
            var progress = new Progress<string>(update => { lbStatusText.Text = update; });
            Task sliderRunner = new Task(() => sliderTask(progress));
            sliderRunner.Start();
        }
        private Command ReadSerial() {
            var com = new Command();
            byte sync = 0x00;
            //sync byte is ff, it should be the first byte, scan till we get it.
            while (sync != 0xff) {
                sync = ReadByte();
            }
            com.sync = sync;
            com.command = ReadByte();
            com.length = ReadByte();            
            com.data = new byte[com.length]; //slider does not include checksum in its length calc
            com.data = ReadTotalLength(com.data, com.data.Length);
            com.checksum = ReadByte();
            return com;
        }
        private void SendCommand(byte commandByte, byte[] data) {
            var command = new Command() {
                sync = 0xff,
                command = commandByte,
                length = (byte)(data.Length),               
                data = data,
            };
            command.checksum = Checksum(command);

            serialPort.Write(new byte[] { command.sync }, 0, 1); //don't escape this byte, lol
            WriteEscapedByte(command.command);
            WriteEscapedByte(command.length);            
            WriteAllBytes(command.data);
            WriteEscapedByte(command.checksum);
        }

        //from here, everything is a ported version of CrazyRedMachine's python test harnerss. They did the hard work so I don't have to!
        private byte Checksum(byte[] arr) {
            var chksm = -1 * arr.Sum(b => b);
            return (byte)chksm;
        }

        private byte Checksum(Command com) {
            var chksm = com.sync + com.command + com.length;
            foreach (var b in com.data) {
                chksm += b;
            }
            chksm *= -1;
            return (byte)chksm;
        }
        private byte ReadByte() {
            int b = serialPort.ReadByte();
            if (b == SLIDER_ESCAPE) {
                b = serialPort.ReadByte() + 1;
            }
            return (byte)b;
        }
        private void WriteAllBytes(byte[] data) {
            int written = 0;
            while (written < data.Length) {
                WriteEscapedByte(data[written]);
                written++;
            }
        }

        private void WriteEscapedByte(byte b) {
            if (b == SLIDER_ESCAPE || b == 0xff) {
                serialPort.Write(new byte[] { SLIDER_ESCAPE, (byte)(b - 1) }, 0, 2);
            } else
                serialPort.Write(new byte[] { b }, 0, 1);
        }

        private byte[] ReadTotalLength(byte[] arr, int bytesToRead) {
            int read = 0;
            while (read < bytesToRead) {
                read += serialPort.Read(arr, read, bytesToRead - read);
            }
            int i = 0;
            bool changed = false;
            var l = arr.ToList();
            var l0 = arr.ToList();
            foreach(var b in l) {
                if (changed) {
                    l0[i] = (byte)(l0[i] + 1);
                    changed = false;
                    i++;
                }  else {
                    if (b == SLIDER_ESCAPE) {
                        l0.RemoveAt(i);
                        changed = true;
                    } else {
                        i++;
                    }
                }                
            }
            arr = l0.ToArray();
            return arr;
        }

        private string packetToString(byte[] arr) {
            string s = string.Empty;
            foreach (var b in arr) {
                s += $"{b},";
            }
            s += "\n";
            return s;
        }

        private void SendCommand(byte[] arr) {
            var command = arr;
            var chksm = Checksum(arr);
            command = command.Append(chksm).ToArray();
            serialPort.Write(command, 0, command.Count());
        }

        private void SendLEDUniformColour(byte red, byte green, byte blue, int brightness) {
            var data = new byte[] {(byte)brightness};
            for (int i = 0; i < 31; i++) {
                data = data.Append(blue).ToArray();
                data = data.Append(red).ToArray();
                data = data.Append(green).ToArray();
            }
            SendCommand(LED_CMD, data);
        }

        private void RetrieveInput(byte[] touchdata) {

            //find and skip sync byte so we know where we are.
            var currByte = serialPort.ReadByte();
            if (currByte != 0xff) {
                while (currByte != 0xff) {
                    currByte = serialPort.ReadByte();
                }
            }
            while (currByte == 0xff) {
                currByte = serialPort.ReadByte();
            }

            //check command type
            if (currByte != 0x01) {
                //unexpected value
                return;
            }
            currByte = serialPort.ReadByte();
            if (currByte != 0x20) {
                //unexpected packet length
                return;
            }
            int read = 0;
            while (read < 32) {
                read += serialPort.Read(touchdata, read, 32 - read);
            }

            currByte = serialPort.ReadByte(); //checksum byte, but we're hacking so who gaf about that   
           
           /* //this should be the same as the above code just in a standardised form, but it breaks everything. wtf?
            * var cmd = ReadSerial();
            //check command type
            if (cmd.command != 0x01) {
                //unexpected value
                return;
            }
            if (cmd.length != 0x20) {
                //unexpected packet length
                return;
            }
            touchdata =  cmd.data;  
           */
        }

        private void SendLEDReactive(byte[] touchData) {
            //send LEDs over the new command interface eventually causes a timeout?
            var data = new byte[] { 0xff, 0x02, 0x5e, 0x7f };
            //var data = new byte[] { 0x7f };
            for (int i = 0; i < 31; i++) {
                if (i % 2 != 0) {
                    //odd, separator
                    data = data.Append((byte)0x7f).ToArray();
                    data = data.Append((byte)0x23).ToArray();
                    data = data.Append((byte)0).ToArray();
                } else if (touchData[i] > 0) {
                    //top zone
                    data = data.Append((byte)0x23).ToArray();
                    data = data.Append((byte)0).ToArray();
                    data = data.Append((byte)0x7f).ToArray();
                } else if (touchData[i + 1] > 0) {
                    //bottom zone
                    data = data.Append((byte)0).ToArray();
                    data = data.Append((byte)0x7f).ToArray();
                    data = data.Append((byte)0x23).ToArray();
                } else {
                    data = data.Append((byte)0).ToArray();
                    data = data.Append((byte)0).ToArray();
                    data = data.Append((byte)0).ToArray();
                }
            }
            //SendCommand(LED_CMD, data);
            SendCommand(data);
        }

        private bool SliderInit(IProgress<string> progress) {
            SendCommand(RESET_CMD, new byte[] { });
            var returnedCommand = ReadSerial();
            var returnedBytes = new byte[4];
            //returnedBytes = ReadTotalLength(returnedBytes, 4);

            if (returnedCommand.command == RESET_CMD && returnedCommand.checksum == 0xf1) {
                progress.Report("Reset OK");
            } else {
                progress.Report("Reset not OK");
                return false;
            }

            SendCommand(HW_INFO_CMD, new byte[] { });

            returnedCommand = ReadSerial();

            if (returnedCommand.data.SequenceEqual(new byte[] {0x31, 0x35, 0x33, 0x33, 0x30, 0x20, 0x20, 0x20, 0xA0, 0x30, 0x36, 0x37, 0x31, 0x32, 0xFF, 0x90, 0x00 })) {
                progress.Report("HW Info OK");
                return true;
            } else {
                progress.Report("HW Info not OK");
                return false;
            }
        }
        private void InputTest(IProgress<string> progress) {
            progress.Report("IO Test");
            //SendCommand(new byte[] { 0xff, 0x03, 0x00 });
            SendCommand(AUTOSCAN_CMD, new byte[] { });
            byte[] touchData = new byte[32];
            int i = 0;
            while (active) {
                //SendCommand(AUTOSCAN_CMD, new byte[] { }); //keepalive for testing rn
                RetrieveInput(touchData);
                if (i == 3) {
                    SendLEDReactive(touchData);
                    i = 0;
                } else {
                    i++;
                }
                //after a while this dies with new code? wtf?
            }
            serialPort.Close();
        }

        private void ColorTest(IProgress<string> progress) {
            progress.Report("Red LEDs");
            SendLEDUniformColour(127, 0, 0, 0x7f);
            System.Threading.Thread.Sleep(1000);
            progress.Report("Green LEDs");
            SendLEDUniformColour(0, 127, 0, 0x7f);
            System.Threading.Thread.Sleep(1000);
            progress.Report("Blue LEDs");
            SendLEDUniformColour(0, 0, 127, 0x7f);
            System.Threading.Thread.Sleep(1000);
            progress.Report("LEDs off");
            SendLEDUniformColour(0, 0, 0, 0x7f);
            System.Threading.Thread.Sleep(1000);
        }

        private void sliderTask(IProgress<string> progress) {
            serialPort = new SerialPort();
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 115200;
            serialPort.WriteTimeout = 3000;
            serialPort.ReadTimeout = 3000;
            serialPort.Open();
            if (SliderInit(progress)) {
                ColorTest(progress);
                InputTest(progress);
            } else {
                serialPort.Close();
            }
        }

        private void SliderTestWindow_FormClosing(object sender, FormClosingEventArgs e) {
            active = false;
        }
    }
}
