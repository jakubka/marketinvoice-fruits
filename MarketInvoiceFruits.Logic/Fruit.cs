using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Logic
{
    public class Fruit
    {
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public decimal Price { get; set; }
        public DeliveryStates DeliveryState { get; set; }
    }

    public enum DeliveryStates
    {
        JustPicked = 1,
        ArrivedAtClassificationCentre = 2,
        EnrouteToMarket = 3,
        Delivered = 4
    }
}
