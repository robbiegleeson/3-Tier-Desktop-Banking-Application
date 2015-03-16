namespace OOP2CreditUnion
{
    partial class OpenAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenAccount));
            this.lblCustmoer = new System.Windows.Forms.Label();
            this.lblCheckAccountType = new System.Windows.Forms.Label();
            this.lblValidateOverDraft = new System.Windows.Forms.Label();
            this.lblValidateBalance = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.txtOverdraftLimit = new System.Windows.Forms.TextBox();
            this.txtInitialBalance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInitialBalance = new System.Windows.Forms.Label();
            this.rdoSavings = new System.Windows.Forms.RadioButton();
            this.rdoCurrent = new System.Windows.Forms.RadioButton();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCustmoer
            // 
            this.lblCustmoer.AutoSize = true;
            this.lblCustmoer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustmoer.Location = new System.Drawing.Point(12, 9);
            this.lblCustmoer.Name = "lblCustmoer";
            this.lblCustmoer.Size = new System.Drawing.Size(65, 16);
            this.lblCustmoer.TabIndex = 0;
            this.lblCustmoer.Text = "Customer";
            // 
            // lblCheckAccountType
            // 
            this.lblCheckAccountType.AutoSize = true;
            this.lblCheckAccountType.ForeColor = System.Drawing.Color.Red;
            this.lblCheckAccountType.Location = new System.Drawing.Point(447, 57);
            this.lblCheckAccountType.Name = "lblCheckAccountType";
            this.lblCheckAccountType.Size = new System.Drawing.Size(10, 13);
            this.lblCheckAccountType.TabIndex = 47;
            this.lblCheckAccountType.Text = "!";
            this.lblCheckAccountType.Visible = false;
            // 
            // lblValidateOverDraft
            // 
            this.lblValidateOverDraft.AutoSize = true;
            this.lblValidateOverDraft.ForeColor = System.Drawing.Color.Red;
            this.lblValidateOverDraft.Location = new System.Drawing.Point(544, 91);
            this.lblValidateOverDraft.Name = "lblValidateOverDraft";
            this.lblValidateOverDraft.Size = new System.Drawing.Size(10, 13);
            this.lblValidateOverDraft.TabIndex = 46;
            this.lblValidateOverDraft.Text = "!";
            this.lblValidateOverDraft.Visible = false;
            // 
            // lblValidateBalance
            // 
            this.lblValidateBalance.AutoSize = true;
            this.lblValidateBalance.ForeColor = System.Drawing.Color.Red;
            this.lblValidateBalance.Location = new System.Drawing.Point(268, 91);
            this.lblValidateBalance.Name = "lblValidateBalance";
            this.lblValidateBalance.Size = new System.Drawing.Size(10, 13);
            this.lblValidateBalance.TabIndex = 45;
            this.lblValidateBalance.Text = "!";
            this.lblValidateBalance.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(168, 146);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(94, 29);
            this.btnBack.TabIndex = 44;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(15, 146);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(125, 29);
            this.btnAddAccount.TabIndex = 43;
            this.btnAddAccount.Text = "ADD ACCOUNT";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // txtOverdraftLimit
            // 
            this.txtOverdraftLimit.Location = new System.Drawing.Point(414, 88);
            this.txtOverdraftLimit.Name = "txtOverdraftLimit";
            this.txtOverdraftLimit.Size = new System.Drawing.Size(124, 20);
            this.txtOverdraftLimit.TabIndex = 42;
            // 
            // txtInitialBalance
            // 
            this.txtInitialBalance.Location = new System.Drawing.Point(138, 88);
            this.txtInitialBalance.Name = "txtInitialBalance";
            this.txtInitialBalance.Size = new System.Drawing.Size(124, 20);
            this.txtInitialBalance.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "OVERDRAFT LIMIT:";
            // 
            // lblInitialBalance
            // 
            this.lblInitialBalance.AutoSize = true;
            this.lblInitialBalance.Location = new System.Drawing.Point(12, 91);
            this.lblInitialBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitialBalance.Name = "lblInitialBalance";
            this.lblInitialBalance.Size = new System.Drawing.Size(99, 13);
            this.lblInitialBalance.TabIndex = 39;
            this.lblInitialBalance.Text = "INITIAL BALANCE:";
            // 
            // rdoSavings
            // 
            this.rdoSavings.AutoSize = true;
            this.rdoSavings.Location = new System.Drawing.Point(299, 55);
            this.rdoSavings.Name = "rdoSavings";
            this.rdoSavings.Size = new System.Drawing.Size(127, 17);
            this.rdoSavings.TabIndex = 38;
            this.rdoSavings.TabStop = true;
            this.rdoSavings.Text = "SAVINGS ACCOUNT";
            this.rdoSavings.UseVisualStyleBackColor = true;
            this.rdoSavings.CheckedChanged += new System.EventHandler(this.rdoSavings_CheckedChanged);
            // 
            // rdoCurrent
            // 
            this.rdoCurrent.AutoSize = true;
            this.rdoCurrent.Location = new System.Drawing.Point(138, 55);
            this.rdoCurrent.Name = "rdoCurrent";
            this.rdoCurrent.Size = new System.Drawing.Size(133, 17);
            this.rdoCurrent.TabIndex = 37;
            this.rdoCurrent.TabStop = true;
            this.rdoCurrent.Text = "CURRENT ACCOUNT";
            this.rdoCurrent.UseVisualStyleBackColor = true;
            this.rdoCurrent.CheckedChanged += new System.EventHandler(this.rdoCurrent_CheckedChanged);
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(12, 57);
            this.lblAccountType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(93, 13);
            this.lblAccountType.TabIndex = 36;
            this.lblAccountType.Text = "ACCOUNT TYPE:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(83, 8);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(124, 20);
            this.txtCustomerName.TabIndex = 48;
            // 
            // OpenAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(562, 197);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCheckAccountType);
            this.Controls.Add(this.lblValidateOverDraft);
            this.Controls.Add(this.lblValidateBalance);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.txtOverdraftLimit);
            this.Controls.Add(this.txtInitialBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInitialBalance);
            this.Controls.Add(this.rdoSavings);
            this.Controls.Add(this.rdoCurrent);
            this.Controls.Add(this.lblAccountType);
            this.Controls.Add(this.lblCustmoer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DBSCU | Open Account";
            this.Load += new System.EventHandler(this.OpenAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustmoer;
        private System.Windows.Forms.Label lblCheckAccountType;
        private System.Windows.Forms.Label lblValidateOverDraft;
        private System.Windows.Forms.Label lblValidateBalance;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.TextBox txtOverdraftLimit;
        private System.Windows.Forms.TextBox txtInitialBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInitialBalance;
        private System.Windows.Forms.RadioButton rdoSavings;
        private System.Windows.Forms.RadioButton rdoCurrent;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.TextBox txtCustomerName;
    }
}