using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    abstract class MilkChocolate : IChocolate
    {
        // Put constants here


        // Put Properties here
        public double RawMaterialsNeeded { get; private set; }
        public string ChocolateName { get; private set; }
        public double ChocolatePrice { get; set; }
        public int ChocolateID { get; private set; }

        // Put Constructors here


        // Put Methods Here
    }
}
