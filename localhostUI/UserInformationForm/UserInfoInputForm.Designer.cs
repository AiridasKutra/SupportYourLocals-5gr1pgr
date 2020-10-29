namespace localhostUI.UserInformationForm
{
    partial class UserInfoInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoInputForm));
            this.formHeader = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.adressLabel = new System.Windows.Forms.Label();
            this.adressCheckBox = new System.Windows.Forms.CheckBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inputResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // formHeader
            // 
            this.formHeader.AutoSize = true;
            this.formHeader.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.formHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.formHeader.Location = new System.Drawing.Point(50, 26);
            this.formHeader.Name = "formHeader";
            this.formHeader.Size = new System.Drawing.Size(692, 65);
            this.formHeader.TabIndex = 0;
            this.formHeader.Text = "Please input your information";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(51, 122);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(78, 20);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username:";
            // 
            // adressLabel
            // 
            this.adressLabel.AutoSize = true;
            this.adressLabel.Location = new System.Drawing.Point(72, 160);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(56, 20);
            this.adressLabel.TabIndex = 2;
            this.adressLabel.Text = "Adress:";
            // 
            // adressCheckBox
            // 
            this.adressCheckBox.AutoSize = true;
            this.adressCheckBox.Checked = true;
            this.adressCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.adressCheckBox.Location = new System.Drawing.Point(50, 163);
            this.adressCheckBox.Name = "adressCheckBox";
            this.adressCheckBox.Size = new System.Drawing.Size(18, 17);
            this.adressCheckBox.TabIndex = 3;
            this.adressCheckBox.UseVisualStyleBackColor = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(135, 119);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PlaceholderText = "BelovedUser";
            this.usernameTextBox.Size = new System.Drawing.Size(607, 27);
            this.usernameTextBox.TabIndex = 4;
            this.usernameTextBox.Text = "penisLover420";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(135, 157);
            this.addressBox.Name = "addressBox";
            this.addressBox.PlaceholderText = "Gedimino pr. 69";
            this.addressBox.Size = new System.Drawing.Size(572, 27);
            this.addressBox.TabIndex = 4;
            this.addressBox.Text = "Didlaukio g. 59";
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextButton.Location = new System.Drawing.Point(346, 200);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(94, 42);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.Next);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(713, 157);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 27);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CheckAddress);
            // 
            // inputResultLabel
            // 
            this.inputResultLabel.AutoSize = true;
            this.inputResultLabel.Location = new System.Drawing.Point(51, 200);
            this.inputResultLabel.Name = "inputResultLabel";
            this.inputResultLabel.Size = new System.Drawing.Size(0, 20);
            this.inputResultLabel.TabIndex = 16;
            // 
            // UserInfoInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 273);
            this.Controls.Add(this.inputResultLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.adressCheckBox);
            this.Controls.Add(this.adressLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.formHeader);
            this.Name = "UserInfoInputForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UserInformationLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label adressLabel;
        private System.Windows.Forms.CheckBox adressCheckBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label inputResultLabel;
    }
}