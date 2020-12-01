namespace localhostUI
{
    partial class RegistrationPanel
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
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordRepeatTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.resultLabel);
            this.mainPanel.Controls.Add(this.registerButton);
            this.mainPanel.Controls.Add(this.passwordRepeatTextBox);
            this.mainPanel.Controls.Add(this.passwordTextBox);
            this.mainPanel.Controls.Add(this.usernameTextBox);
            this.mainPanel.Controls.Add(this.emailTextBox);
            this.mainPanel.Location = new System.Drawing.Point(8, 9);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(350, 250);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.PlaceholderText = "Email";
            this.emailTextBox.Size = new System.Drawing.Size(300, 25);
            this.emailTextBox.TabIndex = 0;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(350, 281);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PlaceholderText = "Username";
            this.usernameTextBox.Size = new System.Drawing.Size(300, 25);
            this.usernameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(350, 312);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.PlaceholderText = "Password";
            this.passwordTextBox.Size = new System.Drawing.Size(300, 25);
            this.passwordTextBox.TabIndex = 2;
            // 
            // passwordRepeatTextBox
            // 
            this.passwordRepeatTextBox.Location = new System.Drawing.Point(350, 343);
            this.passwordRepeatTextBox.Name = "passwordRepeatTextBox";
            this.passwordRepeatTextBox.PasswordChar = '*';
            this.passwordRepeatTextBox.PlaceholderText = "Repeat password";
            this.passwordRepeatTextBox.Size = new System.Drawing.Size(300, 25);
            this.passwordRepeatTextBox.TabIndex = 3;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(450, 374);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 35);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(350, 421);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(300, 66);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "Result";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegistrationPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1018, 820);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "RegistrationPanel";
            this.Text = "RegistrationPanel";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox passwordRepeatTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button registerButton;
    }
}