using localhostUI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class AccountsPanel : Form, IPanel
    {
        private UiMain mainForm;
        private IPanel caller;

        public void Reload() { }

        public Panel GetPanel()
        {
            return mainPanel;
        }

        public void SetMainRef(UiMain main)
        {
            mainForm = main;
        }

        public AccountsPanel()
        {
            InitializeComponent();
        }

        public void LoadAccounts()
        {
            List<UserAccount> accounts = new List<UserAccount>();


        }

        public void ShowAccount()
        {
            if (selectedAccount == null)
            {
                accountInfoPanel.Visible = false;
                return;
            }


        }

        private UserAccount selectedAccount = null;

        private void silenceButton_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            if (selectedAccount.Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                Program.Client.SilenceAccount(selectedAccount.Id);
            }
            else
            {
                Program.Client.UnsilenceAccount(selectedAccount.Id);
            }
        }

        private void banButton_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            if (selectedAccount.Can((uint)Permissions.BANNED))
            {
                Program.Client.UnbanAccount(selectedAccount.Id);
            }
            else
            {
                Program.Client.BanAccount(selectedAccount.Id);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            if (!confirmDeleteTextBox.Visible)
            {
                confirmDeleteTextBox.Visible = true;
            }
            else
            {
                if (confirmDeleteTextBox.Text == "delete")
                {
                    Program.Client.DeleteAccount(selectedAccount.Id);
                    confirmDeleteTextBox.Visible = false;
                }
            }
        }
    }
}
