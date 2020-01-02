using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryA
{
    class Factory
    {
        // Put constants here
        const double maxStorageRawMaterials = 5000;

        // Put Properties here
        public string Factory_Name { get; set; }
        public string Factory_Address { get; set; }        
        private double F_MaterialsKg { get; set; } = 0;
        private List<IEmployee> FactoryEmployees { get; set; }
        public List<IChocolate> F_ChocolateStorage { get; set; }
        private Wallet F_Wallet { get; set; }

        // Put Constructors here
        public Factory(string factoryName, string factoryAdress)
        {
            Factory_Name = factoryName;
            Factory_Address = factoryAdress;
            FactoryEmployees = new List<IEmployee>();
            F_ChocolateStorage = new List<IChocolate>();
            F_Wallet = new Wallet();

            //AmountOfRawMaterials = 10000;

            // Dummy Fake Employees in the factory (WARNING, THEY DONT BELONG HERE!!!!)
            IEmployee employee1 = new FactoryEmployee();
            FactoryEmployees.Add(employee1);
            IEmployee employee2 = new FactoryEmployee();
            FactoryEmployees.Add(employee2);
            IEmployee employee3 = new FactoryEmployee();
            FactoryEmployees.Add(employee3);
            IEmployee employee4 = new FactoryEmployee();
            FactoryEmployees.Add(employee4);
            IEmployee employee5 = new FactoryEmployee();
            FactoryEmployees.Add(employee5);
            IEmployee employee6 = new FactoryEmployee();
            FactoryEmployees.Add(employee6);
            IEmployee employee7 = new FactoryEmployee();
            FactoryEmployees.Add(employee7);
            IEmployee employee8 = new FactoryEmployee();
            FactoryEmployees.Add(employee8);
            IEmployee employee9 = new FactoryEmployee();
            FactoryEmployees.Add(employee9);
            IEmployee employee10 = new FactoryEmployee();
            FactoryEmployees.Add(employee10);
        }

        // Put Methods Here

        // User will choose which factory will make his chocolate (upgrade in mind>?)
        public void MakeChocolate(Factory factory)
        {           
            // General Values for Chocolate generation
            string choice = "";
            int quantityProduction = 0;

            try
            {
                // User will pick what chocolate he wants to create
                Console.WriteLine("Choose the Chocolate you want to produce");
                Console.WriteLine("1) Black Chocolate");
                Console.WriteLine("2) White Chocolate");
                Console.WriteLine("3) Simple Milk Chocolate");
                Console.WriteLine("4) Hazel Milk Chocolate");
                Console.WriteLine("5) Almond Milk Chocolate");
                choice = Console.ReadLine();

                // Here the user will choose how many chocolate you would like to make
                Console.WriteLine("Chose the quantity you want to produce:");
                Console.WriteLine("1) 1 Chocolate Bar:");
                Console.WriteLine("2) 10 Chocolate Bar:");
                Console.WriteLine("3) 50 Chocolate Bar:");
                Console.WriteLine("4) Give the quantity you want:");
                quantityProduction = int.Parse(Console.ReadLine());

                // The quantity based on the user choice
                switch (quantityProduction)
                {
                    case 1:
                        quantityProduction = 1;
                        break;

                    case 2:
                        quantityProduction = 10;
                        break;
                    case 3:
                        quantityProduction = 50;
                        break;
                    case 4:
                        quantityProduction = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Give the quantity you would like to produce:");
                        quantityProduction = int.Parse(Console.ReadLine());
                        break;
                }

                switch (choice.ToUpper())
                {
                    // Production of Black Chocolate
                    case "1":
                        for (int i = 0; i < quantityProduction; i++)
                        {
                            // Add chocolate to IChocolate list call storage and take the resources that was used from the stock pile of Raw Materials in the factory
                            IChocolate blackChocolate = new BlackChocolate();
                            factory.F_ChocolateStorage.Add(blackChocolate);
                            factory.F_MaterialsKg -= blackChocolate.RawMaterialsNeeded;
                            factory.FuctoryRunningCosts();
                        }
                        Console.WriteLine($"{quantityProduction} Bars of Black chocolate was Succesfully produced");
                        break;

                    // Production of White Chocolate
                    case "2":
                        for (int i = 0; i < quantityProduction; i++)
                        {
                            // Add chocolate to IChocolate list call storage and take the resources that was used from the stock pile of Raw Materials in the factory
                            IChocolate whiteChocolate = new WhiteChocolate();
                            factory.F_ChocolateStorage.Add(whiteChocolate);
                            factory.F_MaterialsKg -= whiteChocolate.RawMaterialsNeeded;
                            factory.FuctoryRunningCosts();
                        }
                        Console.WriteLine($"{quantityProduction} Bars of White chocolate was Succesfully produced");
                        break;

                    // Production of Milk Chocolate
                    case "3":
                        for (int i = 0; i < quantityProduction; i++)
                        {
                            // Add chocolate to IChocolate list call storage and take the resources that was used from the stock pile of Raw Materials in the factory
                            IChocolate simpleMilkChocolate = new SimpleMilkChocolate();
                            factory.F_ChocolateStorage.Add(simpleMilkChocolate);
                            factory.F_MaterialsKg -= simpleMilkChocolate.RawMaterialsNeeded;
                            factory.FuctoryRunningCosts();
                        }
                        Console.WriteLine($"{quantityProduction} Bars of Simple Milk chocolate was Succesfully produced");
                        break;

                    // Production of Hazel Milk Chocolate
                    case "4":
                        for (int i = 0; i < quantityProduction; i++)
                        {
                            // Add chocolate to IChocolate list call storage and take the resources that was used from the stock pile of Raw Materials in the factory
                            IChocolate hazelMilkChocolate = new HazelMilkChocolate();
                            factory.F_ChocolateStorage.Add(hazelMilkChocolate);
                            factory.F_MaterialsKg -= hazelMilkChocolate.RawMaterialsNeeded;
                            factory.FuctoryRunningCosts();
                        }
                        Console.WriteLine($"Hazel Milk chocolate was Succesfully produced");
                        break;

                    // Production of Almond Milk Chocolate
                    case "5":
                        for (int i = 0; i < quantityProduction; i++)
                        {
                            // Add chocolate to IChocolate list call storage and take the resources that was used from the stock pile of Raw Materials in the factory
                            IChocolate almondMilkChocolate = new AlmondMilkChocolate();
                            factory.F_ChocolateStorage.Add(almondMilkChocolate);
                            factory.F_MaterialsKg -= almondMilkChocolate.RawMaterialsNeeded;
                            factory.FuctoryRunningCosts();
                        }
                        Console.WriteLine($"{quantityProduction} Bars of Almond Milk chocolate was Succesfully produced");
                        break;

                    // Maybe i could avoid using try catch and default together (will see).
                    default:
                        Console.WriteLine($"Something was wrong with your chocolate production.");
                        Console.WriteLine($"Production will start again...");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} Something was wrong with your chocolate production.");
                Console.WriteLine($"Production will start again...");
            }
        }
        public void BuyRawMaterialas(Factory factory)
        {
            // Values needed for the scenario
            Random random = new Random();
            int choice = 0;

            List<IRawMaterialsOffer> listOfRawMaterialsOffer = new List<IRawMaterialsOffer>();           
          

            SupplierA supplierA = new SupplierA(random);
            listOfRawMaterialsOffer.Add(supplierA.GiveΟfferRawMaterials(supplierA, random));

            SupplierB supplierB = new SupplierB(random);
            listOfRawMaterialsOffer.Add(supplierB.GiveΟfferRawMaterials(supplierB, random));

            SupplierC supplierC = new SupplierC(random);
            listOfRawMaterialsOffer.Add(supplierC.GiveΟfferRawMaterials(supplierC, random));

            Console.WriteLine("Choose Which Offer you want:");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    try
                    {
                        foreach (IRawMaterialsOffer rawMaterialsOffer in listOfRawMaterialsOffer)
                        {
                            // Using Interface we take only the type of offer we want
                            if (rawMaterialsOffer is RawMaterialsOfferA rawMaterialsOfferA)
                            {
                                factory.F_MaterialsKg += rawMaterialsOfferA.QuantityKg;
                                factory.F_Wallet.MakeTransaction(factory.F_Wallet, (-rawMaterialsOfferA.PricePerKg));

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (rawMaterialsOfferA.QuantityKg > maxStorageRawMaterials && F_MaterialsKg > maxStorageRawMaterials)
                                {
                                    factory.F_MaterialsKg = maxStorageRawMaterials;
                                    Console.WriteLine("There is no other space to store Raw Materials");
                                    throw new CustomException($"{maxStorageRawMaterials - rawMaterialsOfferA.QuantityKg:N0} Raw Materials was wastfully thrown");
                                }

                                // Supplier Changes
                                supplierA.S_MakeTransaction(supplierA, rawMaterialsOfferA.PricePerKg);

                                // If there is no check trigger then this will be printed
                                Console.WriteLine($"{rawMaterialsOfferA.QuantityKg:N0} kg of Raw materials was Succesfully stored in the Factory");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;                    
                case 2:
                    try
                    {
                        foreach (IRawMaterialsOffer rawMaterialsOffer in listOfRawMaterialsOffer)
                        {
                            // Using Interface we take only the type of offer we want
                            if (rawMaterialsOffer is RawMaterialsOfferB rawMaterialsOfferB)
                            {
                                factory.F_MaterialsKg += rawMaterialsOfferB.QuantityKg;
                                F_Wallet.MakeTransaction(F_Wallet, (-rawMaterialsOfferB.PricePerKg));

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (rawMaterialsOfferB.QuantityKg > maxStorageRawMaterials && F_MaterialsKg > maxStorageRawMaterials)
                                {
                                    factory.F_MaterialsKg = maxStorageRawMaterials;
                                    Console.WriteLine("There is no other space to store Raw Materials");
                                    throw new CustomException($"{maxStorageRawMaterials - rawMaterialsOfferB.QuantityKg:N0} Raw Materials was wastfully thrown");
                                }

                                // Supplier Changes
                                supplierA.S_MakeTransaction(supplierA, rawMaterialsOfferB.PricePerKg);

                                // If there is no check trigger then this will be printed
                                Console.WriteLine($"{rawMaterialsOfferB.QuantityKg:N0} kg of Raw materials was Succesfully stored in the Factory");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 3:
                    try
                    {                       
                        foreach (IRawMaterialsOffer rawMaterialsOffer in listOfRawMaterialsOffer)
                        {
                            // Using Interface we take only the type of offer we want
                            if (rawMaterialsOffer is RawMaterialsOfferC rawMaterialsOfferC)
                            {
                                factory.F_MaterialsKg += rawMaterialsOfferC.QuantityKg;
                                F_Wallet.MakeTransaction(F_Wallet, (-rawMaterialsOfferC.PricePerKg));

                                // Check if there is a storage capacity to shelf the chocolate we asked from shop storage, if there is not enough then we will transfer only as many for as many we can shelf
                                if (rawMaterialsOfferC.QuantityKg > maxStorageRawMaterials && F_MaterialsKg > maxStorageRawMaterials)
                                {
                                    factory.F_MaterialsKg = maxStorageRawMaterials;
                                    Console.WriteLine("There is no other space to store Raw Materials");
                                    throw new CustomException($"{maxStorageRawMaterials - rawMaterialsOfferC.QuantityKg:N0} Raw Materials was wastfully thrown");
                                }

                                // Supplier Changes
                                supplierA.S_MakeTransaction(supplierA, rawMaterialsOfferC.PricePerKg);

                                // If there is no check trigger then this will be printed
                                Console.WriteLine($"{rawMaterialsOfferC.QuantityKg:N0} kg of Raw materialsl was Succesfully stored in the Factory");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("The AI will chose randomly an Offer");
                    choice = random.Next(1, 4);
                    break;
            }

        }
        private void FuctoryRunningCosts()
        {           

            // Stable Cost of Machinery used -> Marginal Cost also (MPC)
            double stableCosts = 0.02;
            double expences = 0;

            foreach (IEmployee iemployee in FactoryEmployees)
            {
                if(iemployee is FactoryEmployee factoryEmployee)
                {
                    // This expecne type is based on economic principal that the meployees are beeing payed according to their Marginal Prodcution
                    // The salary is not the monthly one, but the one they are payed for each time the proccess of production is triggered
                    expences += factoryEmployee.Salary + stableCosts;
                }                
            }
            // With this method, the factory wallet will suffer the cost of paying the employees
            F_Wallet.MakeTransaction(F_Wallet, (-expences));
        }
        public void F_MakeTransaction (Factory factory, double cost)
        {
            factory.F_Wallet.MakeTransaction(factory.F_Wallet, cost);           
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Factory Name: {this.Factory_Name}")
              .AppendLine($"Factory Address: {this.Factory_Address}")
              .AppendLine($"Factory Employees: {this.FactoryEmployees.Count}")
              .AppendLine($"Factory Available Money to Spend: {this.F_Wallet:N0}")
              .AppendLine($"Factory Available Money to Spend: {this.F_ChocolateStorage.Count}")
              .AppendLine($"Factory Stored Raw Materials: {this.F_MaterialsKg:N0} kg");

            return sb.ToString();
        }

    }
}
