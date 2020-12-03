using localhostUI.Classes.EventClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class CreateReportPanel : Form, IPanel
    {
        private UiMain mainForm;
        private IPanel caller;
        private int eventId;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public CreateReportPanel(int eventId, IPanel caller)
        {
            this.caller = caller;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(caller);
        }

        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            backButton.BackgroundImage = Properties.Resources.BackButtonGreenHover;
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            backButton.BackgroundImage = Properties.Resources.BackButtonGreen;
        }

        private void createReport_Click(object sender, EventArgs e)
        {
            if (typeTextBox.Text.Length == 0)
            {
                typeTextBox.BackColor = Color.FromArgb(255, 200, 200);
                return;
            }

            Report report = new Report
            {
                EventId = eventId,
                Type = typeTextBox.Text,
                Comment = commentTextBox.Text
            };
            Program.Client.CreateReport(report);

            mainForm.ShowPanel(caller);
        }
    }
}
