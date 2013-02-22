using System;
using System.Collections.Generic;
using System.IO;

using System.Threading.Tasks;

namespace TreeSize
{
    internal class FileItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        private long Size { get; set; }
        private FileInfo FileInfo {get; set;}

        public FileItem(string fullName, string name)
        {
            if (File.Exists(fullName))
            {
                FullPath = fullName;
            }
            else
            { 
                throw new FileNotFoundException();
            }

            Name = name;
        }

        public long GetSize()
        {
            try
            {
                FileInfo info = GetFileInfo();
                return info.Length;
            }
            catch (FileNotFoundException)
            {
                return 0;
            }
        }

        private FileInfo GetFileInfo()
        {
            if (FileInfo == null)
            {
                FileInfo = new FileInfo(FullPath);
            }

            return FileInfo;
        }
    }
}
