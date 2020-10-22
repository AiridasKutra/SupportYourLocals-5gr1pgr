using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    interface IDataReader
    {
        void Read(out DataList data);
    }
}
