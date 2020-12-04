using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.Validation;

namespace localhostUI
{
    public partial class RegistrationPanel : Form, IPanel
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

        public RegistrationPanel()
        {
            InitializeComponent();
            resultLabel.Text = "";
        }

        private void registerButton_Click(object sender, EventArgs args)
        {
            string username = usernameTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;

            var resUsername = Validator.ValidateUsername(username);
            var resEmail = Validator.ValidateEmail(email);
            var resPassword = Validator.ValidatePassword(password);

            resultLabel.Text = "";

            usernameTextBox.BackColor = Color.White;
            emailTextBox.BackColor = Color.White;
            passwordTextBox.BackColor = Color.White;
            passwordRepeatTextBox.BackColor = Color.White;

            // Valid username
            if (!resUsername.isValid)
            {
                resultLabel.Text += $"• {resUsername.message}\n";
                usernameTextBox.BackColor = Color.FromArgb(255, 200, 200);
            }

            // Valid email
            if (!resEmail.isValid)
            {
                resultLabel.Text += $"• {resEmail.message}\n";
                emailTextBox.BackColor = Color.FromArgb(255, 200, 200);
            }

            // Valid password
            if (!resPassword.isValid)
            {
                resultLabel.Text += $"• {resPassword.message}\n";
                passwordTextBox.BackColor = Color.FromArgb(255, 200, 200);
            }

            // Passwords match
            if (passwordTextBox.Text != passwordRepeatTextBox.Text)
            {
                resultLabel.Text += $"• Passwords don't match\n";
                passwordRepeatTextBox.BackColor = Color.FromArgb(255, 200, 200);
            }

            if (resultLabel.Text == "")
            {
                string result = Program.Client.CreateAccount(username, email, password);
                if (result == "OK")
                {
                    mainForm.ShowPanel(new MainEventListPanel(null));
                    return;
                }

                resultLabel.Text += $"• {result}";
            }
        }
    }
}
