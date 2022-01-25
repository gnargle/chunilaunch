
namespace ChuniLaunch {
    partial class AimeTestWindow {
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
            this.lbStatusText = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbStatusText
            // 
            this.lbStatusText.AutoSize = true;
            this.lbStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusText.ForeColor = System.Drawing.Color.DarkRed;
            this.lbStatusText.Location = new System.Drawing.Point(12, 9);
            this.lbStatusText.Name = "lbStatusText";
            this.lbStatusText.Size = new System.Drawing.Size(184, 26);
            this.lbStatusText.TabIndex = 0;
            this.lbStatusText.Text = "No Reader Found";
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(50, 47);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // AimeTestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 82);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lbStatusText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AimeTestWindow";
            this.Text = "Reader Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AimeTestWindow_FormClosing);
            this.Load += new System.EventHandler(this.AimeTestWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbStatusText;
        private System.Windows.Forms.Button bClose;
    }
}