using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    interface IChocolate
    {
        // Put constants here


        // Put Properties here
        double RawMaterialsNeeded { get; }
        string ChocolateName { get; }
        double ChocolatePrice { get; }
        int ChocolateID { get; }

        // Put Methods Here
    }
}
