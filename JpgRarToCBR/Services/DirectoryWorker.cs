using JpgRarToCBR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JpgRarToCBR.Services
{
    public class DirectoryWorker
    {
        public static IEnumerable<string> GetAllRarFiles(string rootFolder)
        {
            return GetAllFiles(rootFolder, $"*{Consts.RarExtension}");
        }


        public static IEnumerable<string> GetAllZipFiles(string rootFolder)
        {
            return GetAllFiles(rootFolder, $"*{Consts.ZipExtension}");
        }

        private static IEnumerable<string> GetAllFiles(string rootFolder, string searchRool)
        {
            var root = new DirectoryInfo(rootFolder);
            var files = GoThroughDirectories(searchRool, root);

            Console.WriteLine($"Total found {files.Count()} files in {rootFolder}");

            var filePaths = files.Select(f => f.FullName).ToList();
            return filePaths;

        }

        private static IEnumerable<FileInfo> GoThroughDirectories(string searchRool, DirectoryInfo directory, IEnumerable<FileInfo> files = null)
        {
            Console.WriteLine($"Search {searchRool} files in '{directory.FullName}' folder");

            var newFiles = directory.GetFiles(searchRool).AsEnumerable();

            Console.WriteLine($"Found {newFiles.Count()} files");

            if (files == null)
            {
                files = newFiles;
            }
            else
            {
                files = files.Union(newFiles).ToList();
            }

            foreach (var insideDirectory in directory.GetDirectories())
            {
                var insideFiles = GoThroughDirectories(searchRool, insideDirectory, files);
                files = files.Union(insideFiles).ToList();
            }

            return files;
        }
    }
}
