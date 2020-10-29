using Common;
using localhostUI.Classes.LocationClasses;
using localhostUI.Classes.UserInformationClasses;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace localhostUI.UserInformationForm
{
    public partial class UserInfoInputForm : Form
    {
        public UserInfoInputForm()
        {
            InitializeComponent();
        }

        private void UserInformationLoad(object sender, EventArgs e)
        {

        }

        private void Next(object sender, EventArgs e)
        {
            if(!LocationInformation.IsValidAddress(addressBox.Text) || (addressBox.Text.Length == 0 && adressCheckBox.Checked)|| usernameTextBox.Text.Length == 0)
            {
                if (!LocationInformation.IsValidAddress(addressBox.Text) || addressBox.Text.Length == 0)
                {
                    inputResultLabel.Text = "Invalid address";
                    addressBox.BackColor = Color.FromArgb(255, 128, 128);
                }
                else addressBox.BackColor = Color.White;
                if (usernameTextBox.Text.Length < 3)
                {
                    inputResultLabel.Text = "Username must be atleast 3 characters";
                    usernameTextBox.BackColor = Color.FromArgb(255, 128, 128);
                }
                else usernameTextBox.BackColor = Color.White;
                return;
            }

            UserData user;
            if(adressCheckBox.Checked) user = new UserData(addressBox.Text, usernameTextBox.Text);
                else user = new UserData(usernameTextBox.Text);
            DataList userData = UserData.ToDataList(user);
            Program.UserDataManager.UserData = user;
            Program.DataPool.userData = userData;
            Program.UserInfoNaturallyClosed = true;

            //If some bug occurs in saving related to this form try moving the following statement
            //to on close function.
            Program.UserDataManager.Save();
            this.Close();
        }

        private void CheckAddress(object sender, EventArgs e)
        {
            if (addressBox.Text.Length == 0) return;
            LocationInformation.OpenAdressInBrowser(addressBox.Text);
        }
    }
}
