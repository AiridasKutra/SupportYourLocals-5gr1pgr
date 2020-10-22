using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    class DataManager
    {
        public DataManager()
        {

        }

        public void Read(IDataReader reader, out DataList data)
        {
            reader.Read(out data);
        }

        public void Write(IDataWriter writer, DataList data)
        {
            writer.Write(data);
        }
    }
}
