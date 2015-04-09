using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Logic
{
    public class JsonFileSystemFruitWriter : IFruitWriter
    {
        private readonly string _baseDirectory;
        private readonly Func<Fruit, string> _savePathFunc;

        public JsonFileSystemFruitWriter(string baseDirectory, Func<Fruit, string> savePathFunc)
        {
            _baseDirectory = baseDirectory;
            _savePathFunc = savePathFunc;
        }


        public void WriteFruit(Fruit fruit)
        {
            string completePath = Path.Combine(_baseDirectory, _savePathFunc(fruit));

            File.WriteAllText(completePath, JsonConvert.SerializeObject(fruit));
        }
    }
}
