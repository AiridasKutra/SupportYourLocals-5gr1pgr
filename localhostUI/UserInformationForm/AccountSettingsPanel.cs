using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class AccountSettingsPanel : Form, IPanel
    {
        private UiMain mainForm;
        private IPanel caller;

        public void Reload()
        {

        }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public AccountSettingsPanel()
        {
            InitializeComponent();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!deleteConfirmTextBox.Visible)
            {
                deleteConfirmTextBox.Visible = true;
            }
            else
            {
                if (deleteConfirmTextBox.Text == "delete")
                {
                    mainForm.logoutButton_Click(null, null);
                    mainForm.ShowPanel(new MainEventListPanel(null));
                }
                else
                {
                    deleteConfirmFailedLabel.Visible = true;
                }
            }
        }
    }
}
