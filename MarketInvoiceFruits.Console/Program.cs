using MarketInvoiceFruits.Console;
using MarketInvoiceFruits.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseDirectory = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "StateTest");

            Func<Fruit, string> classicFruitPathFunc = f => Path.ChangeExtension(Path.Combine(DeliveryStatesMetadataContainer.GetMetadata(f.DeliveryState).DirectoryName, f.Name), "txt");
            Func<Fruit, string> processedFruitPathFunc = f => Path.ChangeExtension(Path.Combine(DeliveryStatesMetadataContainer.GetMetadata(f.DeliveryState).DirectoryName, "Processed", f.Name), "txt");

            var fruitsReader = new JsonFileSystemFruitsReader(baseDirectory);
            var fruitsWriter = new JsonFileSystemFruitWriter(baseDirectory, classicFruitPathFunc);
            var processedFruitsWriter = new JsonFileSystemFruitWriter(baseDirectory, processedFruitPathFunc);
            var fruitsDeleter = new FileSystemFruitsDeleter(baseDirectory, classicFruitPathFunc);

            var fruitStatesProcessor = new FruitDeliveryStatesProcessor();

            fruitStatesProcessor.FruitMovedToNextStep += f =>
                {
                    string actionFriendlyName = DeliveryStatesMetadataContainer.GetMetadata(f.DeliveryState).ActionFriendlyName;
                    System.Console.WriteLine(f.Name + " " + actionFriendlyName);
                };

            fruitStatesProcessor.MoveFruitsToNextDeliveryState(fruitsReader, fruitsWriter, processedFruitsWriter, fruitsDeleter);

            System.Console.WriteLine("All fruits moved to the next state. Press enter to exit...");
            System.Console.ReadLine();
        }
    }
}
