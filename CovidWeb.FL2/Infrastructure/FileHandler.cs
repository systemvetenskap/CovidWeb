using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CovidWeb.Infrastructure
{
    public static class FileHandler
    {
        public static T GetTestData<T>(string path)
        {
            string data = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }
    }
}
