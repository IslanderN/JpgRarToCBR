using JpgRarToCBR.Services;
using Newtonsoft.Json;
using System;
using System.IO;

namespace JpgRarToCBR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            var config = ReadConfigService.ReadConfig();

            var files = DirectoryWorker.GetAllRarFiles(config.SourceRootPath);
            foreach(var file in files)
            {
                FileConverter.ConvertRarToCbr(file, config.TargetPath);
            }


            var zipFiles = DirectoryWorker.GetAllZipFiles(config.SourceRootPath);
            foreach (var file in zipFiles)
            {
                FileConverter.ConvertZipToCbr(file, config.TargetPath);
            }
        }
    }
}
