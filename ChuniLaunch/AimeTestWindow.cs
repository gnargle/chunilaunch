using System;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class AimeTestWindow : Form {
        private SerialPort serialPort;
        private bool active = true;
        private const byte AIME_ESCAPE = 0xd0;
        private byte _seq;
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
        public AimeTestWindow() {
            InitializeComponent();
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
            if (b == 0xd0 || b == 0xe0) {
                serialPort.Write(new byte[] { 0xd0, (byte)(b - 1) }, 0, 2);
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
            SendCommand(0x00, 0x62, new byte[] { 0x00 });
            //SendCommand(new byte[] { 0xE0, 0x05, 0x00, 0x01, 0x62, 0x00 }); //reset
            var returnedCom = ReadSerial();

            if (returnedCom.command == 0x62 && returnedCom.data.SequenceEqual(new byte[] { 0x03, 0x00 })) { //reset is ok response
                progress.Report("Reset OK");
            } else {
                progress.Report("Reset not OK");
                return false;
            }
            return false;

            // SendCommand(new byte[] { 0xE0, 0x05, 0x00, 0x02, 0x30, 0x00, });
            /* returnedCom = new byte[08];

             returnedCom = ReadTotalLength(returnedCom, returnedCom.Length);

             if (returnedCom.SequenceEqual(new byte[] { 0xFF, 0xF0, 0x12, 0x31, 0x35, 0x33, 0x33, 0x30, 0x20, 0x20, 0x20, 0xA0, 0x30, 0x36, 0x37, 0x31, 0x32, 0xFD, 0xFE, 0x90, 0x00, 0x64 })) {
                 progress.Report("HW Info OK");
                 return true;
             } else {
                 progress.Report("HW Info not OK");
                 return false;
             }*/
        }

        private void aimeTask(IProgress<string> progress) {
            serialPort = new SerialPort();
            serialPort.PortName = "COM12";
            serialPort.BaudRate = 38400;
            serialPort.WriteTimeout = 3000;
            serialPort.ReadTimeout = 3000;
            serialPort.Open();
            if (ReaderInit(progress)) {

            } else {
                serialPort.Close();
            }
        }

        private void AimeTestWindow_FormClosing(object sender, FormClosingEventArgs e) {
            active = false;
        }
    }
}
