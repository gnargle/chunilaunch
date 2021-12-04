using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuniLaunch {
    public partial class Form1 : Form {
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
        public Form1() {
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
            cbWindowedMode.Checked = ini.Read("windowed") != "0";

            remoteServerAddress = ini.Read("remoteServer");
            tbRemoteAddress.Text = remoteServerAddress;
            localServerAddress = ini.Read("localServer");
            tbLocalAddress.Text = localServerAddress;

            remoteFelica = ini.Read("remoteFelica");
            tbRemoteFelica.Text = remoteFelica;
            localFelica = ini.Read("localFelica");
            tbLocalFelica.Text = localFelica;
        }

        private void ChangeProfile(Status newStatus) {
            if (ini == null) return; //still initialising...
            if (currentStatus == newStatus) return; //during initial launch or something's gone weird, don't change anything.            
            //first, change SegaTools.
            var SegaToolsIni = new IniFile("segatools.ini");
            SegaToolsIni.Write("default", newStatus == Status.Remote ? remoteServerAddress : localServerAddress, "dns");
            //now change the felica card to use
            File.Delete(@"DEVICE\felica.txt");
            if(newStatus == Status.Remote) {
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
    }
}
