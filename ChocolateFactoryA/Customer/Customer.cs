using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class Customer : ICustomer
    {
        public string C_userName { get; private set; }
        public string C_FirstName { get; private set; }
        public string C_LastName { get; private set; }
        private Wallet C_Wallet { get; set; }
        public List<IChocolate> C_ListOfChocolates { get; set; }

        public Customer(Random random)
        {
            // For Testing purposes this will generate the values randomly. This can change anytime
            C_userName = RandomGenerator.RND_UserNames(random);

            C_FirstName = RandomGenerator.RND_FirstName(random);

            C_LastName = RandomGenerator.RND_LastName(random);

            C_Wallet = new Wallet();

            C_ListOfChocolates = new List<IChocolate>();
        }
        public void C_MakeTransaction(Customer customer, double cost)
        {
            customer.C_Wallet.MakeTransaction(customer.C_Wallet, cost);
        }
    }
}
