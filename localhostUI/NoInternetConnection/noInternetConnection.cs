using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
