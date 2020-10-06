using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Database.IO
{
    interface IDataReader
    {
        public void Read(out DataList list);
    }
}
