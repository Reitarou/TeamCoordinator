namespace TeamCoordinator
{
    partial class StageEditDlg
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
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbCall = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.listAvg = new System.Windows.Forms.ListBox();
            this.lbAvg = new System.Windows.Forms.Label();
            this.listAig = new System.Windows.Forms.ListBox();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tbCoach = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(84, 12);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(229, 20);
            this.tbNumber.TabIndex = 1;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(37, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(41, 13);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "Номер";
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(12, 67);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(66, 13);
            this.lbDescription.TabIndex = 3;
            this.lbDescription.Text = "Инструктор";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 304);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(238, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbCall
            // 
            this.lbCall.AutoSize = true;
            this.lbCall.Location = new System.Drawing.Point(21, 41);
            this.lbCall.Name = "lbCall";
            this.lbCall.Size = new System.Drawing.Size(57, 13);
            this.lbCall.TabIndex = 7;
            this.lbCall.Text = "Название";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(84, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(229, 20);
            this.tbName.TabIndex = 6;
            // 
            // listAvg
            // 
            this.listAvg.FormattingEnabled = true;
            this.listAvg.Location = new System.Drawing.Point(12, 109);
            this.listAvg.Name = "listAvg";
            this.listAvg.Size = new System.Drawing.Size(113, 186);
            this.listAvg.TabIndex = 8;
            // 
            // lbAvg
            // 
            this.lbAvg.AutoSize = true;
            this.lbAvg.Location = new System.Drawing.Point(12, 93);
            this.lbAvg.Name = "lbAvg";
            this.lbAvg.Size = new System.Drawing.Size(113, 13);
            this.lbAvg.TabIndex = 9;
            this.lbAvg.Text = "Допущенные группы";
            // 
            // listAig
            // 
            this.listAig.FormattingEnabled = true;
            this.listAig.Location = new System.Drawing.Point(200, 109);
            this.listAig.Name = "listAig";
            this.listAig.Size = new System.Drawing.Size(113, 186);
            this.listAig.TabIndex = 10;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(131, 109);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(63, 29);
            this.btnAddAll.TabIndex = 11;
            this.btnAddAll.Text = "| <<";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(131, 266);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(63, 29);
            this.btnRemoveAll.TabIndex = 12;
            this.btnRemoveAll.Text = ">> |";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(131, 144);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 29);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "<<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(131, 231);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(63, 29);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = ">>";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // tbCoach
            // 
            this.tbCoach.Location = new System.Drawing.Point(84, 64);
            this.tbCoach.Name = "tbCoach";
            this.tbCoach.Size = new System.Drawing.Size(229, 20);
            this.tbCoach.TabIndex = 15;
            // 
            // StageEditDlg
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(325, 339);
            this.Controls.Add(this.tbCoach);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.listAig);
            this.Controls.Add(this.lbAvg);
            this.Controls.Add(this.listAvg);
            this.Controls.Add(this.lbCall);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StageEditDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Редактор этапа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbCall;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ListBox listAvg;
        private System.Windows.Forms.Label lbAvg;
        private System.Windows.Forms.ListBox listAig;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox tbCoach;
    }
}