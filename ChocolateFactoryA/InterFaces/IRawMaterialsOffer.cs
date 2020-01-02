using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    interface IRawMaterialsOffer
    {

        int ID { get; }
        double QuantityKg { get; }
        double PricePerKg { get; }
        double Quality { get; }        

    }
}
