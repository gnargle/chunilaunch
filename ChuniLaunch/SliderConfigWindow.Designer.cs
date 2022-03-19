
namespace ChuniLaunch {
    partial class SliderConfigWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SliderConfigWindow));
            this.pIndicators = new System.Windows.Forms.Panel();
            this.bSave = new System.Windows.Forms.Button();
            this.lInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pIndicators
            // 
            this.pIndicators.Dock = System.Windows.Forms.DockStyle.Top;
            this.pIndicators.Location = new System.Drawing.Point(0, 0);
            this.pIndicators.Name = "pIndicators";
            this.pIndicators.Size = new System.Drawing.Size(720, 98);
            this.pIndicators.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bSave.Location = new System.Drawing.Point(12, 121);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(696, 34);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bDone_Click);
            this.bSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SliderConfigWindow_KeyDown);
            this.bSave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SliderConfigWindow_KeyUp);
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInfo.Location = new System.Drawing.Point(237, 101);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(246, 17);
            this.lInfo.TabIndex = 2;
            this.lInfo.Text = "Click each button to bind the key";
            // 
            // SliderConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 158);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.pIndicators);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SliderConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slider Key config";
            this.Load += new System.EventHandler(this.SliderConfigWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SliderConfigWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SliderConfigWindow_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pIndicators;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lInfo;
    }
}