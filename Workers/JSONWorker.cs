using Newtonsoft.Json;
using Practice_JSON.Models;

namespace Practice_JSON.Workers
{
    public class JSONWorker(string filePath)
    {
        public string FilePath { get; init; } = filePath;

        public Data? ReadDataFromJson()
        {
            var json = File.ReadAllText(FilePath);
            var data = JsonConvert.DeserializeObject<Data>(json);

            return data;
        }

        public void SaveDataToJson(Data data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
