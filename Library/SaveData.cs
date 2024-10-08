using Newtonsoft.Json;
using System.IO;

namespace Library
{
    static class SaveData<T> where T : People
    {

        private static string filePath = "person.json";
        public static void SaveJSONFile(T persons)
        {
            var file = JsonConvert.SerializeObject(persons);
            File.WriteAllText(filePath, file);
        }
    }
}
