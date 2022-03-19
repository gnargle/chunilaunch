
namespace ChuniLaunch {
    partial class AirConfigWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirConfigWindow));
            this.lInfo = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.pIndicators = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInfo.Location = new System.Drawing.Point(12, 52);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(246, 17);
            this.lInfo.TabIndex = 5;
            this.lInfo.Text = "Click each button to bind the key";
            // 
            // bSave
            // 
            this.bSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bSave.Location = new System.Drawing.Point(11, 72);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(247, 34);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            this.bSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirConfigWindow_KeyDown);
            this.bSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AirConfigWindow_KeyUp);
            // 
            // pIndicators
            // 
            this.pIndicators.Dock = System.Windows.Forms.DockStyle.Top;
            this.pIndicators.Location = new System.Drawing.Point(0, 0);
            this.pIndicators.Name = "pIndicators";
            this.pIndicators.Size = new System.Drawing.Size(270, 49);
            this.pIndicators.TabIndex = 3;
            // 
            // AirConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 110);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pIndicators);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AirConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Air Key Config";
            this.Load += new System.EventHandler(this.AirConfigWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AirConfigWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AirConfigWindow_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel pIndicators;
    }
}