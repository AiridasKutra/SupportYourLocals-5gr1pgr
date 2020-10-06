using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Database.IO
{
    interface IDataWriter
    {
        public void Write(DataList data);
    }
}
