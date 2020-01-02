using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class Program
    {
        static void Main(string[] args)
        {
            // General Values used
            bool activated = true;
            string choice = "";
            int picker1 = 0;
            int picker2 = 0;
            Random random = new Random();
            int counter1 = 0;
            int counter2 = 0;

            List<Factory> listFactories = new List<Factory>();
            List<Shop> listShops = new List<Shop>();
            List<Customer> listCustomers = new List<Customer>();

            //this is the bigger loop, when the programm stops running its fuctions, then we will ask the user if he wants to do something else. This adds replayability.
            do
            {
                // Scenario running
                Console.WriteLine("....................... -Welcome to the Chocolate Factory program part A- .......................");
                Console.WriteLine("Choose a task:");
                Console.WriteLine("1) Create Instances (Factory, Shop, Customer)");
                Console.WriteLine("2) Buy Raw Materials for the Factory (Factory and Supplier -> Its Automated)");
                Console.WriteLine("3) Produce Chocolate (In the Factory)");
                Console.WriteLine("4) Transfer Chocolate (From Factory to the Shop)");
                Console.WriteLine("5) Transfer Chocolate (From Shop Storage to the Shop Shelfs)");
                Console.WriteLine("6) Sell Chcolate (From Shop Shlefs to the Customer)");
                Console.WriteLine("7) Check info for each Instance (Print Lists for every Instance we have)");
                Console.WriteLine("8) Exit");

                choice = Console.ReadLine();

                switch (choice)
                {
                    // User will Create Instances
                    case "1":
                        do
                        {
                            // The counters should always start from 0 so they display correct info
                            counter1 = 0;
                            counter2 = 0;

                            try
                            {
                                // Switch for UI, user decides what he wants to create                    
                                Console.WriteLine("1) Create a Chocolate Factory");
                                Console.WriteLine("2) Create a Shop");
                                Console.WriteLine("3) Create a Customer");
                                Console.WriteLine("4) Exit");
                                choice = Console.ReadLine();

                                switch (choice.ToUpper())
                                {
                                    case "1":
                                        Console.WriteLine("Enter the Factory Name");
                                        string factoryName = Console.ReadLine();
                                        Console.WriteLine("Enter the Factory Adress");
                                        string factoryAddress = Console.ReadLine();

                                        Factory factory = new Factory(factoryName, factoryAddress);
                                        listFactories.Add(factory);

                                        Console.WriteLine("Factory Details Saved");

                                        // A method where user will decide if he wants to countinue creating new entities.
                                        Console.WriteLine("Would you like to create another Instance? Y/N");
                                        choice = Console.ReadLine();
                                        activated = Repeater.RepeatTheProgram(choice);
                                        break;

                                    case "2":
                                        Console.WriteLine("Enter the Shop Name");
                                        string shopName = Console.ReadLine();
                                        Console.WriteLine("Enter the Shop Adress");
                                        string shopAddress = Console.ReadLine();

                                        Shop shop = new Shop(shopName, shopAddress);
                                        listShops.Add(shop);

                                        Console.WriteLine("Shop Details Saved");

                                        // A method where user will decide if he wants to countinue creating new entities.
                                        Console.WriteLine("Would you like to create another Instance? Y/N");
                                        choice = Console.ReadLine();
                                        activated = Repeater.RepeatTheProgram(choice);
                                        break;

                                    case "3":
                                        Console.WriteLine("For now, the Customer will be Auto Generated");
                                        Customer customer = new Customer(random);
                                        listCustomers.Add(customer);

                                        Console.WriteLine("Customer Details Saved");

                                        // A method where user will decide if he wants to countinue creating new entities.
                                        Console.WriteLine("Would you like to create another Instance? Y/N");
                                        choice = Console.ReadLine();
                                        activated = Repeater.RepeatTheProgram(choice);
                                        break;

                                    default:
                                        // A method where user will decide if he wants to countinue or proccess to then next part
                                        Console.WriteLine("Would you like to create another Instance? Y/N");
                                        choice = Console.ReadLine();
                                        activated = Repeater.RepeatTheProgram(choice);
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                        } while (activated);
                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                    // User now will be guided throught the proccess of Buying Raw Materials, Creating Chocolate, Transfering, Storing, Putiing on the Shops Shelf and Selling                   
                    case "2":
                        do
                        {
                            // The counters should always start from 0 so they display correct info
                            counter1 = 0;
                            counter2 = 0;

                            try
                            {                                                                
                                Console.WriteLine("Pick a factory to make chocolate:");
                                // The counters should always start from 0 so they display correct info
                                counter1 = 0;
                                counter2 = 0;

                                foreach (Factory factory in listFactories)
                                {
                                    counter1++;
                                    Console.WriteLine($"Factory Number: {counter1}");
                                    Console.WriteLine(factory);
                                }
                                picker1 = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Factory Successfully Picked");

                                try
                                {
                                    listFactories[picker1].BuyRawMaterialas(listFactories[picker1]);
                                    Console.WriteLine("Your Factory has successfully bought the Raw Materials");
                                    Console.WriteLine(listFactories[picker1]);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }
                                // A method where user will decide if he wants to countinue or proccess to then next part
                                Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                choice = Console.ReadLine();
                                activated = Repeater.RepeatTheProgram(choice);
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        } while (activated);

                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                        // Produce Chocolate
                    case "3":
                        do
                        {
                            // The counters should always start from 0 so they display correct info
                            counter1 = 0;
                            counter2 = 0;

                            foreach (Factory factory in listFactories)
                            {
                                counter1++;
                                Console.WriteLine($"Factory Number: {counter1}");
                                Console.WriteLine(factory);
                            }
                            picker1 = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Factory Successfully Picked");

                            listFactories[picker1].MakeChocolate(listFactories[picker1]);
                            // A method where user will decide if he wants to countinue or proccess to then next part
                            Console.WriteLine(listFactories[picker1]);

                            Console.WriteLine("Would you like to repeat the proccess? Y/N");
                            choice = Console.ReadLine();
                            activated = Repeater.RepeatTheProgram(choice);

                        } while (activated);

                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                    // Ask the user if he wants to transfer the chocolate.
                    case "4":
                        do
                        {                           
                            // The counters should always start from 0 so they display correct info
                            counter1 = 0;
                            counter2 = 0;

                            try
                            {                               
                                Console.WriteLine("Pick a Shop to transfer the chocolate:");
                                foreach (Shop shop in listShops)
                                {
                                    counter2++;
                                    Console.WriteLine($"Shop Number: {counter2}");
                                    Console.WriteLine(shop);
                                }
                                picker2 = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Shop Successfully Picked");

                                try
                                {
                                    listShops[picker2].TransferChocolatesToTheShop(listFactories[picker1], listShops[picker2]);
                                    Console.WriteLine("The Chcocolate was succesfully transfered to the Shop Storage");
                                    Console.WriteLine(listShops[picker2]);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }

                                // A method where user will decide if he wants to countinue or proccess to then next part
                                Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                choice = Console.ReadLine();
                                activated = Repeater.RepeatTheProgram(choice);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        } while (activated);

                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                    // User will decide if he want to transfer chocolate from His store to the Shelf (This can be upgraded to a version where user first chooses his Shop to do so)
                    case "5":
                        do
                        {
                            // The counters should always start from 0 so they display correct info
                            counter1 = 0;
                            counter2 = 0;

                            try
                            {
                                Console.WriteLine("Pick a Shop:");
                                foreach (Shop shop in listShops)
                                {
                                    counter2++;
                                    Console.WriteLine($"Shop Number: {counter2}");
                                    Console.WriteLine(shop);
                                }
                                picker2 = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Shop Successfully Picked");

                                try
                                {
                                    listShops[picker2].PutChocolatesOnTheShelf(listShops[picker2]);
                                    Console.WriteLine("The Chcocolate was succesfully transfered to the Shop Shelf");
                                    Console.WriteLine(listShops[picker2]);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }

                                // A method where user will decide if he wants to countinue or proccess to then next part
                                Console.WriteLine("Would you like to repat the proccess? Y/N");
                                choice = Console.ReadLine();
                                activated = Repeater.RepeatTheProgram(choice);
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        } while (activated);

                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                    // Proceeed to sell the Chocolate
                    case "6":
                        do
                        {
                            // The counters should always start from 0 so they display correct info
                            counter1 = 0;
                            counter2 = 0;

                            try
                            {                                
                                // Pick the shop from which you want to sell the chocolate
                                Console.WriteLine("Pick a Shop:");
                                foreach (Shop shop in listShops)
                                {
                                    counter2++;
                                    Console.WriteLine($"Shop Number: {counter1}");
                                    Console.WriteLine(shop);
                                }
                                picker1 = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Shop Successfully Picked");

                                // Pick the Customer to whom you want to sell the chocolate
                                Console.WriteLine("Pick a Customer:");
                                foreach (Customer customer in listCustomers)
                                {
                                    counter2++;
                                    Console.WriteLine($"Customer Number: {counter2}");
                                    Console.WriteLine(customer);
                                }
                                picker2 = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Customer Successfully Picked");

                                try
                                {
                                    listShops[picker1].SellChocolates(listShops[picker1], listCustomers[picker2]);
                                    Console.WriteLine("The Chcocolate was succesfully transfered to the Shop Shelf");
                                    Console.WriteLine(listShops[picker2]);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"{ex.Message}");
                                }

                                // A method where user will decide if he wants to countinue or proccess to then next part
                                Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                choice = Console.ReadLine();
                                activated = Repeater.RepeatTheProgram(choice);
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        } while (activated);

                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                    case "7":
                        do
                        {
                            Console.WriteLine("Choose the Instance for which you want Info:");
                            Console.WriteLine("1) Factory");
                            Console.WriteLine("2) Shop");
                            Console.WriteLine("3) Customer");
                            Console.WriteLine("4) Exit");

                            choice = Console.ReadLine();

                            switch (choice.ToUpper())
                            {
                                case "1":
                                    // The counters should always start from 0 so they display correct info
                                    counter1 = 0;

                                    // Factory Print List
                                    foreach (Factory factory in listFactories)
                                    {
                                        counter1++;
                                        Console.WriteLine($"Factory Number: {counter1}");
                                        Console.WriteLine(factory);
                                    }
                                    // A method where user will decide if he wants to countinue or proccess to then next part
                                    Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                    choice = Console.ReadLine();
                                    activated = Repeater.RepeatTheProgram(choice);
                                    break;

                                // Shop Print List
                                case "2":
                                    // The counters should always start from 0 so they display correct info
                                    counter1 = 0;

                                    foreach (Shop shop in listShops)
                                    {
                                        counter1++;
                                        Console.WriteLine($"Shop Number: {counter1}");
                                        Console.WriteLine(shop);
                                    }
                                    // A method where user will decide if he wants to countinue or proccess to then next part
                                    Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                    choice = Console.ReadLine();
                                    activated = Repeater.RepeatTheProgram(choice);
                                    break;

                                // Customer Print List
                                case "3":
                                    // The counters should always start from 0 so they display correct info
                                    counter1 = 0;

                                    foreach (Customer customer in listCustomers)
                                    {
                                        counter1++;
                                        Console.WriteLine($"Customer Number: {counter1}");
                                        Console.WriteLine(customer);
                                    }
                                    // A method where user will decide if he wants to countinue or proccess to then next part
                                    Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                    choice = Console.ReadLine();
                                    activated = Repeater.RepeatTheProgram(choice);
                                    break;

                                default:
                                    // A method where user will decide if he wants to countinue or proccess to then next part
                                    Console.WriteLine("Would you like to repeat the proccess? Y/N");
                                    choice = Console.ReadLine();
                                    activated = Repeater.RepeatTheProgram(choice);
                                    break;
                            }                            

                        } while (activated);
                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;

                    default:
                        // A method where user will decide if he wants to countinue or proccess to then next part
                        Console.WriteLine("Do something else? Y/N");
                        choice = Console.ReadLine();
                        activated = Repeater.RepeatTheProgram(choice);
                        break;
                }                               
            } while (activated);



        }
    }
}
