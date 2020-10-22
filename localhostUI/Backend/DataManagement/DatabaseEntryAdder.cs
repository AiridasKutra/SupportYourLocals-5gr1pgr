using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    class DatabaseEntryAdder : IDataWriter
    {
        private string tableName;

        public DatabaseEntryAdder(string tableName)
        {
            this.tableName = tableName;
        }

        public void Write(DataList data)
        {
            Program.Client.AddEntry(data, tableName);
        }
    }
}
