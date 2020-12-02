using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            ulong vfid = Program.Client.Login(emailTextBox.Text, passwordTextBox.Text);
            if (vfid != 0)
            {
                Program.Client.SetVfid(vfid);
                mainForm.loggedIn = true;
            }
            mainForm.ShowPanel(new MainEventListPanel(null));
            mainForm.DrawBanner();
        }
    }
}
