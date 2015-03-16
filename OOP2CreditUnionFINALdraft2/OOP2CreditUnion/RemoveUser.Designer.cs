namespace OOP2CreditUnion
{
    partial class RemoveUser
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cboUserNames = new System.Windows.Forms.ComboBox();
            this.lblSelectUser = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSubmit.Location = new System.Drawing.Point(57, 71);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 35);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "DELETE USER";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cboUserNames
            // 
            this.cboUserNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboUserNames.FormattingEnabled = true;
            this.cboUserNames.Location = new System.Drawing.Point(121, 26);
            this.cboUserNames.Name = "cboUserNames";
            this.cboUserNames.Size = new System.Drawing.Size(169, 24);
            this.cboUserNames.TabIndex = 1;
            // 
            // lblSelectUser
            // 
            this.lblSelectUser.AutoSize = true;
            this.lblSelectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSelectUser.Location = new System.Drawing.Point(14, 29);
            this.lblSelectUser.Name = "lblSelectUser";
            this.lblSelectUser.Size = new System.Drawing.Size(101, 16);
            this.lblSelectUser.TabIndex = 2;
            this.lblSelectUser.Text = "SELECT USER";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnCancel.Location = new System.Drawing.Point(176, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RemoveUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(302, 118);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSelectUser);
            this.Controls.Add(this.cboUserNames);
            this.Controls.Add(this.btnSubmit);
            this.Name = "RemoveUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DBSCU | Remove User";
            this.Load += new System.EventHandler(this.RemoveUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cboUserNames;
        private System.Windows.Forms.Label lblSelectUser;
        private System.Windows.Forms.Button btnCancel;
    }
}