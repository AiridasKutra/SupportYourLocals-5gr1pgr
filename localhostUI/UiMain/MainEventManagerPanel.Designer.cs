namespace localhostUI
{
    partial class MainEventManagerPanel
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
            this.draftsPanel = new System.Windows.Forms.Panel();
            this.eventsPanel = new System.Windows.Forms.Panel();
            this.draftsLabel = new System.Windows.Forms.Label();
            this.myEventsLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.separatorPanel1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.separatorPanel1);
            this.mainPanel.Controls.Add(this.draftsPanel);
            this.mainPanel.Controls.Add(this.eventsPanel);
            this.mainPanel.Controls.Add(this.draftsLabel);
            this.mainPanel.Controls.Add(this.myEventsLabel);
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Location = new System.Drawing.Point(8, 9);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 800);
            this.mainPanel.TabIndex = 0;
            // 
            // draftsPanel
            // 
            this.draftsPanel.Location = new System.Drawing.Point(550, 180);
            this.draftsPanel.Name = "draftsPanel";
            this.draftsPanel.Size = new System.Drawing.Size(400, 400);
            this.draftsPanel.TabIndex = 3;
            // 
            // eventsPanel
            // 
            this.eventsPanel.Location = new System.Drawing.Point(50, 180);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(400, 400);
            this.eventsPanel.TabIndex = 2;
            // 
            // draftsLabel
            // 
            this.draftsLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.draftsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.draftsLabel.Location = new System.Drawing.Point(650, 120);
            this.draftsLabel.Name = "draftsLabel";
            this.draftsLabel.Size = new System.Drawing.Size(200, 30);
            this.draftsLabel.TabIndex = 1;
            this.draftsLabel.Text = "Drafts";
            this.draftsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myEventsLabel
            // 
            this.myEventsLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.myEventsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.myEventsLabel.Location = new System.Drawing.Point(150, 120);
            this.myEventsLabel.Name = "myEventsLabel";
            this.myEventsLabel.Size = new System.Drawing.Size(200, 30);
            this.myEventsLabel.TabIndex = 1;
            this.myEventsLabel.Text = "My events";
            this.myEventsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.Gray;
            this.titleLabel.Location = new System.Drawing.Point(350, 40);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(300, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Event manager";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separatorPanel1
            // 
            this.separatorPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separatorPanel1.Location = new System.Drawing.Point(125, 160);
            this.separatorPanel1.Name = "separatorPanel1";
            this.separatorPanel1.Size = new System.Drawing.Size(250, 1);
            this.separatorPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(625, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 1);
            this.panel1.TabIndex = 4;
            // 
            // MainEventManagerPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1018, 820);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainEventManagerPanel";
            this.Text = "MainEventManagerPanel";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label draftsLabel;
        private System.Windows.Forms.Label myEventsLabel;
        private System.Windows.Forms.Panel eventsPanel;
        private System.Windows.Forms.Panel draftsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel separatorPanel1;
    }
}