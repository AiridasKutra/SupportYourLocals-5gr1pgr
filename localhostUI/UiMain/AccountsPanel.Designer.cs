namespace localhostUI
{
    partial class AccountsPanel
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
            this.confirmDeleteTextBox = new System.Windows.Forms.TextBox();
            this.accountInfoPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.banButton = new System.Windows.Forms.Button();
            this.silenceButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.normalCheckBox = new System.Windows.Forms.CheckBox();
            this.bannedCheckBox = new System.Windows.Forms.CheckBox();
            this.silencedCheckBox = new System.Windows.Forms.CheckBox();
            this.accountListPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.accountInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.confirmDeleteTextBox);
            this.mainPanel.Controls.Add(this.accountInfoPanel);
            this.mainPanel.Controls.Add(this.normalCheckBox);
            this.mainPanel.Controls.Add(this.bannedCheckBox);
            this.mainPanel.Controls.Add(this.silencedCheckBox);
            this.mainPanel.Controls.Add(this.accountListPanel);
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Location = new System.Drawing.Point(4, 4);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // confirmDeleteTextBox
            // 
            this.confirmDeleteTextBox.Location = new System.Drawing.Point(610, 216);
            this.confirmDeleteTextBox.Name = "confirmDeleteTextBox";
            this.confirmDeleteTextBox.PlaceholderText = "Enter the word \"delete\" and click again to confirm";
            this.confirmDeleteTextBox.Size = new System.Drawing.Size(350, 26);
            this.confirmDeleteTextBox.TabIndex = 7;
            // 
            // accountInfoPanel
            // 
            this.accountInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.accountInfoPanel.Controls.Add(this.deleteButton);
            this.accountInfoPanel.Controls.Add(this.banButton);
            this.accountInfoPanel.Controls.Add(this.silenceButton);
            this.accountInfoPanel.Controls.Add(this.usernameLabel);
            this.accountInfoPanel.Location = new System.Drawing.Point(610, 120);
            this.accountInfoPanel.Name = "accountInfoPanel";
            this.accountInfoPanel.Size = new System.Drawing.Size(350, 90);
            this.accountInfoPanel.TabIndex = 6;
            this.accountInfoPanel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.Tomato;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(240, 50);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 30);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            // 
            // banButton
            // 
            this.banButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.banButton.FlatAppearance.BorderSize = 0;
            this.banButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.banButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.banButton.ForeColor = System.Drawing.Color.White;
            this.banButton.Location = new System.Drawing.Point(125, 50);
            this.banButton.Name = "banButton";
            this.banButton.Size = new System.Drawing.Size(100, 30);
            this.banButton.TabIndex = 7;
            this.banButton.Text = "Ban";
            this.banButton.UseVisualStyleBackColor = false;
            // 
            // silenceButton
            // 
            this.silenceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.silenceButton.FlatAppearance.BorderSize = 0;
            this.silenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.silenceButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.silenceButton.ForeColor = System.Drawing.Color.White;
            this.silenceButton.Location = new System.Drawing.Point(10, 50);
            this.silenceButton.Name = "silenceButton";
            this.silenceButton.Size = new System.Drawing.Size(100, 30);
            this.silenceButton.TabIndex = 6;
            this.silenceButton.Text = "Silence";
            this.silenceButton.UseVisualStyleBackColor = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.usernameLabel.Location = new System.Drawing.Point(10, 10);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(330, 30);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "<username>";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // normalCheckBox
            // 
            this.normalCheckBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.normalCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.normalCheckBox.Location = new System.Drawing.Point(396, 192);
            this.normalCheckBox.Name = "normalCheckBox";
            this.normalCheckBox.Size = new System.Drawing.Size(200, 30);
            this.normalCheckBox.TabIndex = 4;
            this.normalCheckBox.Text = "Show normal";
            this.normalCheckBox.UseVisualStyleBackColor = true;
            // 
            // bannedCheckBox
            // 
            this.bannedCheckBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bannedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.bannedCheckBox.Location = new System.Drawing.Point(396, 156);
            this.bannedCheckBox.Name = "bannedCheckBox";
            this.bannedCheckBox.Size = new System.Drawing.Size(200, 30);
            this.bannedCheckBox.TabIndex = 3;
            this.bannedCheckBox.Text = "Show banned";
            this.bannedCheckBox.UseVisualStyleBackColor = true;
            // 
            // silencedCheckBox
            // 
            this.silencedCheckBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.silencedCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.silencedCheckBox.Location = new System.Drawing.Point(396, 120);
            this.silencedCheckBox.Name = "silencedCheckBox";
            this.silencedCheckBox.Size = new System.Drawing.Size(200, 30);
            this.silencedCheckBox.TabIndex = 2;
            this.silencedCheckBox.Text = "Show silenced";
            this.silencedCheckBox.UseVisualStyleBackColor = true;
            // 
            // accountListPanel
            // 
            this.accountListPanel.Location = new System.Drawing.Point(40, 120);
            this.accountListPanel.Name = "accountListPanel";
            this.accountListPanel.Size = new System.Drawing.Size(350, 200);
            this.accountListPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.Gray;
            this.titleLabel.Location = new System.Drawing.Point(300, 40);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(400, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Account manager";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountsPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1004, 561);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccountsPanel";
            this.Text = "AccountsPanel";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.accountInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel accountListPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.CheckBox normalCheckBox;
        private System.Windows.Forms.CheckBox bannedCheckBox;
        private System.Windows.Forms.CheckBox silencedCheckBox;
        private System.Windows.Forms.Panel accountInfoPanel;
        private System.Windows.Forms.Button banButton;
        private System.Windows.Forms.Button silenceButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox confirmDeleteTextBox;
    }
}