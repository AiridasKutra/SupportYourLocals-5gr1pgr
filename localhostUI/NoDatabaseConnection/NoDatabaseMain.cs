using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace localhostUI.NoDatabaseConnection
{
    public partial class NoDatabaseMain : Form
    {
        public NoDatabaseMain()
        {
            InitializeComponent();
        }

        private void refresh(object sender, EventArgs e)
        {
            if(Program.ConnectToDb("193.219.91.103", 2776))
            {
                Program.ContinueOffline = true;
                Close();
            }
        }
    }
}
