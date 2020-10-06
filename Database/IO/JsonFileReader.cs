using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text;
using System.Text.Json;
using Common.Formatting;

namespace Database.IO
{
    class JsonFileReader : IDataReader
    {
        private string filename;

        public JsonFileReader(string filename)
        {
            this.filename = filename;
        }

        public void Read(out DataList list)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonStr = File.ReadAllText(filename);
            List<object> fullData = JsonSerializer.Deserialize<List<object>>(jsonStr, options);

            list = DataList.FromList(Json.DecodeList(fullData));
        }
    }
}
