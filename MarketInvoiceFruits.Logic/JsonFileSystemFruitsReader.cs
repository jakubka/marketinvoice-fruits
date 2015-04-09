using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Logic
{
    public class JsonFileSystemFruitsReader : IFruitsReader
    {
        private readonly string _basePath;

        public JsonFileSystemFruitsReader(string basePath)
        {
            _basePath = basePath;
        }

        public IEnumerable<Fruit> ReadAllFruits()
        {
            var filePaths = new List<string>();

            foreach (var directory in Directory.GetDirectories(_basePath))
            {
                filePaths.AddRange(Directory.GetFiles(directory, "*.txt"));
            }

            return filePaths.Select(File.ReadAllText).Select(JsonConvert.DeserializeObject<Fruit>);
        }
    }
}
