namespace localhostUI
{
    partial class uiMain
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
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.currentEventsTab = new System.Windows.Forms.TabPage();
            this.eventsTabs = new System.Windows.Forms.TabControl();
            this.sportsTab = new System.Windows.Forms.TabPage();
            this.nearbyTab = new System.Windows.Forms.TabPage();
            this.soonTab = new System.Windows.Forms.TabPage();
            this.eventManagerTab = new System.Windows.Forms.TabPage();
            this.managerTabs = new System.Windows.Forms.TabControl();
            this.yourEventsTab = new System.Windows.Forms.TabPage();
            this.newEventTab = new System.Windows.Forms.TabPage();
            this.profileTab = new System.Windows.Forms.TabPage();
            this.menuTabs.SuspendLayout();
            this.currentEventsTab.SuspendLayout();
            this.eventsTabs.SuspendLayout();
            this.eventManagerTab.SuspendLayout();
            this.managerTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.currentEventsTab);
            this.menuTabs.Controls.Add(this.eventManagerTab);
            this.menuTabs.Controls.Add(this.profileTab);
            this.menuTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTabs.ItemSize = new System.Drawing.Size(266, 21);
            this.menuTabs.Location = new System.Drawing.Point(0, 0);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(800, 450);
            this.menuTabs.TabIndex = 0;
            // 
            // currentEventsTab
            // 
            this.currentEventsTab.Controls.Add(this.eventsTabs);
            this.currentEventsTab.Location = new System.Drawing.Point(4, 25);
            this.currentEventsTab.Name = "currentEventsTab";
            this.currentEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.currentEventsTab.Size = new System.Drawing.Size(792, 421);
            this.currentEventsTab.TabIndex = 0;
            this.currentEventsTab.Text = "Current events";
            this.currentEventsTab.UseVisualStyleBackColor = true;
            // 
            // eventsTabs
            // 
            this.eventsTabs.Controls.Add(this.sportsTab);
            this.eventsTabs.Controls.Add(this.nearbyTab);
            this.eventsTabs.Controls.Add(this.soonTab);
            this.eventsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventsTabs.Location = new System.Drawing.Point(3, 3);
            this.eventsTabs.Name = "eventsTabs";
            this.eventsTabs.SelectedIndex = 0;
            this.eventsTabs.Size = new System.Drawing.Size(786, 415);
            this.eventsTabs.TabIndex = 0;
            // 
            // sportsTab
            // 
            this.sportsTab.Location = new System.Drawing.Point(4, 25);
            this.sportsTab.Name = "sportsTab";
            this.sportsTab.Size = new System.Drawing.Size(778, 386);
            this.sportsTab.TabIndex = 0;
            this.sportsTab.Text = "Sports";
            this.sportsTab.UseVisualStyleBackColor = true;
            // 
            // nearbyTab
            // 
            this.nearbyTab.Location = new System.Drawing.Point(4, 25);
            this.nearbyTab.Name = "nearbyTab";
            this.nearbyTab.Padding = new System.Windows.Forms.Padding(3);
            this.nearbyTab.Size = new System.Drawing.Size(778, 386);
            this.nearbyTab.TabIndex = 1;
            this.nearbyTab.Text = "Near you";
            this.nearbyTab.UseVisualStyleBackColor = true;
            // 
            // soonTab
            // 
            this.soonTab.Location = new System.Drawing.Point(4, 25);
            this.soonTab.Name = "soonTab";
            this.soonTab.Padding = new System.Windows.Forms.Padding(3);
            this.soonTab.Size = new System.Drawing.Size(778, 386);
            this.soonTab.TabIndex = 2;
            this.soonTab.Text = "Happening soon";
            this.soonTab.UseVisualStyleBackColor = true;
            // 
            // eventManagerTab
            // 
            this.eventManagerTab.Controls.Add(this.managerTabs);
            this.eventManagerTab.Location = new System.Drawing.Point(4, 25);
            this.eventManagerTab.Name = "eventManagerTab";
            this.eventManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventManagerTab.Size = new System.Drawing.Size(792, 421);
            this.eventManagerTab.TabIndex = 1;
            this.eventManagerTab.Text = "Event manager";
            this.eventManagerTab.UseVisualStyleBackColor = true;
            // 
            // managerTabs
            // 
            this.managerTabs.Controls.Add(this.yourEventsTab);
            this.managerTabs.Controls.Add(this.newEventTab);
            this.managerTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerTabs.Location = new System.Drawing.Point(3, 3);
            this.managerTabs.Name = "managerTabs";
            this.managerTabs.SelectedIndex = 0;
            this.managerTabs.Size = new System.Drawing.Size(786, 415);
            this.managerTabs.TabIndex = 0;
            // 
            // yourEventsTab
            // 
            this.yourEventsTab.Location = new System.Drawing.Point(4, 25);
            this.yourEventsTab.Name = "yourEventsTab";
            this.yourEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.yourEventsTab.Size = new System.Drawing.Size(778, 386);
            this.yourEventsTab.TabIndex = 0;
            this.yourEventsTab.Text = "Manage your events";
            this.yourEventsTab.UseVisualStyleBackColor = true;
            // 
            // newEventTab
            // 
            this.newEventTab.Location = new System.Drawing.Point(4, 25);
            this.newEventTab.Name = "newEventTab";
            this.newEventTab.Padding = new System.Windows.Forms.Padding(3);
            this.newEventTab.Size = new System.Drawing.Size(778, 386);
            this.newEventTab.TabIndex = 1;
            this.newEventTab.Text = "Create a new event";
            this.newEventTab.UseVisualStyleBackColor = true;
            // 
            // profileTab
            // 
            this.profileTab.Location = new System.Drawing.Point(4, 25);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(3);
            this.profileTab.Size = new System.Drawing.Size(792, 421);
            this.profileTab.TabIndex = 2;
            this.profileTab.Text = "Profile settings";
            this.profileTab.UseVisualStyleBackColor = true;
            // 
            // uiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuTabs);
            this.Name = "uiMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainLoad);
            this.menuTabs.ResumeLayout(false);
            this.currentEventsTab.ResumeLayout(false);
            this.eventsTabs.ResumeLayout(false);
            this.eventManagerTab.ResumeLayout(false);
            this.managerTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl menuTabs;
        private System.Windows.Forms.TabPage currentEventsTab;
        private System.Windows.Forms.TabPage eventManagerTab;
        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.TabControl eventsTabs;
        private System.Windows.Forms.TabPage sportsTab;
        private System.Windows.Forms.TabPage nearbyTab;
        private System.Windows.Forms.TabPage soonTab;
        private System.Windows.Forms.TabControl managerTabs;
        private System.Windows.Forms.TabPage yourEventsTab;
        private System.Windows.Forms.TabPage newEventTab;
    }
}

