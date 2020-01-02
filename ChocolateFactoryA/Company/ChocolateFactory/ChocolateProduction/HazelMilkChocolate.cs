using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class HazelMilkChocolate : IChocolate
    {
        // Put constants here


        // Put Properties here
        public string ChocolateName { get; private set; } 
        public double ChocolatePrice { get; set; } 
        public int ChocolateID { get; private set; } 
        public double RawMaterialsNeeded { get; private set; }

        // Put Constructors here
        public HazelMilkChocolate()
        {
            ChocolateName = "Hazel Milk Chocolate";
            ChocolatePrice = 2.50;
            ChocolateID = 4;
            RawMaterialsNeeded = 1.5;
        }

        // Put Methods Here
    }
}
