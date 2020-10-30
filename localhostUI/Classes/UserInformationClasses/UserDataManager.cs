using Common;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;

namespace localhostUI.Classes.UserInformationClasses
{
    class UserDataManager
    {
        public UserData UserData { get; set; }
        private readonly string writeDirectory = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\localhostPSI";
        private readonly string fileName = "userInfo.json";
        public string FileDirectory()
        {
            return writeDirectory + @$"\{fileName}";
        }

        public UserDataManager()
        {
            this.Load();
        }

        public void LoadFromDataPool()
        {
            DataList userDataList = Program.DataPool.userData;
            this.UserData = new UserData((string)userDataList.Get("address"), (string)userDataList.Get("username"));
        }

        public void SaveToDataPool()
        {
            DataList userDataList = UserData.ToDataList(this.UserData);
            Program.DataPool.userData = userDataList;
        }

        public void Load()
        {
            //fix dis error pls
            string userJson;
            try
            {
                if (Directory.Exists(FileDirectory()))
                {
                    Directory.Delete(FileDirectory());
                }
                
                Directory.CreateDirectory(writeDirectory);
                userJson = File.ReadAllText(FileDirectory());
                Console.WriteLine(userJson);
                this.UserData = JsonConvert.DeserializeObject<UserData>(userJson);
                Program.DataPool.userData = UserData.ToDataList(this.UserData);
                Console.WriteLine(this.UserData.ToString());
            }
            catch(FileNotFoundException e)
            {
                return;
            }
            
        }

        public void Save()
        {
            try
            {
                if (UserData == null)
                {
                    DataList userList = Program.DataPool.userData;
                    UserData = new UserData((string)userList.Get("address"), (string)userList.Get("username"));
                }
            }catch(Exception e){
                Console.WriteLine("Saving class failed.");
                throw e;
            }
            string jsonUser = System.Text.Json.JsonSerializer.Serialize(UserData);
            try
            {
                Console.WriteLine(writeDirectory);
                Directory.CreateDirectory(writeDirectory);
                File.WriteAllText(FileDirectory(), jsonUser);
            }
            catch
            {
                ;
            }
            
        }
        public UserData GetData()
        {
            return UserData;
        }
    }
}
