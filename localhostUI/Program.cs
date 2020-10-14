using Common.Network;
using localhostUI.NoDatabaseConnection;
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
        private static readonly ClientWrapper client = new ClientWrapper();
        public static ClientWrapper Client
        {
            get
            {
                return client;
            }
        }
        [STAThread]

        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //string ip = "193.219.91.103";
            string ip = "doesntexist";
            ushort port = 8485;

            // Check if internet is available
            if (!CheckForInternetConnection())
            {
                Application.Run(new noInternetMain());
            }
            else
            {
                // Check if connection to database exists
                if (!ConnectToDb(ip, port))
                {
                    Application.Run(new NoDatabaseMain());
                }
                Application.Run(new uiMain());
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
