using Common;
using Common.Formatting;
using localhostUI.Classes.UserInformationClasses;
using System.Collections.Generic;
using System.IO;


namespace localhostUI.Backend.DataManagement
{
    class UserDataReader : IDataReader
    {
        public void Read(out DataList data)
        {
            string userJson;
            List<object> dataList = null;
            try
            {
                if (Directory.Exists(UserDataManager.FileDirectory()))
                {
                    Directory.Delete(UserDataManager.FileDirectory());
                }
                Directory.CreateDirectory(UserDataManager.writeDirectory);
                userJson = File.ReadAllText(UserDataManager.FileDirectory());
                data = DataList.FromList(Json.ToList(userJson));
            }
            catch (FileNotFoundException e)
            {
                data = null;
                return;
            }
        }
    }
}


/*
 * public void Read(out DataList data)
        {
            string userJson;
            List<object> dataList = null;
            try
            {
                if (Directory.Exists(UserDataManager.FileDirectory()))
                {
                    Directory.Delete(UserDataManager.FileDirectory());
                }
                Directory.CreateDirectory(UserDataManager.writeDirectory);
                userJson = File.ReadAllText(UserDataManager.FileDirectory());
                dataList = JsonConvert.DeserializeObject<List<object>>(userJson);
                data = DataList.FromList(dataList);
            }
            catch (FileNotFoundException e)
            {
                data = null;
                return;
            }
        }*/