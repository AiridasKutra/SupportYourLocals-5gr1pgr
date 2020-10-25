using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    class DatabaseEntryRemover : IDataWriter
    {
        private string tableName;
        private int id;

        public DatabaseEntryRemover(string tableName, int id)
        {
            this.tableName = tableName;
            this.id = id;
        }

        public void Write(DataList data)
        {
            Program.Client.RemoveEntry(tableName, id);
        }
    }
}
