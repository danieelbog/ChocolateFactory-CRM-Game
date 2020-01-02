using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class RawMaterialsOfferC : IRawMaterialsOffer
    {
        // Put const values here
        string qualityRating = "";

        // Price Tag represents the added value of the seller, as a seller i can offer whatever i like based on the economic circumstances at whatever price i like (Free Market Bitch)
        double priceTag = 0;

        // enter your currency here or your currency analogy
        int euros = 1;

        // Put Properties here

        public int ID { get; private set; } // i put it for now, when data base will connect this will not be needed
        public double QuantityKg { get; private set; }
        public double PricePerKg
        {
            get
            {
                return pricePerKg;
            }
            private set
            {
                value += priceTag * euros * QuantityKg * quality;
                pricePerKg = value;
            }
        }
        private double pricePerKg;
        public double Quality
        {
            get
            {
                return quality;
            }
            private set
            {
                if (qualityRating == "A")
                    value = 2;
                if (qualityRating == "B")
                    value = 1.6;
                if (qualityRating == "C")
                    value = 1.1;
                if (qualityRating == "F")
                    value = 1;
                quality = value;
            }
        }
        private double quality;

        // Put Constructors here
        public RawMaterialsOfferC(Random random)
        {
            // Create a randomizer so we can get different offers based on quality each time, this is a little bit of gamification thing
            qualityRating = RandomGenerator.RND_QualityRating(random);

            // Same principle for quantity (it can be changed later so user can iput his desired quantity, this is a little bit of gamification thing)
            // This is also something unique, because i think that the seller can tell you how much he has and wants to sell, so the factory must take it or leave it.


            // Same Principle for the Price
            priceTag = RandomGenerator.RND_PriceTag(random);

            Quality = 0;

            QuantityKg = RandomGenerator.RND_Quantity(random);

            PricePerKg = 0;

            ID = RandomGenerator.RND_ID(random);
        }

        // Put Methods here

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Offer ID: {this.ID}")
              .AppendLine($"Price: {this.pricePerKg:N0} Euros for")
              .AppendLine($"Quantity of Raw Materials: {this.QuantityKg:N0} kg")
              .AppendLine($"Quality: {this.qualityRating}");

            return sb.ToString();
        }
    }
}
