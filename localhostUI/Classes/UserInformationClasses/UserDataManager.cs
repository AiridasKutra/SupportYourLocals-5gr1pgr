using Common;
using localhostUI.Backend.DataManagement;
using System;
using System.IO;

//READING FROM FILE
namespace localhostUI.Classes.UserInformationClasses
{
    class UserDataManager
    {
        public UserData UserData { get; set; }
        public static readonly string writeDirectory = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\localhostPSI";
        public static readonly string fileName = "userInfo.json";
       
        //JoinPath ždž padaryk
        public static string FileDirectory()
        {
            return writeDirectory + @$"\{fileName}";
        }

        public UserDataManager()
        {
            this.Load();
        }

        /*public void LoadFromDataPool()
        {
            DataList userDataList = Program.DataPool.userData;
            this.UserData = new UserData((string)userDataList.Get("address"), (string)userDataList.Get("username"));
        }

        public void SaveToDataPool()
        {
            DataList userDataList = UserData.ToDataList(this.UserData);
            Program.DataPool.userData = userDataList;
        }*/
        public void Load()
        {
            DataList userDataList;
            Program.DataManager.Read(new UserDataReader(), out userDataList);
            this.UserData = new UserData(userDataList); 
        }
        public void Save()
        {
            Program.DataManager.Write(new UserDataWriter(), UserData.ToDataList(this.UserData));
        }
        public UserData GetData()
        {
            return UserData;
        }
    }
}
