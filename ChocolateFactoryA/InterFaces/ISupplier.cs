using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    interface ISupplier
    {
        // Put Properties here      
        List<IRawMaterialsOffer> ListOffer { get; set; }

    }
}
