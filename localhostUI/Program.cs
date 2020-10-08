using Common.Network;
using localhostUI.NoInternetConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace localhostUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly TCPClient client = new TCPClient();
        public static TCPClient Client
        {
            get
            {
                return client;
            }
        }
        [STAThread]

        
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string ip = "90.140.218.197";
            ushort port = 54000;
            */

            if (CheckForInternetConnection()// && ConnectToDb(ip, port)
                ) Application.Run(new uiMain());
            else
            {
                Application.Run(new noInternetMain());
            }
        }

        public static bool ConnectToDb(string ip, ushort port)
        {
            if (client.Connect(ip, port)) return true;
            return false;
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
