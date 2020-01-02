using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class SupplierB : ISupplier
    {
        // Put constants here
        private const int MinCharactersAllowed = 2;

        // Put Properties here
        private string S_Name
        {
            set
            {
                if (value.Length < MinCharactersAllowed)
                {
                    throw new CustomException($"The first name should be more than {MinCharactersAllowed} charachters");
                }
                if (!value.All(Char.IsLetterOrDigit))
                {
                    throw new CustomException($"The first name should contain only numbers or digits");
                }

                s_Name = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        private string s_Name;
        private Wallet S_Wallet { get; set; }
        public List<IRawMaterialsOffer> ListOffer { get; set; }

        // Put Constructors here
        public SupplierB(Random random)
        {
            s_Name = RandomGenerator.RND_SupplierName(random);

            ListOffer = new List<IRawMaterialsOffer>();

            S_Wallet = new Wallet();
        }

        // Put Methods Here
        public IRawMaterialsOffer GiveΟfferRawMaterials(ISupplier supplier, Random random)
        {
            try
            {
                IRawMaterialsOffer rawMaterialsOffer = new RawMaterialsOfferB(random);
                ListOffer.Add(rawMaterialsOffer);
                Console.WriteLine($"The Supplier: {this.s_Name} offers: ");
                Console.WriteLine(rawMaterialsOffer.ToString());

                return rawMaterialsOffer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GiveΟfferRawMaterials(supplier, random);
            }
        }
        public void S_MakeTransaction(SupplierB supplierB, double cost)
        {
            supplierB.S_Wallet.MakeTransaction(supplierB.S_Wallet, cost);
        }

    }
}
