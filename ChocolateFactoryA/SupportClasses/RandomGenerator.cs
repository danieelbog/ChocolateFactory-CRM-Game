using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class RandomGenerator : Random
    {
        public static string RND_SupplierName(Random random)
        {        
            // Random generation for Names Arrays
            string[] firstName = { "Alpaca.LTD", "Avalanch.LTD", "EA.LYD", "Ubisoft.Chocolate.LTD", "Activision.CEP", "Blizzard.NOR", "Akela.UBI", "Bandai.NAMCO", "SquareEnix.Eidos", "4A.LTD", "Matahari", "Cry.En", "Selios.FLD" };

            string Name = firstName[random.Next(0, firstName.Length)];

            return Name;
        }
        public static string RND_UserNames(Random random)
        {
            // Random generation for Names Arrays
            string[] userNamesArray = { "boardvitally", "judithchert", "houndnumber", "filthycartridge", "detailedbare", "wopsletap", "doilyclass", "musicignorant", "boxingcongolese", "4A.LTD", "trappinguniverse", "galileimarkham", "tugtheta" };

            string userName = userNamesArray[random.Next(0, userNamesArray.Length)];

            return userName;
        }

        public static string RND_FirstName(Random random)
        {
            // Random generation for Names Arrays
            string[] firstNamesArray = { "Daniel", "Nikos", "George", "Takis", "Maria", "Dimitra", "Aria", "Tereza", "Iwanna", "Volfkan", "Matahari", "Gregory", "John", "Argyris", "Periklis" };

            string firstName = firstNamesArray[random.Next(0, firstNamesArray.Length)];

            return firstName;
        }

        public static string RND_LastName(Random random)
        {
            // Random generation for Names Arrays
            string[] lastNamesArray = { "Johnson", "Trump", "McGregor", "Thompson", "Obama", "Clinton", "DevOps", "Wick", "Pagidas", "Aidinopoulos" };

            string lastName = lastNamesArray[random.Next(0, lastNamesArray.Length)];

            return lastName;
        }

        public static string RND_Subjects(Random random)
        {
            // Random generation for Names Arrays
            string[] subjectsArray = { "Math", "Physics", "Java", "C#.", "FrontEnd", "JavaScript", "Anguilar", "Cobolt", "Python", "C++", "HTML", "CSS" };

            string subject = subjectsArray[random.Next(0, subjectsArray.Length)];

            return subject;
        }

        public static string RND_QualityRating(Random random)
        {
            string[] randomQuality = { "A", "B", "C", "F" };

            string quality = randomQuality[random.Next(0, randomQuality.Length)];

            return quality;
        }

        public static double RND_Quantity(Random random)
        {
            double quantityKg = random.NextDouble() * (5000 - 100) + 100;

            return quantityKg;
        }

        public static double RND_PriceTag(Random random)
        {
            double priceTag = random.NextDouble() + 1;

            return priceTag;
        }

        public static int RND_ID(Random random)
        {
            int ID = random.Next(1,1001);

            return ID;
        }
    }
}
