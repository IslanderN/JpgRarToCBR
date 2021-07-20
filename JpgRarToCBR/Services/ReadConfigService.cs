using JpgRarToCBR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace JpgRarToCBR.Services
{
    public static class ReadConfigService
    {
        private const string ConfigFileName = "appsettings.json";
        
        private readonly static string CurrentPath = Path.GetDirectoryName(typeof(ReadConfigService).Assembly.Location);

        public static Config ReadConfig(string filename = ConfigFileName)
        {
            string content = null;

            var fullPath = $"{CurrentPath}/{filename}";

            using (StreamReader sr = new StreamReader(File.OpenRead(fullPath)))
            {
                content = sr.ReadToEnd();
            }

            var config = JsonConvert.DeserializeObject<Config>(content);

            return config;
        }
    }
}
