using Common.Validation;
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
            addressTextBox.Text = Program.UserDataManager.UserData.Address;
        }

        private void changeAddressButton_Click(object sender, EventArgs e)
        {
            addressResultLabel.Visible = true;
            if (addressTextBox.Text == "" || addressTextBox.Text == null)
            {
                Program.UserDataManager.UserData.Address = "";
                addressResultLabel.Text = "Your address information has been deleted.";
                return;
            }
            if (addressTextBox.Text == Program.UserDataManager.UserData.Address)
            {
                addressResultLabel.Text = "This is already your address.";
                addressResultLabel.ForeColor = Color.Black;
                return;
            }

            //Bug here, after changing it to an invalid address, and then changing it to a valid one, the line still reads invalid.
            if (Program.UserDataManager.UserData.ChangeAddress(addressTextBox.Text))
            {
                addressResultLabel.Text = "Address has been accepted.";
                addressResultLabel.ForeColor = Color.Black;
                addressTextBox.Text = Program.UserDataManager.UserData.Address;
                Program.UserDataManager.Save();
            }
            else
            {
                addressResultLabel.Text = "Address is invalid.";
                addressResultLabel.ForeColor = Color.FromArgb(255, 128, 128);
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            passwordResultLabel.Visible = true;
            if (!Validator.ValidatePassword(passwordTextBox.Text).isValid)
            {
                passwordResultLabel.Text = "Invalid password";
                return;
            }
            if (passwordRepeatTextBox.Text != passwordTextBox.Text)
            {
                passwordResultLabel.Text = "Passwords don't match";
                return;
            }

            Program.Client.SetAccountPassword(Program.UserDataManager.UserAccount.Id, passwordTextBox.Text);
            passwordResultLabel.Text = "Change successful";
            return;
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
                    Program.Client.DeleteAccount(Program.UserDataManager.UserAccount.Id);
                    mainForm.logoutButton_Click(null, null);
                }
                else
                {
                    deleteConfirmFailedLabel.Visible = true;
                }
            }
        }
    }
}
