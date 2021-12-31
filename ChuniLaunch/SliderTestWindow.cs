using System;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class SliderTestWindow : Form {
        private SerialPort serialPort;
        private bool active = true;
        public SliderTestWindow() {
            InitializeComponent();
        }

        private void SliderTestWindow_Load(object sender, EventArgs e) {
            var progress = new Progress<string>(update => { lbStatusText.Text = update; });
            Task sliderRunner = new Task(() => sliderTask(progress));
            sliderRunner.Start();
        }

        //from here, everything is a ported version of CrazyRedMachine's python test harnerss. They did the hard work so I don't have to!
        private byte Checksum(byte[] arr) {

            var chksm = -1*arr.Sum(b => b);
            return (byte)chksm;
        }

        private byte[] ReadTotalLength(byte[] arr, int bytesToRead) {
            int read = 0;
            while (read < bytesToRead) {
                read += serialPort.Read(arr, read, bytesToRead - read);
            }
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

        private void SendLED(int red, int green, int blue) {
            var command = new byte[] { 0xff, 0x02, 0x5e, 0x7f };
            for (int i = 0; i < 31; i++) {
                command = command.Append((byte)blue).ToArray();
                command = command.Append((byte)red).ToArray();
                command = command.Append((byte)green).ToArray();
            }
            SendCommand(command);
        }        

        private void RetrieveInput(byte[] touchData) {
            //find and skip sync byte so we know where we are.
            var currByte = serialPort.ReadByte();
            if (currByte != 0xff) {
                while(currByte!= 0xff) {
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
                read += serialPort.Read(touchData, read, 32 - read);
            }
            
            currByte = serialPort.ReadByte(); //checksum byte, but we're hacking so who gaf about that            
        }

        private void SendLEDReactive(byte[] touchData) {
            var command = new byte[] { 0xff, 0x02, 0x5e, 0x7f };
            for (int i = 0; i < 31; i++) {
                if (i % 2 != 0) {
                    //odd, separator
                    command = command.Append((byte)0x7f).ToArray();
                    command = command.Append((byte)0x23).ToArray();
                    command = command.Append((byte)0).ToArray();
                } else if (touchData[i] > 0) {
                    //top zone
                    command = command.Append((byte)0x23).ToArray();
                    command = command.Append((byte)0).ToArray();
                    command = command.Append((byte)0x7f).ToArray();
                } else if (touchData[i+1] > 0) {
                    //top zone
                    command = command.Append((byte)0).ToArray();
                    command = command.Append((byte)0x7f).ToArray();
                    command = command.Append((byte)0x23).ToArray();
                } else {
                    command = command.Append((byte)0).ToArray();
                    command = command.Append((byte)0).ToArray();
                    command = command.Append((byte)0).ToArray();
                }
            }
            SendCommand(command);
        }

        private bool SliderInit(IProgress<string> progress) {
            SendCommand(new byte[] { 0xff, 0x10, 0x00 });
            var returnedBytes = new byte[4];
            returnedBytes = ReadTotalLength(returnedBytes, 4);

            if (returnedBytes.SequenceEqual(new byte[] { 0xff, 0x10, 0x00, 0xf1 })) {
                progress.Report("Reset OK");
            } else {
                progress.Report("Reset not OK");
                return false;
            }

            SendCommand(new byte[] { 0xff, 0xf0, 0x00 });
            returnedBytes = new byte[22];

            returnedBytes = ReadTotalLength(returnedBytes, 22);

            if (returnedBytes.SequenceEqual(new byte[] { 0xFF, 0xF0, 0x12, 0x31, 0x35, 0x33, 0x33, 0x30, 0x20, 0x20, 0x20, 0xA0, 0x30, 0x36, 0x37, 0x31, 0x32, 0xFD, 0xFE, 0x90, 0x00, 0x64 })) {
                progress.Report("HW Info OK");
                return true;
            } else {
                progress.Report("HW Info not OK");
                return false;
            }
        }
        private void InputTest(IProgress<string> progress) {
            progress.Report("IO Test");
            SendCommand(new byte[] { 0xff, 0x03, 0x00 });
            var touchData = new byte[32];
            while (active) {
                RetrieveInput(touchData);
                SendLEDReactive(touchData);
            }
            serialPort.Close();
        }

        private void ColorTest(IProgress<string> progress) {
            progress.Report("Red LEDs");
            SendLED(127, 0, 0);
            System.Threading.Thread.Sleep(1000);
            progress.Report("Green LEDs");
            SendLED(0, 127, 0);
            System.Threading.Thread.Sleep(1000);
            progress.Report("Blue LEDs");
            SendLED(0, 0, 127);
            System.Threading.Thread.Sleep(1000);
            progress.Report("LEDs off");
            SendLED(0, 0, 0);
        }

        private void sliderTask(IProgress<string>progress) {
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
