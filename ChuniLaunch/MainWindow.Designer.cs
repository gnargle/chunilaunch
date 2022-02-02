
namespace ChuniLaunch {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.rbRemoteProfile = new System.Windows.Forms.RadioButton();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBatchFile = new System.Windows.Forms.TextBox();
            this.bCombinedOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.bServerOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbChuni = new System.Windows.Forms.TextBox();
            this.bChuniOpen = new System.Windows.Forms.Button();
            this.flpRemote = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRemoteAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRemoteFelica = new System.Windows.Forms.TextBox();
            this.cbRemoteServ1 = new System.Windows.Forms.CheckBox();
            this.flpLocal = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLocalAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLocalFelica = new System.Windows.Forms.TextBox();
            this.cbRemoteServ2 = new System.Windows.Forms.CheckBox();
            this.rbLocalProfile = new System.Windows.Forms.RadioButton();
            this.bApplyServer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.cbWindowedMode = new System.Windows.Forms.CheckBox();
            this.cbEnableChunitachi = new System.Windows.Forms.CheckBox();
            this.cbEnableSliderEmu = new System.Windows.Forms.CheckBox();
            this.bTestACSlider = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cbLEDPort = new System.Windows.Forms.ComboBox();
            this.cbAimeEmulation = new System.Windows.Forms.CheckBox();
            this.bTestAimeReader = new System.Windows.Forms.Button();
            this.bLaunch = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.flpMain.SuspendLayout();
            this.flpRemote.SuspendLayout();
            this.flpLocal.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbRemoteProfile
            // 
            this.rbRemoteProfile.AutoSize = true;
            this.rbRemoteProfile.Location = new System.Drawing.Point(3, 219);
            this.rbRemoteProfile.Name = "rbRemoteProfile";
            this.rbRemoteProfile.Size = new System.Drawing.Size(65, 17);
            this.rbRemoteProfile.TabIndex = 0;
            this.rbRemoteProfile.TabStop = true;
            this.rbRemoteProfile.Text = "Server 1";
            this.rbRemoteProfile.UseVisualStyleBackColor = true;
            // 
            // flpMain
            // 
            this.flpMain.Controls.Add(this.label1);
            this.flpMain.Controls.Add(this.tbBatchFile);
            this.flpMain.Controls.Add(this.bCombinedOpen);
            this.flpMain.Controls.Add(this.label2);
            this.flpMain.Controls.Add(this.tbServer);
            this.flpMain.Controls.Add(this.bServerOpen);
            this.flpMain.Controls.Add(this.label3);
            this.flpMain.Controls.Add(this.tbChuni);
            this.flpMain.Controls.Add(this.bChuniOpen);
            this.flpMain.Controls.Add(this.flpRemote);
            this.flpMain.Controls.Add(this.flpLocal);
            this.flpMain.Controls.Add(this.rbRemoteProfile);
            this.flpMain.Controls.Add(this.rbLocalProfile);
            this.flpMain.Controls.Add(this.bApplyServer);
            this.flpMain.Controls.Add(this.flowLayoutPanel1);
            this.flpMain.Controls.Add(this.bLaunch);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 0);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(484, 380);
            this.flpMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Combined Start batch location     ";
            // 
            // tbBatchFile
            // 
            this.tbBatchFile.Location = new System.Drawing.Point(173, 3);
            this.tbBatchFile.Name = "tbBatchFile";
            this.tbBatchFile.ReadOnly = true;
            this.tbBatchFile.Size = new System.Drawing.Size(248, 20);
            this.tbBatchFile.TabIndex = 3;
            // 
            // bCombinedOpen
            // 
            this.bCombinedOpen.Location = new System.Drawing.Point(427, 3);
            this.bCombinedOpen.Name = "bCombinedOpen";
            this.bCombinedOpen.Size = new System.Drawing.Size(54, 23);
            this.bCombinedOpen.TabIndex = 4;
            this.bCombinedOpen.Text = "Open...";
            this.bCombinedOpen.UseVisualStyleBackColor = true;
            this.bCombinedOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Local Server Start batch location";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(171, 32);
            this.tbServer.Name = "tbServer";
            this.tbServer.ReadOnly = true;
            this.tbServer.Size = new System.Drawing.Size(248, 20);
            this.tbServer.TabIndex = 7;
            // 
            // bServerOpen
            // 
            this.bServerOpen.Location = new System.Drawing.Point(425, 32);
            this.bServerOpen.Name = "bServerOpen";
            this.bServerOpen.Size = new System.Drawing.Size(54, 23);
            this.bServerOpen.TabIndex = 9;
            this.bServerOpen.Text = "Open...";
            this.bServerOpen.UseVisualStyleBackColor = true;
            this.bServerOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Chuniapp Start batch location     ";
            // 
            // tbChuni
            // 
            this.tbChuni.Location = new System.Drawing.Point(171, 61);
            this.tbChuni.Name = "tbChuni";
            this.tbChuni.ReadOnly = true;
            this.tbChuni.Size = new System.Drawing.Size(248, 20);
            this.tbChuni.TabIndex = 10;
            // 
            // bChuniOpen
            // 
            this.bChuniOpen.Location = new System.Drawing.Point(425, 61);
            this.bChuniOpen.Name = "bChuniOpen";
            this.bChuniOpen.Size = new System.Drawing.Size(54, 23);
            this.bChuniOpen.TabIndex = 12;
            this.bChuniOpen.Text = "Open...";
            this.bChuniOpen.UseVisualStyleBackColor = true;
            this.bChuniOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // flpRemote
            // 
            this.flpRemote.Controls.Add(this.label8);
            this.flpRemote.Controls.Add(this.label4);
            this.flpRemote.Controls.Add(this.tbRemoteAddress);
            this.flpRemote.Controls.Add(this.label6);
            this.flpRemote.Controls.Add(this.tbRemoteFelica);
            this.flpRemote.Controls.Add(this.cbRemoteServ1);
            this.flpRemote.Location = new System.Drawing.Point(3, 90);
            this.flpRemote.Name = "flpRemote";
            this.flpRemote.Size = new System.Drawing.Size(234, 123);
            this.flpRemote.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Server 1 Settings         ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Address";
            // 
            // tbRemoteAddress
            // 
            this.tbRemoteAddress.Location = new System.Drawing.Point(3, 33);
            this.tbRemoteAddress.Name = "tbRemoteAddress";
            this.tbRemoteAddress.Size = new System.Drawing.Size(222, 20);
            this.tbRemoteAddress.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Felica";
            // 
            // tbRemoteFelica
            // 
            this.tbRemoteFelica.Location = new System.Drawing.Point(3, 72);
            this.tbRemoteFelica.Name = "tbRemoteFelica";
            this.tbRemoteFelica.Size = new System.Drawing.Size(222, 20);
            this.tbRemoteFelica.TabIndex = 15;
            this.tbRemoteFelica.TextChanged += new System.EventHandler(this.tbRemoteFelica_TextChanged);
            // 
            // cbRemoteServ1
            // 
            this.cbRemoteServ1.AutoSize = true;
            this.cbRemoteServ1.Location = new System.Drawing.Point(3, 98);
            this.cbRemoteServ1.Name = "cbRemoteServ1";
            this.cbRemoteServ1.Size = new System.Drawing.Size(63, 17);
            this.cbRemoteServ1.TabIndex = 19;
            this.cbRemoteServ1.Text = "Remote";
            this.cbRemoteServ1.UseVisualStyleBackColor = true;
            this.cbRemoteServ1.CheckedChanged += new System.EventHandler(this.cbRemoteServ_CheckedChanged);
            // 
            // flpLocal
            // 
            this.flpLocal.Controls.Add(this.label5);
            this.flpLocal.Controls.Add(this.label9);
            this.flpLocal.Controls.Add(this.tbLocalAddress);
            this.flpLocal.Controls.Add(this.label7);
            this.flpLocal.Controls.Add(this.tbLocalFelica);
            this.flpLocal.Controls.Add(this.cbRemoteServ2);
            this.flpLocal.Location = new System.Drawing.Point(243, 90);
            this.flpLocal.Name = "flpLocal";
            this.flpLocal.Size = new System.Drawing.Size(234, 123);
            this.flpLocal.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Server 2 Settings              ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Address";
            // 
            // tbLocalAddress
            // 
            this.tbLocalAddress.Location = new System.Drawing.Point(3, 33);
            this.tbLocalAddress.Name = "tbLocalAddress";
            this.tbLocalAddress.Size = new System.Drawing.Size(226, 20);
            this.tbLocalAddress.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Felica";
            // 
            // tbLocalFelica
            // 
            this.tbLocalFelica.Location = new System.Drawing.Point(3, 72);
            this.tbLocalFelica.Name = "tbLocalFelica";
            this.tbLocalFelica.Size = new System.Drawing.Size(226, 20);
            this.tbLocalFelica.TabIndex = 17;
            this.tbLocalFelica.TextChanged += new System.EventHandler(this.tbLocalFelica_TextChanged);
            // 
            // cbRemoteServ2
            // 
            this.cbRemoteServ2.AutoSize = true;
            this.cbRemoteServ2.Location = new System.Drawing.Point(3, 98);
            this.cbRemoteServ2.Name = "cbRemoteServ2";
            this.cbRemoteServ2.Size = new System.Drawing.Size(63, 17);
            this.cbRemoteServ2.TabIndex = 21;
            this.cbRemoteServ2.Text = "Remote";
            this.cbRemoteServ2.UseVisualStyleBackColor = true;
            this.cbRemoteServ2.CheckedChanged += new System.EventHandler(this.cbRemoteServ_CheckedChanged);
            // 
            // rbLocalProfile
            // 
            this.rbLocalProfile.AutoSize = true;
            this.rbLocalProfile.Location = new System.Drawing.Point(74, 219);
            this.rbLocalProfile.Name = "rbLocalProfile";
            this.rbLocalProfile.Size = new System.Drawing.Size(65, 17);
            this.rbLocalProfile.TabIndex = 1;
            this.rbLocalProfile.TabStop = true;
            this.rbLocalProfile.Text = "Server 2";
            this.rbLocalProfile.UseVisualStyleBackColor = true;
            // 
            // bApplyServer
            // 
            this.bApplyServer.Location = new System.Drawing.Point(145, 219);
            this.bApplyServer.Name = "bApplyServer";
            this.bApplyServer.Size = new System.Drawing.Size(120, 23);
            this.bApplyServer.TabIndex = 21;
            this.bApplyServer.Text = "Apply Server Settings";
            this.bApplyServer.UseVisualStyleBackColor = true;
            this.bApplyServer.Click += new System.EventHandler(this.bApplyServer_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.cbWindowedMode);
            this.flowLayoutPanel1.Controls.Add(this.cbEnableChunitachi);
            this.flowLayoutPanel1.Controls.Add(this.cbEnableSliderEmu);
            this.flowLayoutPanel1.Controls.Add(this.bTestACSlider);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.cbLEDPort);
            this.flowLayoutPanel1.Controls.Add(this.cbAimeEmulation);
            this.flowLayoutPanel1.Controls.Add(this.bTestAimeReader);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 248);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(469, 79);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "General Settings";
            // 
            // cbWindowedMode
            // 
            this.cbWindowedMode.AutoSize = true;
            this.cbWindowedMode.Location = new System.Drawing.Point(139, 3);
            this.cbWindowedMode.Name = "cbWindowedMode";
            this.cbWindowedMode.Size = new System.Drawing.Size(107, 17);
            this.cbWindowedMode.TabIndex = 5;
            this.cbWindowedMode.Text = "Windowed Mode";
            this.cbWindowedMode.UseVisualStyleBackColor = true;
            this.cbWindowedMode.CheckedChanged += new System.EventHandler(this.cbWindowedMode_CheckedChanged);
            // 
            // cbEnableChunitachi
            // 
            this.cbEnableChunitachi.AutoSize = true;
            this.cbEnableChunitachi.Location = new System.Drawing.Point(252, 3);
            this.cbEnableChunitachi.Name = "cbEnableChunitachi";
            this.cbEnableChunitachi.Size = new System.Drawing.Size(112, 17);
            this.cbEnableChunitachi.TabIndex = 19;
            this.cbEnableChunitachi.Text = "Enable Chunitachi";
            this.cbEnableChunitachi.UseVisualStyleBackColor = true;
            this.cbEnableChunitachi.CheckedChanged += new System.EventHandler(this.cbEnableChunitachi_CheckedChanged);
            // 
            // cbEnableSliderEmu
            // 
            this.cbEnableSliderEmu.AutoSize = true;
            this.cbEnableSliderEmu.Location = new System.Drawing.Point(3, 26);
            this.cbEnableSliderEmu.Name = "cbEnableSliderEmu";
            this.cbEnableSliderEmu.Size = new System.Drawing.Size(137, 17);
            this.cbEnableSliderEmu.TabIndex = 21;
            this.cbEnableSliderEmu.Text = "Enable Slider Emulation";
            this.cbEnableSliderEmu.UseVisualStyleBackColor = true;
            this.cbEnableSliderEmu.CheckedChanged += new System.EventHandler(this.cbEnableSliderEmu_CheckedChanged);
            // 
            // bTestACSlider
            // 
            this.bTestACSlider.Location = new System.Drawing.Point(146, 26);
            this.bTestACSlider.Name = "bTestACSlider";
            this.bTestACSlider.Size = new System.Drawing.Size(88, 23);
            this.bTestACSlider.TabIndex = 22;
            this.bTestACSlider.Text = "Test AC Slider";
            this.bTestACSlider.UseVisualStyleBackColor = true;
            this.bTestACSlider.Click += new System.EventHandler(this.bTestACSlider_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(240, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "LED Port";
            // 
            // cbLEDPort
            // 
            this.cbLEDPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLEDPort.FormattingEnabled = true;
            this.cbLEDPort.Location = new System.Drawing.Point(296, 26);
            this.cbLEDPort.Name = "cbLEDPort";
            this.cbLEDPort.Size = new System.Drawing.Size(121, 21);
            this.cbLEDPort.TabIndex = 24;
            this.cbLEDPort.SelectedIndexChanged += new System.EventHandler(this.cbLEDPort_SelectedIndexChanged);
            // 
            // cbAimeEmulation
            // 
            this.cbAimeEmulation.AutoSize = true;
            this.cbAimeEmulation.Location = new System.Drawing.Point(3, 55);
            this.cbAimeEmulation.Name = "cbAimeEmulation";
            this.cbAimeEmulation.Size = new System.Drawing.Size(172, 17);
            this.cbAimeEmulation.TabIndex = 25;
            this.cbAimeEmulation.Text = "Enable Aime Reader Emulation";
            this.cbAimeEmulation.UseVisualStyleBackColor = true;
            this.cbAimeEmulation.CheckedChanged += new System.EventHandler(this.cbAimeEmulation_CheckedChanged);
            // 
            // bTestAimeReader
            // 
            this.bTestAimeReader.Location = new System.Drawing.Point(181, 55);
            this.bTestAimeReader.Name = "bTestAimeReader";
            this.bTestAimeReader.Size = new System.Drawing.Size(88, 23);
            this.bTestAimeReader.TabIndex = 26;
            this.bTestAimeReader.Text = "Test Aime Reader";
            this.bTestAimeReader.UseVisualStyleBackColor = true;
            this.bTestAimeReader.Click += new System.EventHandler(this.bTestAimeReader_Click);
            // 
            // bLaunch
            // 
            this.bLaunch.Location = new System.Drawing.Point(3, 333);
            this.bLaunch.Name = "bLaunch";
            this.bLaunch.Size = new System.Drawing.Size(476, 44);
            this.bLaunch.TabIndex = 2;
            this.bLaunch.Text = "Launch";
            this.bLaunch.UseVisualStyleBackColor = true;
            this.bLaunch.Click += new System.EventHandler(this.bLaunch_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Batch Files|*.bat|All files| *.*";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 380);
            this.Controls.Add(this.flpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ChuniLaunch";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.flpMain.ResumeLayout(false);
            this.flpMain.PerformLayout();
            this.flpRemote.ResumeLayout(false);
            this.flpRemote.PerformLayout();
            this.flpLocal.ResumeLayout(false);
            this.flpLocal.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbRemoteProfile;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.RadioButton rbLocalProfile;
        private System.Windows.Forms.Button bLaunch;
        private System.Windows.Forms.TextBox tbBatchFile;
        private System.Windows.Forms.Button bCombinedOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbWindowedMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button bServerOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbChuni;
        private System.Windows.Forms.Button bChuniOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRemoteAddress;
        private System.Windows.Forms.TextBox tbLocalAddress;
        private System.Windows.Forms.FlowLayoutPanel flpRemote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRemoteFelica;
        private System.Windows.Forms.FlowLayoutPanel flpLocal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLocalFelica;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckBox cbEnableChunitachi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbEnableSliderEmu;
        private System.Windows.Forms.Button bTestACSlider;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbLEDPort;
        private System.Windows.Forms.CheckBox cbAimeEmulation;
        private System.Windows.Forms.Button bTestAimeReader;
        private System.Windows.Forms.Button bApplyServer;
        private System.Windows.Forms.CheckBox cbRemoteServ1;
        private System.Windows.Forms.CheckBox cbRemoteServ2;
    }
}

