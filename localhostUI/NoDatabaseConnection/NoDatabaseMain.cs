using System;
using System.Windows.Forms;

namespace localhostUI.NoDatabaseConnection
{
    public partial class NoDatabaseMain : Form
    {
        public NoDatabaseMain()
        {
            InitializeComponent();
        }

        private void Refresh(object sender, EventArgs e)
        {
            if(Program.ConnectToDb("193.219.91.103", 2776))
            {
                
                Program.ContinueOffline = true;
                Close();
            }
        }
    }
}
