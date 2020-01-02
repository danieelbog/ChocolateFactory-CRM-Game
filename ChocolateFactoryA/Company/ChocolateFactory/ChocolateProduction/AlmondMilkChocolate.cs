using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class AlmondMilkChocolate : IChocolate
    {
        // Put constants here


        // Put Properties here
        public string ChocolateName { get; private set; } 
        public double ChocolatePrice { get; set; } 
        public int ChocolateID { get; private set; } 
        public double RawMaterialsNeeded { get; private set; } 

        // Put Constructors here
        public AlmondMilkChocolate()
        {
            ChocolateName = "Almond Milk Chocolate";
            ChocolatePrice = 2.60;
            ChocolateID = 5;
            RawMaterialsNeeded = 2;
        }

        // Put Methods Here
    }
}
