using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend.DataManagement
{
    interface IDataWriter
    {
        void Write(DataList data);
    }
}
