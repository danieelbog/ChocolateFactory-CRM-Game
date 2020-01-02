using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class Wallet
    {
        // enter your currency here or your currency analogy
        int euros = 1;
        private double Money
        {
            set
            {
                value = value * euros;
                money = value;
            }
        }
        private double money;

        public Wallet()
        {
            Money = 5000;
        }

        public void MakeTransaction(Wallet wallet, double cost)
        {           
            if (cost >= 0)
            {
                this.money += cost;                
            }                
            else 
            {               
                if (this.money > -cost)
                {
                    this.money += cost;
                }
                else
                {                    
                    throw new CustomException("Not enough Funds!!!");
                }
            }               
        }

        public override string ToString()
        {
            return $"{this.money:N0}";
        }
    }
}
