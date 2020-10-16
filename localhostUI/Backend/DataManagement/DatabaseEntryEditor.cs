using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    class DatabaseEntryEditor : IDataWriter
    {
        private string tableName;

        public DatabaseEntryEditor(string tableName)
        {
            this.tableName = tableName;
        }

        public void Write(DataList data)
        {
            Program.Client.ModifyEntry(data, tableName, "");
        }
    }
}
