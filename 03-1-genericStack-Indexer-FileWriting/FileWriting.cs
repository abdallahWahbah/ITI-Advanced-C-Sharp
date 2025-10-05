using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_1_genericStack_Indexer
{
    internal class FileWriting<T>: List<T>
    {
        private readonly string filePath;
        public FileWriting(string _filePath)
        {
            filePath = _filePath;
        }
        public new void Add(T item)
        {
            base.Add(item);
            File.AppendAllText(filePath, item.ToString() + Environment.NewLine);
        }
        public string RealAllLines()
        {
            string readText = File.ReadAllText(filePath);
            return readText;
        }
    }
}
