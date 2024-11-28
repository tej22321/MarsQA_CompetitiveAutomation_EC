using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.Data
{
    public class JsonReader
    {
        public static TestData ReadJsonFile(string path)
        {
            try
            {
                var jsonData = File.ReadAllText(path);
                var testData = JsonConvert.DeserializeObject<TestData>(jsonData);
                return testData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return null;
            }

        }
    }
}
