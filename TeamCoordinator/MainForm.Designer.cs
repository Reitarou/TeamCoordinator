namespace TeamCoordinator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelStages = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelStages
            // 
            this.panelStages.BackColor = System.Drawing.SystemColors.Control;
            this.panelStages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStages.Location = new System.Drawing.Point(12, 12);
            this.panelStages.Name = "panelStages";
            this.panelStages.Size = new System.Drawing.Size(598, 820);
            this.panelStages.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 986);
            this.Controls.Add(this.panelStages);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStages;
    }
}

