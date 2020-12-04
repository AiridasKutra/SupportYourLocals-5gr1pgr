using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using Common.Validation;

namespace localhostUI
{
    public partial class LoginPanel : Form, IPanel
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

        public LoginPanel()
        {
            //this.caller = caller;
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs args)
        {
            if (emailTextBox.Text.Length == 0)
            {
                resultsLabel.Text = "• Invalid credentials";
                resultsLabel.Visible = true;
                return;
            }
            if (passwordTextBox.Text.Length == 0)
            {
                resultsLabel.Text = "• Invalid credentials";
                resultsLabel.Visible = true;
                return;
            }

            ulong vfid = Program.Client.Login(emailTextBox.Text, passwordTextBox.Text);
            if (vfid != 0)
            {
                Program.Client.SetVfid(vfid);
                mainForm.loggedIn = true;
                mainForm.ShowPanel(new MainEventListPanel(null));
                mainForm.DrawBanner();

                if (rememberCheckBox.Checked)
                {
                    Program.UserDataManager.UserData.SavedEmail = emailTextBox.Text;
                    Program.UserDataManager.UserData.SavedPassword = passwordTextBox.Text;
                    Program.UserDataManager.Save();
                }
                else
                {
                    Program.UserDataManager.UserData.SavedEmail = "";
                    Program.UserDataManager.UserData.SavedPassword = "";
                    Program.UserDataManager.Save();
                }
            }
            else
            {
                resultsLabel.Text = "• Invalid credentials";
                resultsLabel.Visible = true;
            }
        }
    }
}
