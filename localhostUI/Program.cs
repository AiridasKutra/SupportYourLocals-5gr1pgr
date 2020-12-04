using Common.Network;
using localhostUI.Backend;
using localhostUI.Backend.DataManagement;
using localhostUI.Classes.UserInformationClasses;
using localhostUI.NoDatabaseConnection;
using localhostUI.NoInternetConnection;
using localhostUI.UserInformationForm;
using System;
using System.Net;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace localhostUI
{
    static class Program
    {

        private static readonly ClientWrapper client = new ClientWrapper();
        public static ClientWrapper Client
        {
            get
            {
                return client;
            }
        }

        //private static readonly DataPool dataPool = new DataPool();
        //public static DataPool DataPool
        //{
        //    get
        //    {
        //        return dataPool;
        //    }
        //}

        private static readonly DataManager dataManager = new DataManager();
        public static DataManager DataManager
        {
            get
            {
                return dataManager;
            }
        }

        public static readonly EventDraftManager draftManager = new EventDraftManager();
        public static EventDraftManager DraftManager
        {
            get
            {
                return draftManager;
            }
        }

        public static UserDataManager UserDataManager { get;/*set;*/} = new UserDataManager();

        private static readonly EventDataProvider dataProvider = new EventDataProvider();
        public static EventDataProvider DataProvider
        {
            get
            {
                return dataProvider;
            }
        }

        public static bool ContinueOffline { get; set; } = false;
        public static bool ConnectionEstablished { get; set; } = false;

        public static bool UserInfoNaturallyClosed { get; set; }=false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //string ip = "193.219.91.103";
            //string ip = "doesntexist";
            //string ip = "127.0.0.1";
            //ushort port = 7099;
            //ushort port = 54000;

            string ip = ConfigurationManager.AppSettings.Get("IpAddress");
            ushort port = ushort.Parse(ConfigurationManager.AppSettings.Get("Port"));

            // Check if internet is available
            if (!CheckForInternetConnection())
            {
                Application.Run(new noInternetMain());
            }
            else
            {
                ConnectionEstablished = true;
            }

            if (!ConnectToDb(ip, port))
            {
                Application.Run(new NoDatabaseMain());
            }
            else
            {
                ContinueOffline = true;
            }

            if (ConnectionEstablished && ConnectionEstablished)
            {
                //Application.Run(new MainEventListPanel());
                //Application.Run(new MainEventManagerPanel());
                Application.Run(new UiMain());
            }
            
            Client.Disconnect();
            DraftManager.SaveDrafts();
        }

        
        public static bool ConnectToDb(string ip, ushort port)
        {
            return client.Connect(ip, port);
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
