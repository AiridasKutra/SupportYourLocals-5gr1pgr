namespace localhostUI.UserInformationForm
{
    partial class AccountSettingsPanel
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.passwordRepeatTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.deleteAccountLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.areYouSureButton = new System.Windows.Forms.Label();
            this.changeAddressButton = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.addressResultLabel = new System.Windows.Forms.Label();
            this.passwordResultLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.passwordResultLabel);
            this.mainPanel.Controls.Add(this.addressResultLabel);
            this.mainPanel.Controls.Add(this.changePasswordButton);
            this.mainPanel.Controls.Add(this.changeAddressButton);
            this.mainPanel.Controls.Add(this.areYouSureButton);
            this.mainPanel.Controls.Add(this.deleteButton);
            this.mainPanel.Controls.Add(this.textBox1);
            this.mainPanel.Controls.Add(this.passwordRepeatTextBox);
            this.mainPanel.Controls.Add(this.passwordTextBox);
            this.mainPanel.Controls.Add(this.deleteAccountLabel);
            this.mainPanel.Controls.Add(this.passwordLabel);
            this.mainPanel.Controls.Add(this.addressLabel);
            this.mainPanel.Controls.Add(this.headerLabel);
            this.mainPanel.Location = new System.Drawing.Point(45, 23);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // passwordRepeatTextBox
            // 
            this.passwordRepeatTextBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordRepeatTextBox.Location = new System.Drawing.Point(251, 243);
            this.passwordRepeatTextBox.Name = "passwordRepeatTextBox";
            this.passwordRepeatTextBox.PasswordChar = '*';
            this.passwordRepeatTextBox.Size = new System.Drawing.Size(401, 30);
            this.passwordRepeatTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.Location = new System.Drawing.Point(251, 203);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(401, 30);
            this.passwordTextBox.TabIndex = 4;
            // 
            // deleteAccountLabel
            // 
            this.deleteAccountLabel.AutoSize = true;
            this.deleteAccountLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteAccountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.deleteAccountLabel.Location = new System.Drawing.Point(50, 362);
            this.deleteAccountLabel.Name = "deleteAccountLabel";
            this.deleteAccountLabel.Size = new System.Drawing.Size(141, 23);
            this.deleteAccountLabel.TabIndex = 3;
            this.deleteAccountLabel.Text = "Delete account";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.passwordLabel.Location = new System.Drawing.Point(50, 210);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(169, 23);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Change password";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.addressLabel.Location = new System.Drawing.Point(50, 121);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(154, 23);
            this.addressLabel.TabIndex = 1;
            this.addressLabel.Text = "Change address";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.headerLabel.Location = new System.Drawing.Point(395, 29);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(211, 39);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "User settings";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(251, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 30);
            this.textBox1.TabIndex = 6;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Tomato;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(251, 358);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 35);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // areYouSureButton
            // 
            this.areYouSureButton.AutoSize = true;
            this.areYouSureButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.areYouSureButton.Location = new System.Drawing.Point(395, 366);
            this.areYouSureButton.Name = "areYouSureButton";
            this.areYouSureButton.Size = new System.Drawing.Size(116, 19);
            this.areYouSureButton.TabIndex = 8;
            this.areYouSureButton.Text = "Are you sure?";
            this.areYouSureButton.Visible = false;
            // 
            // changeAddressButton
            // 
            this.changeAddressButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.changeAddressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeAddressButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.changeAddressButton.ForeColor = System.Drawing.Color.White;
            this.changeAddressButton.Location = new System.Drawing.Point(251, 150);
            this.changeAddressButton.Name = "changeAddressButton";
            this.changeAddressButton.Size = new System.Drawing.Size(100, 35);
            this.changeAddressButton.TabIndex = 9;
            this.changeAddressButton.Text = "Change";
            this.changeAddressButton.UseVisualStyleBackColor = false;
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.changePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePasswordButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.changePasswordButton.ForeColor = System.Drawing.Color.White;
            this.changePasswordButton.Location = new System.Drawing.Point(251, 280);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(100, 35);
            this.changePasswordButton.TabIndex = 10;
            this.changePasswordButton.Text = "Change";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            // 
            // addressResultLabel
            // 
            this.addressResultLabel.AutoSize = true;
            this.addressResultLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addressResultLabel.Location = new System.Drawing.Point(371, 158);
            this.addressResultLabel.Name = "addressResultLabel";
            this.addressResultLabel.Size = new System.Drawing.Size(68, 19);
            this.addressResultLabel.TabIndex = 11;
            this.addressResultLabel.Text = "[Result]";
            this.addressResultLabel.Visible = false;
            // 
            // passwordResultLabel
            // 
            this.passwordResultLabel.AutoSize = true;
            this.passwordResultLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordResultLabel.Location = new System.Drawing.Point(371, 288);
            this.passwordResultLabel.Name = "passwordResultLabel";
            this.passwordResultLabel.Size = new System.Drawing.Size(68, 19);
            this.passwordResultLabel.TabIndex = 11;
            this.passwordResultLabel.Text = "[Result]";
            this.passwordResultLabel.Visible = false;
            // 
            // AccountSettingsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1084, 811);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "AccountSettingsPanel";
            this.Text = "localhost";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label deleteAccountLabel;
        private System.Windows.Forms.TextBox passwordRepeatTextBox;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.Button changeAddressButton;
        private System.Windows.Forms.Label areYouSureButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label passwordResultLabel;
        private System.Windows.Forms.Label addressResultLabel;
    }
}