using System;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class AimeTestWindow : Form {
        private SerialPort serialPort;
        private bool active = true;
        private byte _seq;
        private int currCol = 0;
        private bool rainbowDir = true;
        private bool _chusan;

        private const byte AIME_ESCAPE = 0xd0;
        private const byte RESET_CMD = 0x62;
        private const byte LED_CMD = 0x81;
        private const byte FELICA_CMD = 0x42;
        private const byte UNK_CARD_CMD_1 = 0x40;
        private const byte UNK_CARD_CMD_2 = 0x42;
        private const byte UNK_1 = 0x00;
        private const byte UNK_2 = 0x08;

        private byte seqnum {
            get {
                return _seq;
            }
            set {
                if (value > 0xff) {
                    _seq = 0;
                } else {
                    _seq++;
                }
            }
        }
        public AimeTestWindow(bool chusan) {
            InitializeComponent();
            _chusan = chusan;
        }

        private void AimeTestWindow_Load(object sender, EventArgs e) {
            seqnum = 0x01;
            var progress = new Progress<string>(update => { lbStatusText.Text = update; });
            Task aimeRunner = new Task(() => aimeTask(progress));
            aimeRunner.Start();
        }
        //command format: e0, length, unk (can be 0 or 8 which is weird), seqnum, command, data, checksum

        struct Command {
            public byte sync; //always e0
            public byte length;
            public byte unk; //00 or 08?
            public byte seqnum; //wraps at 0xff
            public byte command;
            public byte[] data;
            public byte checksum;
        }

        private byte Checksum(Command com) {
            var chksm = com.length + com.unk + com.seqnum + com.command;
            foreach (var b in com.data) {
                chksm += b;
            }
            return (byte)chksm;
        }

        private Command ReadSerial() {
            var com = new Command();
            byte sync = 0x00;
            //sync byte is e0, it should be the first byte, scan till we get it.
            while (sync != 0xe0) {
                sync = ReadByte();
            }
            com.sync = sync;
            com.length = ReadByte();
            com.unk = ReadByte();
            com.seqnum = ReadByte();
            seqnum = com.seqnum; //update our sequence to keep track.
            com.command = ReadByte();
            com.data = new byte[com.length - 4]; //account for unk, seqnum, command, checksum
            com.data = ReadTotalLength(com.data, com.data.Length);
            com.checksum = ReadByte();
            return com;
        }

        private byte[] ReadTotalLength(byte[] arr, int bytesToRead) {
            int read = 0;
            while (read < bytesToRead) {
                arr[read] = ReadByte();
                read++;
            }
            return arr;
        }

        private byte ReadByte() {
            int b = serialPort.ReadByte();
            if (b == AIME_ESCAPE) {
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
            if (b == AIME_ESCAPE || b == 0xe0) {
                serialPort.Write(new byte[] { AIME_ESCAPE, (byte)(b - 1) }, 0, 2);
            } else
                serialPort.Write(new byte[] { b }, 0, 1);
        }

        private string packetToString(byte[] arr) {
            string s = string.Empty;
            foreach (var b in arr) {
                s += $"{b},";
            }
            s += "\n";
            return s;
        }

        private void SendCommand(byte unk, byte commandByte, byte[] data) {
            var command = new Command() {
                sync = 0xe0,
                length = (byte)(data.Length + 4), //including unk, seqnum, command, checksum
                unk = unk,
                seqnum = seqnum,
                command = commandByte,
                data = data,
            };
            command.checksum = Checksum(command); //skip 1 as we don't add the sync in the checksum

            serialPort.Write(new byte[] { command.sync }, 0, 1); //don't escape this byte, lol
            WriteEscapedByte(command.length);
            WriteEscapedByte(command.unk);
            WriteEscapedByte(command.seqnum);
            WriteEscapedByte(command.command);
            WriteAllBytes(command.data);
            WriteEscapedByte(command.checksum);
        }

        private bool ReaderInit(IProgress<string> progress) {
            SendCommand(UNK_1, RESET_CMD, new byte[] { 0x00 });
            var returnedCom = ReadSerial();

            if (returnedCom.command == RESET_CMD && returnedCom.data.SequenceEqual(new byte[] { 0x03, 0x00 })) { //reset is ok response
                progress.Report("Reset OK");
            } else {
                progress.Report("Reset not OK");
                return false;
            }
            return true;
        }

        private void LEDRainbow() {
            //because you gotta have fun stuff.
            var frequency = 0.3;
            byte red = (byte)(Math.Sin(frequency * currCol + 0) * 127 + 128);
            byte green = (byte)(Math.Sin(frequency * currCol + 4) * 127 + 128);
            byte blue = (byte)(Math.Sin(frequency * currCol + 2) * 127 + 128);
            SendLED(red, green, blue);
            if (rainbowDir)
                currCol++;
            else
                currCol--;
            if (currCol == 31 || currCol == 0) rainbowDir = !rainbowDir;
        }


        private void ReadCard(IProgress<string> progress) {
            //seemingly relevant commands - 40,41,42.        
            //command 42, data 00            
            SendCommand(UNK_1, FELICA_CMD, new byte[] { 0x00 });
            var resp = ReadSerial();
            if (resp.command == FELICA_CMD && resp.data.Length > 4) {
                //card of some type 1 found, read card data and talk to reader.
                
                //first five bytes are something else, then you have 8 bytes which are the cards Identifier.
                var cardId = resp.data.Skip(5).Take(8).ToArray();
                var cardStr = BitConverter.ToString(cardId).Replace("-", string.Empty);
                progress.Report($"Card Found!\n\rCard ID: {cardStr}");
                SendLED(0, 0, 0xff);
                System.Threading.Thread.Sleep(1000);
                return;
            }
            //command 41, data 00
            SendCommand(UNK_1, UNK_CARD_CMD_2, new byte[] { 0x00 });
            resp = ReadSerial();
            if (resp.command == UNK_CARD_CMD_2 && resp.data.Length > 4) {
                //card of some type 1 found, read card data and talk to reader.
                progress.Report("Card Found!");
                SendLED(0, 0, 0xff);
                System.Threading.Thread.Sleep(1000);
                return;
            }
            //data seems to send command 40, then data 01 03.
            SendCommand(UNK_1, UNK_CARD_CMD_1, new byte[] { 0x01, 0x03 });
            resp = ReadSerial();
            if (resp.command == UNK_CARD_CMD_1 && resp.data.Length > 4) {
                //card of some type 1 found, read card data and talk to reader.
                progress.Report("Card Found!");
                SendLED(0, 0, 0xff);
                System.Threading.Thread.Sleep(1000);
                return;
            }
            progress.Report("Card not found.");
            LEDRainbow();
            System.Threading.Thread.Sleep(500); //pause or we don't get the data
            //and repeat
            //this appears to be checking for 3 different types of cards. 
            //each of these commands appears to have a unique unk, which I guess is a secondary command byte...
        }

        private void SendLED(byte red, byte green, byte blue) {
            byte command = LED_CMD;
            byte[] data = new byte[] { 0x03 }; //always starts with 03 for some reason. Then followed by 3 bytes of rgb value.
            data = data.Append(red).ToArray();
            data = data.Append(blue).ToArray();
            data = data.Append(green).ToArray();
            SendCommand(UNK_2, command, data); //unk is 08 for this one.
        }

        private void LEDTest(IProgress<string> progress) {
            progress.Report("Red LEDs");
            SendLED(0xff, 0, 0);
            System.Threading.Thread.Sleep(1000);
            progress.Report("Blue LEDs");
            SendLED(0, 0xff, 0);
            System.Threading.Thread.Sleep(1000);
            progress.Report("Green LEDs");
            SendLED(0, 0, 0xff);
            System.Threading.Thread.Sleep(1000);
            progress.Report("White LEDs");
            SendLED(0xff, 0xff, 0xff);
            System.Threading.Thread.Sleep(1000);
            progress.Report("LEDs off");
            SendLED(0, 0, 0);
        }

        private void aimeTask(IProgress<string> progress) {
            serialPort = new SerialPort();
            if (_chusan) {
                serialPort.PortName = "COM4"; //config_sp uses a different com, but the baud rate can remain the same. 
                serialPort.BaudRate = 38400;
            } else {
                serialPort.PortName = "COM12";
                serialPort.BaudRate = 38400;
            }
            serialPort.WriteTimeout = 3000;
            serialPort.ReadTimeout = 3000;
            serialPort.Open();
            if (ReaderInit(progress)) {
                LEDTest(progress);
                while (active) {
                    ReadCard(progress); 
                }
                serialPort.Close();
            } else {
                serialPort.Close();
            }
        }

        private void AimeTestWindow_FormClosing(object sender, FormClosingEventArgs e) {
            active = false;
        }
    }
}
