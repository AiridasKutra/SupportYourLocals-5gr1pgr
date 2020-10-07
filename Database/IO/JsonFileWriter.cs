using Common;
using System.IO;
using System.Text.Json;

namespace Database.IO
{
    class JsonFileWriter : IDataWriter
    {
        private string filename;

        public JsonFileWriter(string filename)
        {
            this.filename = filename;
        }

        void IDataWriter.Write(DataList data)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string jsonStr = JsonSerializer.Serialize(DataList.ToList(data), options);
            File.WriteAllText(filename, jsonStr);
        }
    }
}
