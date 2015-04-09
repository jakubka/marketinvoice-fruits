using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInvoiceFruits.Logic
{
    public class DeliveryStateMetadata
    {
        public DeliveryStates? NextDeliveryState { get; set; }

        public string FriendlyName { get; set; }

        public string ActionFriendlyName { get; set; }

        public string DirectoryName { get; set; }
    }

    public static class DeliveryStatesMetadataContainer
    {
        private static Dictionary<DeliveryStates, DeliveryStateMetadata> _metadata;

        static DeliveryStatesMetadataContainer()
        {
            _metadata = new Dictionary<DeliveryStates, DeliveryStateMetadata>();
            _metadata[DeliveryStates.JustPicked] = new DeliveryStateMetadata()
                {
                    NextDeliveryState = DeliveryStates.ArrivedAtClassificationCentre,
                    FriendlyName = "just picked",
                    ActionFriendlyName = "has just been picked",
                    DirectoryName = DeliveryStates.JustPicked.ToString(),
                };
            _metadata[DeliveryStates.ArrivedAtClassificationCentre] = new DeliveryStateMetadata()
                {
                    NextDeliveryState = DeliveryStates.EnrouteToMarket,
                    FriendlyName = "arrived at the classification centre",
                    ActionFriendlyName = "has just arrived at the classification center",
                    DirectoryName = DeliveryStates.ArrivedAtClassificationCentre.ToString(),
                };
            _metadata[DeliveryStates.EnrouteToMarket] = new DeliveryStateMetadata()
                {
                    NextDeliveryState = DeliveryStates.Delivered,
                    FriendlyName = "enrouted to market",
                    ActionFriendlyName = "has been enrouted to marked",
                    DirectoryName = DeliveryStates.EnrouteToMarket.ToString(),
                };
            _metadata[DeliveryStates.Delivered] = new DeliveryStateMetadata()
                {
                    NextDeliveryState = null,
                    FriendlyName = "delivered",
                    ActionFriendlyName = "has been delivered",
                    DirectoryName = DeliveryStates.Delivered.ToString(),
                };
            }


        public static DeliveryStateMetadata GetMetadata(DeliveryStates deliveryState)
{
    return _metadata[deliveryState];
}

    }
}
