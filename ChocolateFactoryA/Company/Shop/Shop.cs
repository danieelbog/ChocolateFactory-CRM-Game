using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class Shop
    {
        // Put constants here
        const int maxStorageCapacity = 2000;
        const int maxShelfCapacity = 250;
        // the following Values sum should always be 1!!!
        const double factoryPercentegeCut = 0.8;
        const double shopPercentageCut = 0.2;


        // Put Properties here

        public string Shop_Name { get; set; }
        public string Shop_Address { get; set; }
        private double Shop_RunningCosts { get; set; }
        private Wallet S_Wallet { get; set; }
        private List<IChocolate> StorageCapacity { get; set; }
        private List<IChocolate> ShelfCapacity { get; set; }        
        private List<IEmployee> ShopEmployees { get; set; }        

        // Put Constructors here

        public Shop(string shopName, string shopAddress)
        {
            Shop_Name = shopName;
            Shop_Address = shopAddress;
            StorageCapacity = new List<IChocolate>();
            ShelfCapacity = new List<IChocolate>();
            ShopEmployees = new List<IEmployee>();
            S_Wallet = new Wallet();


            // Dummy Fake Employees in the shop (WARNING, THEY DONT BELONG HERE!!!!)
            IEmployee employee1 = new ShopEmployee();
            ShopEmployees.Add(employee1);
            IEmployee employee2 = new ShopEmployee();
            ShopEmployees.Add(employee2);
            IEmployee employee3 = new ShopEmployee();
            ShopEmployees.Add(employee3);
        }

        //Put Methods Here

        // User must choose from which factory he wants to transfer the chocolate (When there will be two factories, in Main there will be a switch to do that)
        // User must choose to which shop he wants to transfer the chocolate (When there will be two shops, in Main there will be a switch to do that)
        // Same principle design as the below Methods
        public void TransferChocolatesToTheShop(Factory factory, Shop shop)
        {
            // General Values for Use
            string choice = "";            
            int quantityTotransfer = 0;
            int chocolateCounter = 0;

            // Choose the chocolate that you want to transfer to the shop
            try
            {
                // User will pick what chocolate he wants to Transfer
                Console.WriteLine("Choose the Chocolate you want to tansfer to the shop");
                Console.WriteLine("1) Black Chocolate");
                Console.WriteLine("2) White Chocolate");
                Console.WriteLine("3) Simple Milk Chocolate");
                Console.WriteLine("4) Hazel Milk Chocolate");
                Console.WriteLine("5) Almond Milk Chocolate");
                choice = Console.ReadLine();

                // Here the user will choose how many chocolate he would like to Transfer
                Console.WriteLine("Chose the quantity you want to transfer:");
                Console.WriteLine("1) 1 Chocolate Bar:");
                Console.WriteLine("2) 10 Chocolate Bar:");
                Console.WriteLine("3) 50 Chocolate Bar:");
                Console.WriteLine("4) Give the quantity you want:");
                quantityTotransfer = int.Parse(Console.ReadLine());

                // Quantities to transfer based on user input
                switch (quantityTotransfer)
                {
                    case 1:
                        quantityTotransfer = 1;
                        break;

                    case 2:
                        quantityTotransfer = 10;
                        break;
                    case 3:
                        quantityTotransfer = 50;
                        break;
                    case 4:
                        quantityTotransfer = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Give the quantity you would like to transfer:");
                        quantityTotransfer = int.Parse(Console.ReadLine());
                        break;
                }

                // Transfering chocolates from the factory to the shop (factory list will be removing chocolates and shop list will be adding chocolates. Simulating real Life)
                switch (choice.ToUpper())
                {
                    case "1":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in factory.F_ChocolateStorage.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is BlackChocolate blackChocolate)
                                {
                                    shop.StorageCapacity.Add(blackChocolate);                                    
                                    factory.F_ChocolateStorage.Remove(blackChocolate);

                                    // Factory Cut, At the selling point the store will get its final cut, so bare in mind this blackChocolate.ChocolatePrice - 1!!!
                                    factory.F_MakeTransaction(factory, blackChocolate.ChocolatePrice - blackChocolate.ChocolatePrice* factoryPercentegeCut);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Factory Storage");
                                }

                                // Check if there is a storage capacity to store the chocolate we asked from Factory, if there is not enough then we will transfer only as many for as many we can store
                                if (shop.StorageCapacity.Count >= maxStorageCapacity)
                                {
                                    Console.WriteLine("There is no other space in the store");
                                    throw new CustomException($"{chocolateCounter} Bars of Black chocolate was Succesfully transfered to the shop");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityTotransfer--;
                                if (quantityTotransfer == 0)
                                {
                                    break;
                                }
                                
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityTotransfer > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Factory Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Black chocolate was Succesfully transfered to the shop");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Black chocolate was Succesfully transfered to the shop");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in factory.F_ChocolateStorage.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is WhiteChocolate whiteChocolate)
                                {
                                    shop.StorageCapacity.Add(whiteChocolate);                                    
                                    factory.F_ChocolateStorage.Remove(whiteChocolate);

                                    // Factory Cut, At the selling point the store will get its final cut, so bare in mind this blackChocolate.ChocolatePrice - 1!!!
                                    factory.F_MakeTransaction(factory, whiteChocolate.ChocolatePrice - whiteChocolate.ChocolatePrice * factoryPercentegeCut);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Factory Storage");
                                }

                                // Check if there is a storage capacity to store the chocolate we asked from Factory, if there is not enough then we will transfer only as many for as many we can store
                                if (shop.StorageCapacity.Count >= maxStorageCapacity)
                                {
                                    Console.WriteLine("There is no other space in the store");
                                    throw new CustomException($"{chocolateCounter} Bars of White chocolate was Succesfully transfered to the shop");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityTotransfer--;
                                if (quantityTotransfer == 0)
                                {
                                    break;
                                }                               
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityTotransfer > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Factory Storage");
                                throw new CustomException($"{chocolateCounter} Bars of White chocolate was Succesfully transfered to the shop");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of White chocolate was Succesfully transfered to the shop");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in factory.F_ChocolateStorage.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is SimpleMilkChocolate simpleMilkChocolate)
                                {
                                    shop.StorageCapacity.Add(simpleMilkChocolate);                                    
                                    factory.F_ChocolateStorage.Remove(simpleMilkChocolate);

                                    // Factory Cut, At the selling point the store will get its final cut, so bare in mind this blackChocolate.ChocolatePrice - 1!!!
                                    factory.F_MakeTransaction(factory, simpleMilkChocolate.ChocolatePrice - simpleMilkChocolate.ChocolatePrice * factoryPercentegeCut);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Factory Storage");
                                }

                                // Check if there is a storage capacity to store the chocolate we asked from Factory, if there is not enough then we will transfer only as many for as many we can store
                                if (shop.StorageCapacity.Count >= maxStorageCapacity)
                                {
                                    Console.WriteLine("There is no other space in the store");
                                    throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the shop");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityTotransfer--;
                                if (quantityTotransfer == 0)
                                {
                                    break;
                                }
                                
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityTotransfer > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Factory Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the shop");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the shop");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in factory.F_ChocolateStorage.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is HazelMilkChocolate hazelMilkChocolate)
                                {
                                    shop.StorageCapacity.Add(hazelMilkChocolate);                                    
                                    factory.F_ChocolateStorage.Remove(hazelMilkChocolate);

                                    // Factory Cut, At the selling point the store will get its final cut, so bare in mind this blackChocolate.ChocolatePrice - 1!!!
                                    factory.F_MakeTransaction(factory, hazelMilkChocolate.ChocolatePrice - hazelMilkChocolate.ChocolatePrice * factoryPercentegeCut);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Factory Storage");
                                }

                                // Check if there is a storage capacity to store the chocolate we asked from Factory, if there is not enough then we will transfer only as many for as many we can store
                                if (shop.StorageCapacity.Count >= maxStorageCapacity)
                                {
                                    Console.WriteLine("There is no other space in the store");
                                    throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the shop");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityTotransfer--;
                                if (quantityTotransfer == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityTotransfer > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Factory Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Hazel Milk chocolate was Succesfully transfered to the shop");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Hazel Milk chocolate was Succesfully transfered to the shop");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in factory.F_ChocolateStorage.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is AlmondMilkChocolate almondMilkChocolate)
                                {
                                    shop.StorageCapacity.Add(almondMilkChocolate);                                    
                                    factory.F_ChocolateStorage.Remove(almondMilkChocolate);

                                    // Factory Cut, At the selling point the store will get its final cut, so bare in mind this blackChocolate.ChocolatePrice - 1!!!
                                    factory.F_MakeTransaction(factory, almondMilkChocolate.ChocolatePrice - almondMilkChocolate.ChocolatePrice * factoryPercentegeCut);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Factory Storage");
                                }

                                // Check if there is a storage capacity to store the chocolate we asked from Factory, if there is not enough then we will transfer only as many for as many we can store
                                if (shop.StorageCapacity.Count >= maxStorageCapacity)
                                {
                                    Console.WriteLine("There is no other space in the store");
                                    throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the shop");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityTotransfer--;
                                if (quantityTotransfer == 0)
                                {
                                    break;
                                }                             
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityTotransfer > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Factory Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Almond Milk chocolate was Succesfully transfered to the shop");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Almond Milk chocolate was Succesfully transfered to the shop");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    // Deafult values jsut in case of something dont work. Also it will help with DB later
                    default:
                        Console.WriteLine($"Something was wrong with your chocolate transfer.");
                        Console.WriteLine($"Transfer will start again...");
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message} Something was wrong with your chocolate transfer.");
                Console.WriteLine($"Transfer will start again...");
            }

        }
        public void PutChocolatesOnTheShelf(Shop shop)
        {
            // General Values for Use
            string choice = "";           
            int quantityToSell = 0;
            int chocolateCounter = 0;

            // Choose the chocolate that you want to put to the shelf
            try
            {
                // User will pick what chocolate he wants to put on the Shelf
                Console.WriteLine("Choose the Chocolate you want to put on the shelf");
                Console.WriteLine("1) Black Chocolate");
                Console.WriteLine("2) White Chocolate");
                Console.WriteLine("3) Simple Milk Chocolate");
                Console.WriteLine("4) Hazel Milk Chocolate");
                Console.WriteLine("5) Almond Milk Chocolate");
                choice = Console.ReadLine();

                // Here the user will choose how many chocolate you would like to put on the Shelf
                Console.WriteLine("Chose the quantity you want to put on the Shelf:");
                Console.WriteLine("1) 1 Chocolate Bar:");
                Console.WriteLine("2) 10 Chocolate Bars:");
                Console.WriteLine("3) 50 Chocolate Bars:");
                Console.WriteLine("4) Give the quantity you want:");
                quantityToSell = int.Parse(Console.ReadLine());

                // Quantities to transfer based on user input
                switch (quantityToSell)
                {
                    case 1:
                        quantityToSell = 1;
                        break;

                    case 2:
                        quantityToSell = 10;
                        break;
                    case 3:
                        quantityToSell = 50;
                        break;
                    case 4:
                        quantityToSell = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Give the quantity you would like to put on the shelf:");
                        quantityToSell = int.Parse(Console.ReadLine());
                        break;
                }

                // Transfering chocolates from the Shop Storage to the Shop Shelf (storage list will be removing chocolates and shelf list will be adding chocolates. Simulating real Life)
                switch (choice.ToUpper())
                {
                    case "1":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.StorageCapacity.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is BlackChocolate blackChocolate)
                                {
                                    shop.ShelfCapacity.Add(blackChocolate);
                                    shop.StorageCapacity.Remove(blackChocolate);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Shop Storage");
                                }

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (shop.ShelfCapacity.Count >= maxShelfCapacity)
                                {
                                    Console.WriteLine("There is no other space on the shelf");
                                    throw new CustomException($"{chocolateCounter} Bars of Black chocolate was Succesfully transfered to the Shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToSell--;
                                if (quantityToSell == 0)
                                {
                                    break;
                                }
                                
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToSell > chocolateCounter)
                            {                                
                                Console.WriteLine($"There is no other chocolate of this type in the Shop Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Black chocolate was Succesfully transfered to the Shelf");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Black chocolate was Succesfully put on the Shelf");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        try
                        {
                            // Make the default value again
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.StorageCapacity.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is WhiteChocolate whiteChocolate)
                                {
                                    shop.ShelfCapacity.Add(whiteChocolate);
                                    shop.StorageCapacity.Remove(whiteChocolate);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Shop Storage");
                                }

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (shop.ShelfCapacity.Count >= maxShelfCapacity)
                                {
                                    Console.WriteLine("There is no other space on the shelf");
                                    throw new CustomException($"{chocolateCounter} Bars of White chocolate was Succesfully transfered to the Shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToSell--;
                                if (quantityToSell == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToSell > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Shop Storage");
                                throw new CustomException($"{chocolateCounter} Bars of White chocolate was Succesfully transfered to the Shelf");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of White chocolate was Succesfully put on the Shelf");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        try
                        {
                            // Make the default value again
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.StorageCapacity.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is SimpleMilkChocolate simpleMilkChocolate)
                                {
                                    shop.ShelfCapacity.Add(simpleMilkChocolate);
                                    shop.StorageCapacity.Remove(simpleMilkChocolate);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Shop Storage");
                                }

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (shop.ShelfCapacity.Count >= maxShelfCapacity)
                                {
                                    Console.WriteLine("There is no other space on the shelf");
                                    throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the Shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToSell--;
                                if (quantityToSell == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToSell > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Shop Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully transfered to the Shelf");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully put on the Shelf");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        try
                        {
                            // Make the default value again
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.StorageCapacity.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is HazelMilkChocolate hazelMilkChocolate)
                                {
                                    shop.ShelfCapacity.Add(hazelMilkChocolate);
                                    shop.StorageCapacity.Remove(hazelMilkChocolate);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Shop Storage");
                                }

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (shop.ShelfCapacity.Count >= maxShelfCapacity)
                                {
                                    Console.WriteLine("There is no other space on the shelf");
                                    throw new CustomException($"{chocolateCounter} Bars of Hazel Milk chocolate was Succesfully transfered to the Shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToSell--;
                                if (quantityToSell == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToSell > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Shop Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Hazel Milk chocolate was Succesfully transfered to the Shelf");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Hazel Milk chocolate was Succesfully put on the Shelf");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            // Make the default value again
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.StorageCapacity.ToList())
                            {
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is AlmondMilkChocolate almondMilkChocolate)
                                {
                                    shop.ShelfCapacity.Add(almondMilkChocolate);
                                    shop.StorageCapacity.Remove(almondMilkChocolate);
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type stored in the Shop Storage");
                                }

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (shop.ShelfCapacity.Count >= maxShelfCapacity)
                                {
                                    Console.WriteLine("There is no other space on the shelf");
                                    throw new CustomException($"{chocolateCounter} Bars of Almond Milk chocolate was Succesfully transfered to the Shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToSell--;
                                if (quantityToSell == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToSell > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type in the Shop Storage");
                                throw new CustomException($"{chocolateCounter} Bars of Almomd Milk chocolate was Succesfully transfered to the Shelf");
                            }

                            // If there is no check trigger then this will be printed
                            shop.ShopRunningCosts();
                            Console.WriteLine($"{chocolateCounter} Bars of Almond Milk chocolate was Succesfully put on the Shelf");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    // Deafult values jsut in case of something dont work. Also it will help with DB later
                    default:
                        Console.WriteLine($"Something was wrong with your chocolate shleft storing.");
                        Console.WriteLine($"Shelf storing will start again...");
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message} Something was wrong with your chocolate shleft storing.");
                Console.WriteLine($"Shelf storing will start again...");
            }

        }
        public void SellChocolates(Shop shop, Customer customer)
        {
            // General Values for Use
            string choice = "";           
            int quantityToBuy = 0;
            int chocolateCounter = 0;

            // Selling proccess
            try
            {
                Console.WriteLine("The Below Chocolates are for Sale");

                // Prin chocolate type only one time so the buyer can choose what he wants to buy
                foreach (IChocolate chocolate in shop.ShelfCapacity)
                {
                    if (chocolate is BlackChocolate blackChocolate)
                    {
                        Console.WriteLine($"1) Black Chocolate for {blackChocolate.ChocolatePrice}");
                    }                    
                    break;
                }

                // Prin chocolate type only one time so the buyer can choose what he wants to buy
                foreach (IChocolate chocolate in shop.ShelfCapacity)
                {
                    if (chocolate is WhiteChocolate whiteChocolate)
                    {
                        Console.WriteLine($"2) White Chocolate {whiteChocolate.ChocolatePrice}");
                    }                    
                    break;
                }

                // Prin chocolate type only one time so the buyer can choose what he wants to buy
                foreach (IChocolate chocolate in shop.ShelfCapacity)
                {
                    if (chocolate is SimpleMilkChocolate simpleMilkChocolate)
                    {
                        Console.WriteLine($"3) Simple Milk Chocolate for {simpleMilkChocolate.ChocolatePrice}");
                    }                    
                    break;
                }

                // Prin chocolate type only one time so the buyer can choose what he wants to buy
                foreach (IChocolate chocolate in shop.ShelfCapacity)
                {
                    if (chocolate is HazelMilkChocolate hazelMilkChocolate)
                    {
                        Console.WriteLine($"4) Hazel Milk Chocolate for {hazelMilkChocolate.ChocolatePrice}");
                    }                    
                    break;
                }

                // Prin chocolate type only one time so the buyer can choose what he wants to buy
                foreach (IChocolate chocolate in shop.ShelfCapacity)
                {
                    if (chocolate is AlmondMilkChocolate almondMilkChocolate)
                    {
                        Console.WriteLine($"1) Black Chocolate for {almondMilkChocolate.ChocolatePrice}");
                    }                    
                    break;
                }

                //User Will choose what chocolate he wants to buy
                Console.WriteLine("Chose the Chocolate you want to buy");
                choice = Console.ReadLine();

                // Here the user will choose how many chocolate he would like to buy
                Console.WriteLine("Chose the quantity you want to Sell:");
                Console.WriteLine("1) 1 Chocolate Bar:");
                Console.WriteLine("2) 10 Chocolate Bars:");
                Console.WriteLine("3) 50 Chocolate Bars:");
                Console.WriteLine("4) Give the quantity you want:");
                quantityToBuy = int.Parse(Console.ReadLine());

                // Quantities to transfer based on user input
                switch (quantityToBuy)
                {
                    case 1:
                        quantityToBuy = 1;
                        break;

                    case 2:
                        quantityToBuy = 10;
                        break;
                    case 3:
                        quantityToBuy = 50;
                        break;
                    case 4:
                        quantityToBuy = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Give the quantity you would like to Sell:");
                        quantityToBuy = int.Parse(Console.ReadLine());
                        break;
                }               

                // Transfering chocolates from the shelft to the Customer (shelf list will be removing chocolates and Customer list will be adding chocolates. Simulating real Life)
                // By this proccess some properties are triggered (Wallet for the income).
                switch (choice.ToUpper())
                {
                    case "1":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.ShelfCapacity.ToList())
                            {
                                // This counter will count how many times the foreach loop runs, Thats how many chocolates will be sold to the customer
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is BlackChocolate blackChocolate)
                                {
                                    // Take money from the Customer
                                    customer.C_MakeTransaction(customer, (-blackChocolate.ChocolatePrice));
                                    // Check for when the Customer dont have the funds to buy the chocolate he wants                                    

                                    // Add chocolates to the customer List
                                    customer.C_ListOfChocolates.Add(blackChocolate);
                                    // Take money from the Customer
                                    shop.S_Wallet.MakeTransaction(shop.S_Wallet, (blackChocolate.ChocolatePrice - blackChocolate.ChocolatePrice * shopPercentageCut));    
                                    // Remove chocolate from the shelf
                                    shop.ShelfCapacity.Remove(blackChocolate);  

                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type on the shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToBuy--;
                                if (quantityToBuy == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToBuy > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type on the Shelf");
                                throw new CustomException($"{chocolateCounter} Bars of Black chocolate was Succesfully sold to the customer");
                            }

                            // If there is no check trigger then this will be printed
                            Console.WriteLine($"{chocolateCounter} Bar(s) of chocolate was Succesfully sold to the Customer");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.ShelfCapacity.ToList())
                            {
                                // This counter will count how many times the foreach loop runs, Thats how many chocolates will be sold to the customer
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is WhiteChocolate whiteChocolate)
                                {
                                    // Take money from the Customer
                                    customer.C_MakeTransaction(customer, (-whiteChocolate.ChocolatePrice));
                                    // Add chocolates to the customer List
                                    customer.C_ListOfChocolates.Add(whiteChocolate);
                                    // Take money from the Customer
                                    shop.S_Wallet.MakeTransaction(shop.S_Wallet, (whiteChocolate.ChocolatePrice - whiteChocolate.ChocolatePrice * shopPercentageCut));
                                    // Remove chocolate from the shelf
                                    shop.ShelfCapacity.Remove(whiteChocolate);

                                    // !!!!!!!!!!!!!!!!!! NEEDED CHECKS FOR TRANSACTIONS AND CHOCOLATES ADD AND REMOVE (MOSTLY SAME WIHT ABOVE) !!!!!!!!!!!!!!!!
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type on the shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToBuy--;
                                if (quantityToBuy == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToBuy > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type on the Shelf");
                                throw new CustomException($"{chocolateCounter} Bars of White chocolate was Succesfully sold to the customer");
                            }

                            // If there is no check trigger then this will be printed
                            Console.WriteLine($"{chocolateCounter} Bar(s) of chocolate was Succesfully sold to the Customer");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.ShelfCapacity.ToList())
                            {
                                // This counter will count how many times the foreach loop runs, Thats how many chocolates will be sold to the customer
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is SimpleMilkChocolate simpleMilkChocolate)
                                {
                                    // Take money from the Customer
                                    customer.C_MakeTransaction(customer, (-simpleMilkChocolate.ChocolatePrice));
                                    // Add chocolates to the customer List
                                    customer.C_ListOfChocolates.Add(simpleMilkChocolate);
                                    // Take money from the Customer
                                    shop.S_Wallet.MakeTransaction(shop.S_Wallet, (simpleMilkChocolate.ChocolatePrice - simpleMilkChocolate.ChocolatePrice * shopPercentageCut));
                                    // Remove chocolate from the shelf
                                    shop.ShelfCapacity.Remove(simpleMilkChocolate);

                                    // !!!!!!!!!!!!!!!!!! NEEDED CHECKS FOR TRANSACTIONS AND CHOCOLATES ADD AND REMOVE (MOSTLY SAME WIHT ABOVE) !!!!!!!!!!!!!!!!
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no Black Chocolate stored in the Shop Storage");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToBuy--;
                                if (quantityToBuy == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToBuy > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type on the Shelf");
                                throw new CustomException($"{chocolateCounter} Bars of Simple Milk chocolate was Succesfully sold to the customer");
                            }

                            // If there is no check trigger then this will be printed
                            Console.WriteLine($"{chocolateCounter} Bar(s) of chocolate was Succesfully sold to the Customer");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.ShelfCapacity.ToList())
                            {
                                // This counter will count how many times the foreach loop runs, Thats how many chocolates will be sold to the customer
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is HazelMilkChocolate hazelMilkChocolate)
                                {
                                    // Take money from the Customer
                                    customer.C_MakeTransaction(customer, (-hazelMilkChocolate.ChocolatePrice));
                                    // Add chocolates to the customer List
                                    customer.C_ListOfChocolates.Add(hazelMilkChocolate);
                                    // Take money from the Customer
                                    shop.S_Wallet.MakeTransaction(shop.S_Wallet, (hazelMilkChocolate.ChocolatePrice - hazelMilkChocolate.ChocolatePrice * shopPercentageCut));
                                    // Remove chocolate from the shelf
                                    shop.ShelfCapacity.Remove(hazelMilkChocolate);

                                    // !!!!!!!!!!!!!!!!!! NEEDED CHECKS FOR TRANSACTIONS AND CHOCOLATES ADD AND REMOVE (MOSTLY SAME WIHT ABOVE) !!!!!!!!!!!!!!!!
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type on the shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToBuy--;
                                if (quantityToBuy == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToBuy > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type on the Shelf");
                                throw new CustomException($"{chocolateCounter} Bars of Hazel Milk chocolate was Succesfully sold to the customer");
                            }

                            // If there is no check trigger then this will be printed
                            Console.WriteLine($"{chocolateCounter} Bar(s) of chocolate was Succesfully sold to the Customer");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            // Make the default value again (Following the pattern)
                            chocolateCounter = 0;

                            foreach (IChocolate chocolate in shop.ShelfCapacity.ToList())
                            {
                                // This counter will count how many times the foreach loop runs, Thats how many chocolates will be sold to the customer
                                chocolateCounter++;

                                // Using Interface we take only the type of chocolate we want
                                if (chocolate is AlmondMilkChocolate almondMilkChocolate)
                                {
                                    // Take money from the Customer
                                    customer.C_MakeTransaction(customer, (-almondMilkChocolate.ChocolatePrice));
                                    // Add chocolates to the customer List
                                    customer.C_ListOfChocolates.Add(almondMilkChocolate);
                                    // Take money from the Customer
                                    shop.S_Wallet.MakeTransaction(shop.S_Wallet, (almondMilkChocolate.ChocolatePrice - almondMilkChocolate.ChocolatePrice * shopPercentageCut));
                                    // Remove chocolate from the shelf
                                    shop.ShelfCapacity.Remove(almondMilkChocolate);

                                    // !!!!!!!!!!!!!!!!!! NEEDED CHECKS FOR TRANSACTIONS AND CHOCOLATES ADD AND REMOVE (MOSTLY SAME WIHT ABOVE) !!!!!!!!!!!!!!!!
                                }
                                else
                                {
                                    // If the user input is for a chocolota that does not exist from the previous method, then this check will trigger.
                                    // Solves the  problem for whem the user want to transfer a chocolate that was not created previously
                                    throw new CustomException($"There is no chocolate of this type on the shelf");
                                }

                                // A loop that will determine based on user input how many times the foreach will run (when foreach count > user input count)
                                quantityToBuy--;
                                if (quantityToBuy == 0)
                                {
                                    break;
                                }
                            }

                            // Check if there is a capacity we are asking, if there is not enough then we will transfer only as many as we have
                            if (quantityToBuy > chocolateCounter)
                            {
                                Console.WriteLine($"There is no other chocolate of this type on the Shelf");
                                throw new CustomException($"{chocolateCounter} Bars of Almond Milk chocolate was Succesfully sold to the customer");
                            }

                            // If there is no check trigger then this will be printed
                            Console.WriteLine($"{chocolateCounter} Bar(s) of chocolate was Succesfully sold to the Customer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    // Deafult values jsut in case of something dont work. Also it will help with DB later
                    default:
                        Console.WriteLine($"Something was wrong with your chocolate production.");
                        Console.WriteLine($"Production will start again...");
                        break;
                }                

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }

        }
        private void ShopRunningCosts()
        {

            // Stable Cost of Machinery used -> Marginal Cost also (MPC)
            double stableCosts = 0.01;
            double expences = 0;

            foreach (IEmployee iemployee in ShopEmployees)
            {
                if (iemployee is ShopEmployee factoryEmployee)
                {
                    // This expecne type is based on economic principal that the meployees are beeing payed according to their Marginal Prodcution
                    // The salary is not the monthly one, but the one they are payed for each time the proccess of production is triggered
                    expences += factoryEmployee.Salary + stableCosts;
                }
            }
            // With this method, the factory wallet will suffer the cost of paying the employees
            S_Wallet.MakeTransaction(S_Wallet, (-expences));
        }
        public void Shop_MakeTransaction(Shop shop, double cost)
        {
            shop.S_Wallet.MakeTransaction(shop.S_Wallet, cost);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Shop Name: {this.Shop_Name}")
              .AppendLine($"Shop Address: {this.Shop_Address}")
              .AppendLine($"Shop Employees: {this.ShopEmployees.Count}")
              .AppendLine($"Shop Available Money to Spend: {this.S_Wallet:N0}")
              .AppendLine($"Shop Stored Chocolates: {this.StorageCapacity.Count} Bars")
              .AppendLine($"Shop Chocolates on Shelfs: {this.ShelfCapacity.Count} Bars");

            return sb.ToString();

        }
    }     

}
    

