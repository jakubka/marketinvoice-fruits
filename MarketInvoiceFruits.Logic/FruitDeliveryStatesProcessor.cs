using MarketInvoiceFruits.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Logic
{
    public class FruitDeliveryStatesProcessor
    {
        public event Action<Fruit> FruitMovedToNextStep;

        public void MoveFruitsToNextDeliveryState(IFruitsReader fruitsReader, 
            IFruitWriter fruitWriter, 
            IFruitWriter processedFruitWriter,
            IFruitsDeleter fruitsDeleter
            )
        {
            var fruits = fruitsReader.ReadAllFruits();

            foreach (var fruit in fruits)
            {
                var nextDeliveryState = DeliveryStatesMetadataContainer.GetMetadata(fruit.DeliveryState).NextDeliveryState;

                if (nextDeliveryState == null)
                {
                    continue;
                }

                var newFruit = new Fruit
                {
                    Name = fruit.Name,
                    Price = fruit.Price,
                    Expiry = fruit.Expiry,
                    DeliveryState = nextDeliveryState.Value,
                };

                fruitWriter.WriteFruit(newFruit);
                processedFruitWriter.WriteFruit(fruit);

                fruitsDeleter.DeleteFruit(fruit);

                OnFruitMovedToNextStep(newFruit);
            }
        }

        private void OnFruitMovedToNextStep(Fruit fruit)
        {
            if (FruitMovedToNextStep != null)
            {
                FruitMovedToNextStep(fruit);
            }
        }
    }
}
