using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace Methods
{
    class FileSystemVisitor
    {
        private string Root { get; set; }
        static StringCollection log = new StringCollection();
        private ICollection<string> _dirs = new List<string>();
        //private Stack<string> _dirs = new Stack<string>();
        public FileSystemVisitor (string root)
        {
            if (!Directory.Exists(root)) throw new ArgumentException();
            else Root = root;
        }
        public void GetDirsFilesTree()
        {
            _dirs.Add(Root);
            while (_dirs.Count > 0)
            {
                string currentDir = _dirs.GetEnumerator().Current;
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
        public IEnumerable<string> PrintDirectoriesTree()
        {
            foreach (var curDir in _dirs)
            {
                yield return curDir.ToString();
            }
        }
    }
}
