using Common;
using Common.Formatting;
using localhostUI.Classes.UserInformationClasses;
using System;
using System.IO;
using System.Text.Json;

namespace localhostUI.Backend.DataManagement
{
    class UserDataWriter : IDataWriter
    {
        public void Write(DataList data)
        {
           /* try
            {
                if (Program.UserDataManager.UserData == null)
                {
                    DataList userList = Program.DataPool.userData;
                    Program.UserDataManager.UserData = new UserData((string)userList.Get("address"), (string)userList.Get("username"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Saving class failed.");
                throw e;
            }*/
            string jsonUser = Json.FromList(DataList.ToList(data));
            try
            {
                Directory.CreateDirectory(UserDataManager.writeDirectory);
                File.WriteAllText(UserDataManager.FileDirectory(), jsonUser);
            }
            catch(Exception e)
            {
                Console.WriteLine("USERDATAMANAGER" + e.Message);
            }
        }
    }
}
