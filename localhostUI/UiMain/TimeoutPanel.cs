using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class TimeoutPanel : Form, IPanel
    {
        private UiMain mainForm;
        private Form caller;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public TimeoutPanel()
        {
            InitializeComponent();
            retryButton.Click += retryButton_Click;
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            mainForm.ShowPanel(new MainEventListPanel(null));
        }
    }
}
