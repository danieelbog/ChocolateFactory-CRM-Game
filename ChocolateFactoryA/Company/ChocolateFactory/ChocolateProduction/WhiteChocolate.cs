using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class WhiteChocolate : IChocolate
    {
        // Put constants here


        // Put Properties here
        public double RawMaterialsNeeded { get; set; } 
        public string ChocolateName { get; private set; }
        public double ChocolatePrice { get; set; }
        public int ChocolateID { get; private set; }

        // Put Constructors here
        public WhiteChocolate()
        {
            RawMaterialsNeeded = 1.5;
            ChocolateName = "White Chocolate";
            ChocolatePrice = 2.2;
            ChocolateID = 2;
        }

        // Put Methods Here
    }
}
