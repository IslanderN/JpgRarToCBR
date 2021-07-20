using JpgRarToCBR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace JpgRarToCBR.Services
{
    public static class FileConverter
    {

        public static string ConvertRarToCbr(string rarFilePath, string targetPath)
        {
            return Convert(rarFilePath, Consts.RarExtension, targetPath, Consts.CbrExtension);
        }
        public static string ConvertZipToCbr(string zipFilePath, string targetPath)
        {
            return Convert(zipFilePath, Consts.ZipExtension, targetPath, Consts.CbrExtension);
        }

        private static string Convert(string sourceFilePath, string sourceFileExtension, string targetPath, string targetExtension)
        {
            Console.WriteLine($"Try to copy {sourceFilePath} file to {targetPath} folder");
            ThrowIfHasNotExtension(sourceFilePath.ToString(), sourceFileExtension);
            CreateFolderIfNotExist(targetPath);

            var sourceFileName = Path.GetFileName(sourceFilePath);

            var targetFileName = sourceFileName.Replace(sourceFileExtension, targetExtension);

            var targetFilePath = Path.Combine(targetPath, targetFileName);

            Console.WriteLine($"Try to create {targetFilePath} file");

            File.Copy(sourceFilePath, targetFilePath);

            return targetFilePath;

        }

        private static void ThrowIfHasNotExtension(string filename, string extension)
        {
            if (!filename.Contains(extension))
            {
                throw new Exception($"File {filename} is not {extension}");
            }
        }

        private static void CreateFolderIfNotExist(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Console.WriteLine($"Folder {folder} isn't exists. Try to create");
                Directory.CreateDirectory(folder);
            }
        }
    }
}
