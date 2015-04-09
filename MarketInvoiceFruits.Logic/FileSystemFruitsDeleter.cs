using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Logic
{
    public class FileSystemFruitsDeleter : IFruitsDeleter
    {
        private readonly string _baseDirectory;
        private readonly Func<Fruit, string> _pathFunc;

        public FileSystemFruitsDeleter(string baseDirectory, Func<Fruit, string> pathFunc)
        {
            _baseDirectory = baseDirectory;
            _pathFunc = pathFunc;
        }

        public void DeleteFruit(Fruit fruit)
        {
            string completePath = Path.Combine(_baseDirectory, _pathFunc(fruit));

            File.Delete(completePath);
        }
    }
}
