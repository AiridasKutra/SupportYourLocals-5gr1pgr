using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Common.Formatting;

namespace localhostUI.Backend.DataManagement
{
    class DraftFileReader : IDataReader
    {
        private readonly string fileName;
        private string message;
        public void Read(out DataList data)
        {
            try
            {
                string jsonstr = File.ReadAllText(fileName);
                data = DataList.FromList(Json.ToList(jsonstr));
            }
            catch (Exception e)
            {
                message = e.Message;
                data = null;
            }
        }
        public string GetMessage()
        {
            return message;
        }
        public DraftFileReader(string fileName)
        {
            this.fileName = fileName;
            
        }
        
    }
}
