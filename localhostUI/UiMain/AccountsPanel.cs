using localhostUI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    public partial class AccountsPanel : Form, IPanel
    {
        private UiMain mainForm;
        private IPanel caller = null;

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
            LoadAccounts();
        }

        public void LoadAccounts()
        {
            List<UserAccount> accounts = Program.Client.SelectAccounts();

            // Filter selection
            if (!normalCheckBox.Checked)
            {
                accounts.RemoveAll(item => item.Can((uint)Permissions.SEND_CHAT_MESSAGES) && !item.Can((uint)Permissions.BANNED));
            }
            //if (!bannedCheckBox.Checked)
            //{
            //    accounts = accounts.Where(item => !item.Can((uint)Permissions.BANNED)).ToList();
            //}
            //if (!silencedCheckBox.Checked)
            //{
            //    accounts = accounts.Where(item => item.Can((uint)Permissions.SEND_CHAT_MESSAGES)).ToList();
            //}

            accountListPanel.Controls.Clear();

            int BUTTON_WIDTH = 350;
            int BUTTON_HEIGHT = 35;
            int MARGINS = 5;

            int counter = 0;
            foreach (var account in accounts)
            {
                Button selectAccountButton = new Button();
                selectAccountButton.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
                selectAccountButton.Location = new Point(0, (BUTTON_HEIGHT + MARGINS) * counter);
                selectAccountButton.Text = account.Username;
                selectAccountButton.TextAlign = ContentAlignment.MiddleLeft;
                selectAccountButton.Font = new Font("Arial", 12, FontStyle.Bold);
                selectAccountButton.FlatStyle = FlatStyle.Flat;
                selectAccountButton.FlatAppearance.BorderSize = 0;
                selectAccountButton.BackColor = Color.FromArgb(230, 230, 230);
                if (!account.Can((uint)Permissions.SEND_CHAT_MESSAGES))
                {
                    selectAccountButton.BackColor = Color.FromArgb(240, 200, 200);
                }
                if (account.Can((uint)Permissions.BANNED))
                {
                    selectAccountButton.BackColor = Color.FromArgb(255, 50, 50);
                }
                selectAccountButton.Click += (s, e) =>
                {
                    selectedAccount = account;
                    ShowAccount();
                };
                accountListPanel.Controls.Add(selectAccountButton);

                counter++;
            }
            accountListPanel.Size = new Size(accountListPanel.Size.Width, counter * (BUTTON_HEIGHT + MARGINS));

            mainPanel.Size = new Size(1000, Math.Max(500, accountListPanel.Location.Y + accountListPanel.Size.Height + 50));
        }

        public void ShowAccount()
        {
            if (selectedAccount == null)
            {
                accountInfoPanel.Visible = false;
                return;
            }

            accountInfoPanel.Visible = true;
            usernameLabel.Text = selectedAccount.Username;

            UserAccount user = Program.UserDataManager.UserAccount;
            if (!user.Can((uint)Permissions.SILENCE_ACCOUNTS))
            {
                silenceButton.Visible = false;
            }
            if (!user.Can((uint)Permissions.BAN_ACCOUNTS))
            {
                banButton.Visible = false;
            }
            if (!user.Can((uint)Permissions.DELETE_ACCOUNTS))
            {
                deleteButton.Visible = false;
            }

            if (selectedAccount.Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                silenceButton.Text = "Silence";
            }
            else
            {
                silenceButton.Text = "Unsilence";
            }

            if (!selectedAccount.Can((uint)Permissions.BANNED))
            {
                banButton.Text = "Ban";
            }
            else
            {
                banButton.Text = "Unban";
            }
        }

        private UserAccount selectedAccount = null;

        private void silenceButton_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            if (selectedAccount.Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                Program.Client.SilenceAccount(selectedAccount.Id);
                silenceButton.Text = "Unsilence";
            }
            else
            {
                Program.Client.UnsilenceAccount(selectedAccount.Id);
                silenceButton.Text = "Silence";
            }

            LoadAccounts();
            accountInfoPanel.Visible = false;
            mainForm.FitCurrentPanel();
        }

        private void banButton_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null) return;

            if (selectedAccount.Can((uint)Permissions.BANNED))
            {
                Program.Client.UnbanAccount(selectedAccount.Id);
                banButton.Text = "Unban";
            }
            else
            {
                Program.Client.BanAccount(selectedAccount.Id);
                banButton.Text = "Ban";
            }

            LoadAccounts();
            accountInfoPanel.Visible = false;
            mainForm.FitCurrentPanel();
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
                    accountInfoPanel.Visible = false;
                }
            }

            LoadAccounts();
            mainForm.FitCurrentPanel();
        }

        private void silencedCheckBox_Click(object sender, EventArgs e)
        {
            LoadAccounts();
            mainForm.FitCurrentPanel();
        }

        private void bannedCheckBox_Click(object sender, EventArgs e)
        {
            LoadAccounts();
            mainForm.FitCurrentPanel();
        }

        private void normalCheckBox_Click(object sender, EventArgs e)
        {
            LoadAccounts();
            mainForm.FitCurrentPanel();
        }
    }
}
