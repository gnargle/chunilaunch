using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class MainWindow : Form {
        private IniFile ini;
        private enum Status { Remote, Local };
        private Status currentStatus;
        private string combinedBatchLoc;
        private string serverBatchLoc;
        private string chuniBatchLoc;
        private string remoteServerAddress;
        private string localServerAddress;
        private string remoteFelica;
        private string localFelica;
        private string ledPort;
        public MainWindow() {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e) {
            ini = new IniFile("chunilaunch.ini");

            if (!ini.KeyExists("profile")) {
                ini.Write("profile", "remote");
            }
            var profile = ini.Read("profile");
            if (string.Equals(profile, "remote", StringComparison.InvariantCultureIgnoreCase)) {
                currentStatus = Status.Remote;
                rbRemoteProfile.Checked = true;
            } else if (string.Equals(profile, "local", StringComparison.InvariantCultureIgnoreCase)) {
                currentStatus = Status.Local;
                rbLocalProfile.Checked = true;
            }

            combinedBatchLoc = ini.Read("batchFile");
            tbBatchFile.Text = combinedBatchLoc;
            serverBatchLoc = ini.Read("serverBatch");
            tbServer.Text = serverBatchLoc;
            chuniBatchLoc = ini.Read("chuniBatch");
            tbChuni.Text = chuniBatchLoc;
            cbWindowedMode.Checked = CheckIniBool("windowed");
            cbEnableChunitachi.Checked = CheckIniBool("chunitachi");
            cbEnableSliderEmu.Checked = CheckIniBool("slideremu");
            cbAimeEmulation.Checked = CheckIniBool("aimeemu");

            remoteServerAddress = ini.Read("remoteServer");
            tbRemoteAddress.Text = remoteServerAddress;
            localServerAddress = ini.Read("localServer");
            tbLocalAddress.Text = localServerAddress;

            remoteFelica = ini.Read("remoteFelica");
            tbRemoteFelica.Text = remoteFelica;
            localFelica = ini.Read("localFelica");
            tbLocalFelica.Text = localFelica;

            ledPort = ini.Read("ledport");

            //populate com port list         
            var ports = SerialPort.GetPortNames();

            for (int i = 1; i < 10; i++) { //arbitrary limit, but who has more than 10 com ports open on a modern pc?
                var portName = $"COM{i}";
                if (!ports.Contains(portName)) {
                    var index = cbLEDPort.Items.Add(portName);
                    if (portName == ledPort) cbLEDPort.SelectedIndex = index;
                }
            };
        }

        private bool CheckIniBool(string option) {
            if (ini != null) {
                return ini.Read(option) != "0";
            } else throw new DataException("ini not initialised.");
        }

        private void ChangeProfile(Status newStatus) {
            if (ini == null) return; //still initialising...
            if (currentStatus == newStatus) return; //during initial launch or something's gone weird, don't change anything.            
            //first, change SegaTools.
            var SegaToolsIni = new IniFile("segatools.ini");
            SegaToolsIni.Write("default", newStatus == Status.Remote ? remoteServerAddress : localServerAddress, "dns");
            //now change the felica card to use
            File.Delete(@"DEVICE\felica.txt");
            if (newStatus == Status.Remote) {
                File.WriteAllText(@"DEVICE\felica.txt", remoteFelica);
            } else {
                File.WriteAllText(@"DEVICE\felica.txt", localFelica);
            }
            //replace the combined batch file.
            File.Delete(combinedBatchLoc);
            string serverLaunchLine = newStatus == Status.Remote ? $"::start \"\" \"{serverBatchLoc}\"" : $"start \"\" \"{serverBatchLoc}\"";
            File.WriteAllLines(combinedBatchLoc, new String[] { serverLaunchLine, $"start \"\" \"{chuniBatchLoc}\" " });
            ini.Write("profile", newStatus == Status.Remote ? "remote" : "local");
            currentStatus = newStatus;
        }

        private void rbRemoteProfile_CheckedChanged(object sender, EventArgs e) {
            if (rbRemoteProfile.Checked)
                ChangeProfile(Status.Remote);
        }

        private void rbLocalProfile_CheckedChanged(object sender, EventArgs e) {
            if (rbLocalProfile.Checked)
                ChangeProfile(Status.Local);
        }

        private void bLaunch_Click(object sender, EventArgs e) {
            var startInfo = new ProcessStartInfo {
                FileName = combinedBatchLoc,
                WorkingDirectory = Path.GetDirectoryName(combinedBatchLoc)
            };
            System.Diagnostics.Process.Start(startInfo);
            Close();
        }

        private void bOpen_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                if (sender == bCombinedOpen) {
                    combinedBatchLoc = openFileDialog1.FileName;
                    tbBatchFile.Text = combinedBatchLoc;
                    ini.Write("batchFile", combinedBatchLoc);
                } else if (sender == bServerOpen) {
                    serverBatchLoc = openFileDialog1.FileName;
                    tbServer.Text = serverBatchLoc;
                    ini.Write("serverBatch", serverBatchLoc);
                } else if (sender == bChuniOpen) {
                    chuniBatchLoc = openFileDialog1.FileName;
                    tbChuni.Text = chuniBatchLoc;
                    ini.Write("chuniBatch", chuniBatchLoc);
                }
            }
        }

        private void cbWindowedMode_CheckedChanged(object sender, EventArgs e) {
            if (ini != null) {
                var SegaToolsIni = new IniFile("segatools.ini");
                SegaToolsIni.Write("windowed", cbWindowedMode.Checked ? "1" : "0", "gfx");
                SegaToolsIni.Write("framed", cbWindowedMode.Checked ? "1" : "0", "gfx");
                ini.Write("windowed", cbWindowedMode.Checked ? "1" : "0");
            }
        }

        private void tbRemoteAddress_TextChanged(object sender, EventArgs e) {
            if (ini != null) {
                remoteServerAddress = tbRemoteAddress.Text;
                ini.Write("remoteServer", remoteServerAddress);
            }
        }

        private void tbLocalServer_TextChanged(object sender, EventArgs e) {
            if (ini != null) {
                localServerAddress = tbLocalAddress.Text;
                ini.Write("localServer", localServerAddress);
            }
        }

        private void tbRemoteFelica_TextChanged(object sender, EventArgs e) {
            if (ini != null) {
                remoteFelica = tbRemoteFelica.Text;
                ini.Write("remoteFelica", remoteFelica);
            }
        }

        private void tbLocalFelica_TextChanged(object sender, EventArgs e) {
            if (ini != null) {
                localFelica = tbLocalFelica.Text;
                ini.Write("localFelica", localFelica);
            }
        }

        private void cbEnableChunitachi_CheckedChanged(object sender, EventArgs e) {
            if (ini != null) {
                var chuniBatch = File.ReadAllLines(chuniBatchLoc);
                for (int i = 0; i <= chuniBatch.Count() - 1; i++) {
                    var line = chuniBatch[i];
                    if (line.Contains("chuniApp")) {
                        if (cbEnableChunitachi.Checked) {
                            line = "start /high /affinity f0 inject -d -k chunihook.dll -k ChunItachi.dll chuniApp.exe";
                        } else {
                            line = "start /high /affinity f0 inject -d -k chunihook.dll chuniApp.exe";
                        }
                        chuniBatch[i] = line;
                        File.WriteAllLines(chuniBatchLoc, chuniBatch);
                        break;
                    }
                    //futureproofing ;)
                    if (line.Contains("chusanApp")) {
                        if (cbEnableChunitachi.Checked) {
                            line = "start /high /affinity f0 inject -d -k chusanhook.dll -k ChunItachi.dll chusanApp.exe";
                        } else {
                            line = "start /high /affinity f0 inject -d -k chusanhook.dll chusanApp.exe";
                        }
                        chuniBatch[i] = line;
                        File.WriteAllLines(chuniBatchLoc, chuniBatch);
                        break;
                    }
                }
                ini.Write("chunitachi", cbEnableChunitachi.Checked ? "1" : "0");
            }
        }

        private void cbEnableSliderEmu_CheckedChanged(object sender, EventArgs e) {
            if (ini != null) {
                var SegaToolsIni = new IniFile("segatools.ini");
                SegaToolsIni.Write("enable", cbEnableSliderEmu.Checked ? "1" : "0", "slider");
                ini.Write("slideremu", cbEnableSliderEmu.Checked ? "1" : "0");
            }
            bTestACSlider.Enabled = !cbEnableSliderEmu.Checked;
        }

        private void cbLEDPort_SelectedIndexChanged(object sender, EventArgs e) {
            if (ini != null) {
                var SegaToolsIni = new IniFile("segatools.ini");
                SegaToolsIni.Write("ledport", cbLEDPort.SelectedItem.ToString(), "slider");
                ini.Write("ledport", cbLEDPort.SelectedItem.ToString());
            }
        }

        private void bTestACSlider_Click(object sender, EventArgs e) {
            //open new modal window and run (a port of) Red's test code.
            var testWnd = new SliderTestWindow();            
            testWnd.ShowDialog();
            testWnd.Close();
        }

        private void cbAimeEmulation_CheckedChanged(object sender, EventArgs e) {
            if (ini != null) {
                var SegaToolsIni = new IniFile("segatools.ini");
                SegaToolsIni.Write("enable", cbAimeEmulation.Checked ? "1" : "0", "aime");
                ini.Write("aimeemu", cbAimeEmulation.Checked ? "1" : "0");
            }
            bTestAimeReader.Enabled = !cbAimeEmulation.Checked;
        }

        private void bTestAimeReader_Click(object sender, EventArgs e) {
            //open new modal window and run tesst code for slider
            var testWnd = new AimeTestWindow();
            testWnd.ShowDialog();
            testWnd.Close();
        }
    }
}
