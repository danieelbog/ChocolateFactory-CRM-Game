using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class SimpleMilkChocolate : IChocolate
    {
        // Put constants here


        // Put Properties here
        public string ChocolateName { get; private set; }
        public double ChocolatePrice { get; set; }
        public int ChocolateID { get; private set; }
        public double RawMaterialsNeeded { get; private set; }

        // Put Constructors here
        public SimpleMilkChocolate()
        {
            ChocolateName = "Simple Milk Chocolate";
            ChocolatePrice = 2.00;
            ChocolateID = 3;
            RawMaterialsNeeded = 1.2;
        }

        // Put Methods Here
    }
}
