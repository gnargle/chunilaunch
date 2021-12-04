
namespace ChuniLaunch {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rbRemoteProfile = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBatchFile = new System.Windows.Forms.TextBox();
            this.bCombinedOpen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.bServerOpen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbChuni = new System.Windows.Forms.TextBox();
            this.bChuniOpen = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRemoteAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRemoteFelica = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbLocalAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLocalFelica = new System.Windows.Forms.TextBox();
            this.rbLocalProfile = new System.Windows.Forms.RadioButton();
            this.cbWindowedMode = new System.Windows.Forms.CheckBox();
            this.bLaunch = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbRemoteProfile
            // 
            this.rbRemoteProfile.AutoSize = true;
            this.rbRemoteProfile.Location = new System.Drawing.Point(3, 196);
            this.rbRemoteProfile.Name = "rbRemoteProfile";
            this.rbRemoteProfile.Size = new System.Drawing.Size(96, 17);
            this.rbRemoteProfile.TabIndex = 0;
            this.rbRemoteProfile.TabStop = true;
            this.rbRemoteProfile.Text = "Remote Server";
            this.rbRemoteProfile.UseVisualStyleBackColor = true;
            this.rbRemoteProfile.CheckedChanged += new System.EventHandler(this.rbRemoteProfile_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.tbBatchFile);
            this.flowLayoutPanel1.Controls.Add(this.bCombinedOpen);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.tbServer);
            this.flowLayoutPanel1.Controls.Add(this.bServerOpen);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.tbChuni);
            this.flowLayoutPanel1.Controls.Add(this.bChuniOpen);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.rbRemoteProfile);
            this.flowLayoutPanel1.Controls.Add(this.rbLocalProfile);
            this.flowLayoutPanel1.Controls.Add(this.cbWindowedMode);
            this.flowLayoutPanel1.Controls.Add(this.bLaunch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(484, 267);
            this.flowLayoutPanel1.TabIndex = 1;
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.tbRemoteAddress);
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.tbRemoteFelica);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 90);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(234, 100);
            this.flowLayoutPanel2.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Remote Settings           ";
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
            this.tbRemoteAddress.TextChanged += new System.EventHandler(this.tbRemoteAddress_TextChanged);
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
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.label9);
            this.flowLayoutPanel3.Controls.Add(this.tbLocalAddress);
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.tbLocalFelica);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(243, 90);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(234, 100);
            this.flowLayoutPanel3.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Local Settings              ";
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
            this.tbLocalAddress.TextChanged += new System.EventHandler(this.tbLocalServer_TextChanged);
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
            // rbLocalProfile
            // 
            this.rbLocalProfile.AutoSize = true;
            this.rbLocalProfile.Location = new System.Drawing.Point(105, 196);
            this.rbLocalProfile.Name = "rbLocalProfile";
            this.rbLocalProfile.Size = new System.Drawing.Size(85, 17);
            this.rbLocalProfile.TabIndex = 1;
            this.rbLocalProfile.TabStop = true;
            this.rbLocalProfile.Text = "Local Server";
            this.rbLocalProfile.UseVisualStyleBackColor = true;
            this.rbLocalProfile.CheckedChanged += new System.EventHandler(this.rbLocalProfile_CheckedChanged);
            // 
            // cbWindowedMode
            // 
            this.cbWindowedMode.AutoSize = true;
            this.cbWindowedMode.Location = new System.Drawing.Point(196, 196);
            this.cbWindowedMode.Name = "cbWindowedMode";
            this.cbWindowedMode.Size = new System.Drawing.Size(107, 17);
            this.cbWindowedMode.TabIndex = 5;
            this.cbWindowedMode.Text = "Windowed Mode";
            this.cbWindowedMode.UseVisualStyleBackColor = true;
            this.cbWindowedMode.CheckedChanged += new System.EventHandler(this.cbWindowedMode_CheckedChanged);
            // 
            // bLaunch
            // 
            this.bLaunch.Location = new System.Drawing.Point(3, 219);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 267);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ChuniLaunch";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbRemoteProfile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRemoteFelica;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLocalFelica;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

