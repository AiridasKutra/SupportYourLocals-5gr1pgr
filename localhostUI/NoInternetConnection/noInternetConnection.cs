using System;
using System.Windows.Forms;

namespace localhostUI.NoInternetConnection
{
    public partial class noInternetMain : Form
    {
        public noInternetMain()
        {
            InitializeComponent();
        }

        private void Refresh(object sender, EventArgs e)
        {
            if (Program.CheckForInternetConnection())
            {
                Program.ConnectionEstablished = true;
                Close();
            }
        }
    }
}
