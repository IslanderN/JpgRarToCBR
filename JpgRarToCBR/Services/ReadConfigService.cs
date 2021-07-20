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

        public static Config ReadConfig(string filename = ConfigFileName)
        {
            string content = null;
            using (StreamReader sr = new StreamReader(File.OpenRead(filename)))
            {
                content = sr.ReadToEnd();
            }

            var config = JsonConvert.DeserializeObject<Config>(content);

            return config;
        }
    }
}
