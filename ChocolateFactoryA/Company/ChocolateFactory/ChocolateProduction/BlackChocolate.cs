using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class BlackChocolate : IChocolate
    {
        // Put constants here


        // Put Properties here
        public double RawMaterialsNeeded { get; private set; } 
        public string ChocolateName { get; private set; } 
        public double ChocolatePrice { get; set; } 
        public int ChocolateID { get; private set; } 

        // Put Constructors here
        public BlackChocolate()
        {
            ChocolateName = "Black Chocolate";
            ChocolatePrice = 1.89;
            ChocolateID = 1;
            RawMaterialsNeeded = 1;
        }

        // Put Methods Here
    }
}
