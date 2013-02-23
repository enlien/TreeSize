using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TreeSize
{
    internal class DirectoryItem
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        
        private List<DirectoryItem> Directories { get; set; }
        private List<FileItem> Files { get; set; }
        private long Size { get; set; }

        private DirectoryInfo CurrentDirectoryInfo { get; set; }

        public DirectoryItem(string fullPath, string name)
        {            
            if (Directory.Exists(fullPath))
            {
                FullPath = fullPath;
            }
            else
            {
                throw new DirectoryNotFoundException();
            }

            Name = name;
        }

        public override string ToString()
        {
            return FullPath;
        }

        public List<DirectoryItem> GetDirectories()
        {
            if (Directories != null)
            {
                return Directories;
            }

            Directories = new List<DirectoryItem>();

            try
            {
                DirectoryInfo info = GetDirectoryInfo();                
                DirectoryInfo[] directories = info.GetDirectories();
                AddDirectoriesToDirectoryList(directories);
            }
            catch (UnauthorizedAccessException)
            {
                return Directories;
            }                            

            return Directories;
        }

        public void Clear()
        {
            Directories = null;
            Files = null;
        }

        private void AddDirectoriesToDirectoryList(DirectoryInfo[] directories)
        {
            foreach (var directory in directories)
            {
                Directories.Add(new DirectoryItem(directory.FullName, directory.Name));
            }
        }

        public List<FileItem> GetFiles()
        {
            if (Files != null)
            {
                return Files;
            }

            Files = new List<FileItem>();
            try
            {
                FileInfo[] files = GetDirectoryInfo().GetFiles();
                AddFilesToFileList(files);
            }
            catch (UnauthorizedAccessException)
            {
                return Files;
            }            

            return Files;
        }

        private void AddFilesToFileList(FileInfo[] files)
        {
            foreach (var file in files)
            {
                try
                {
                    Files.Add(new FileItem(file.FullName, file.Name));
                }
                catch (FileNotFoundException)
                {
                    continue;
                }
                catch (PathTooLongException)
                {
                    continue;
                }
            }
        }

        private DirectoryInfo GetDirectoryInfo()
        {
            if (CurrentDirectoryInfo == null)
            {
                CurrentDirectoryInfo = new DirectoryInfo(FullPath);
            }
            return CurrentDirectoryInfo;
        }

        async public Task<long> GetSize()
        {      
            long result = await GetSizeOfFilesInDirectory();
            return result += await GetSizeOfFilesInSubDirectories();
        }        

        async private Task<long> GetSizeOfFilesInDirectory()
        {
            return await Task.Run(() =>
            {
                long result = 0;
                foreach (var file in GetFiles())
                {
                    result += file.GetSize();
                }
                return result;
            });
            
        }

        async private Task<long> GetSizeOfFilesInSubDirectories()
        {
            long result = 0;
            List<DirectoryItem> directories = GetDirectories();
            foreach (var directory in directories)
            {
                result += await directory.GetSize();
            }
            return result;
        }
    }
}