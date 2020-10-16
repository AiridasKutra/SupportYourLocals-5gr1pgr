using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    class DatabaseReader : IDataReader
    {
        private string command;

        public DatabaseReader(string command)
        {
            this.command = command;
        }

        public void Read(out DataList data)
        {
            data = Program.Client.ExecuteCommand(command);
        }
    }
}
