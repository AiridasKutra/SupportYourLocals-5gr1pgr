namespace localhostUI.UserInformationForm
{
    partial class AppSettingsPanel
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
            this.autoLogInLabel = new System.Windows.Forms.Label();
            this.darkmodeLabel = new System.Windows.Forms.Label();
            this.darkModeCheckBox = new System.Windows.Forms.CheckBox();
            this.autoLogInCheckBox = new System.Windows.Forms.CheckBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.headerLabel);
            this.mainPanel.Controls.Add(this.autoLogInCheckBox);
            this.mainPanel.Controls.Add(this.darkModeCheckBox);
            this.mainPanel.Controls.Add(this.darkmodeLabel);
            this.mainPanel.Controls.Add(this.autoLogInLabel);
            this.mainPanel.Location = new System.Drawing.Point(42, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // autoLogInLabel
            // 
            this.autoLogInLabel.AutoSize = true;
            this.autoLogInLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autoLogInLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.autoLogInLabel.Location = new System.Drawing.Point(97, 78);
            this.autoLogInLabel.Name = "autoLogInLabel";
            this.autoLogInLabel.Size = new System.Drawing.Size(103, 23);
            this.autoLogInLabel.TabIndex = 0;
            this.autoLogInLabel.Text = "Auto log-in";
            // 
            // darkmodeLabel
            // 
            this.darkmodeLabel.AutoSize = true;
            this.darkmodeLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.darkmodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.darkmodeLabel.Location = new System.Drawing.Point(97, 131);
            this.darkmodeLabel.Name = "darkmodeLabel";
            this.darkmodeLabel.Size = new System.Drawing.Size(107, 23);
            this.darkmodeLabel.TabIndex = 1;
            this.darkmodeLabel.Text = "Dark mode";
            // 
            // darkModeCheckBox
            // 
            this.darkModeCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.darkModeCheckBox.Location = new System.Drawing.Point(256, 134);
            this.darkModeCheckBox.Name = "darkModeCheckBox";
            this.darkModeCheckBox.Size = new System.Drawing.Size(20, 24);
            this.darkModeCheckBox.TabIndex = 2;
            this.darkModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoLogInCheckBox
            // 
            this.autoLogInCheckBox.AutoSize = true;
            this.autoLogInCheckBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.autoLogInCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.autoLogInCheckBox.Location = new System.Drawing.Point(256, 82);
            this.autoLogInCheckBox.Name = "autoLogInCheckBox";
            this.autoLogInCheckBox.Size = new System.Drawing.Size(15, 14);
            this.autoLogInCheckBox.TabIndex = 3;
            this.autoLogInCheckBox.UseVisualStyleBackColor = true;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.headerLabel.Location = new System.Drawing.Point(302, 16);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(301, 39);
            this.headerLabel.TabIndex = 4;
            this.headerLabel.Text = "Application settings";
            // 
            // AppSettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 811);
            this.Controls.Add(this.mainPanel);
            this.Name = "AppSettingsPanel";
            this.Text = "localhost";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.CheckBox autoLogInCheckBox;
        private System.Windows.Forms.CheckBox darkModeCheckBox;
        private System.Windows.Forms.Label darkmodeLabel;
        private System.Windows.Forms.Label autoLogInLabel;
        private System.Windows.Forms.Label headerLabel;
    }
}