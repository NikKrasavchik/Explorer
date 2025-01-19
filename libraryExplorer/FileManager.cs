// FileManager.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace libraryExplorer
{
    public class FileManager
    {
        public List<string> GetDirectoryContents(string path)
        {
            List<string> items = new List<string>();
            try
            {
                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                items.AddRange(directories);
                items.AddRange(files);
            }
            catch (Exception ex)
            {
                // Обработка исключений
                Console.WriteLine(ex.Message);
            }
            return items;
        }
    }
}