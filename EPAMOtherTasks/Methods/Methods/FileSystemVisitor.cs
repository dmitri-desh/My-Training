using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Methods
{
    class FileSystemVisitor
    {
        private ICollection<string> _dirsFiles = new List<string>();
        public FileSystemVisitor(DirectoryInfo root)
        {
            _dirsFiles.Add(root.FullName);
            ExploreTree(root);
        }
        public FileSystemVisitor(DirectoryInfo root, Filter paramFilter)
        {
            _dirsFiles.Add(root.FullName);
          
        }
        private ICollection<FileInfo> GetFilesFiltered (DirectoryInfo root)
        {
            return root.GetFiles("*.*");
        }
        private ICollection<DirectoryInfo> GetDirsFiltered(DirectoryInfo root)
        {
            return root.GetDirectories("*");
        }
        private void ExploreTree(DirectoryInfo root)
        {
            ICollection<FileInfo> files = null;
            ICollection<DirectoryInfo> subDirs = null;
            try
            {
                files = GetFilesFiltered(root);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    _dirsFiles.Add(fi.FullName);
                }
                subDirs = GetDirsFiltered(root);
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                     _dirsFiles.Add(dirInfo.FullName);
                    ExploreTree(dirInfo);
                }
            }
        }
        public IEnumerable<string> GetTree()
        {
            foreach (var fd in _dirsFiles)
            {
                yield return fd;
            }
        }
    }
}
