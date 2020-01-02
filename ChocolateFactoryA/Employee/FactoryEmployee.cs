using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class FactoryEmployee : IEmployee
    {
        // Put constants here


        // Put Properties here
        public string E_FirstName { get; set; }
        public string E_LastName { get; set; }
        public double Salary { get; set; }

        // Put Constructors here
        public FactoryEmployee()
        {
            // Values need for Random generations
            Random random = new Random();            

            // Random generation for Names Arrays
            string[] firstName = { "Daniel", "Nikos", "George", "Takis", "Maria", "Dimitra", "Aria", "Tereza", "Iwanna", "Volfkan", "Matahari", "Gregory", "John" };
            string[] lastNames = { "Johnson", "Trump", "McGregor", "Thompson", "Obama", "Clinton", "DevOps", "Wick" };
           
            E_FirstName = firstName[random.Next(0, firstName.Length)];               
            E_LastName = lastNames[random.Next(0, lastNames.Length)];
            Salary = random.NextDouble();
            
        }

        // Put Methods Here
    }
}
