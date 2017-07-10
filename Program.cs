using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            bool exit = false;

            /* While current menu running and last called menu 
               not return true for exit */
            while (running && !exit)
            {
                MainMenu main = new MainMenu();
                //main.PrintMenu();
                int input = main.GetMenuItem();

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Calling Owner menu");
                        OwnerMenuDriver omd = new OwnerMenuDriver();
                        exit = omd.RunMenu();
                        break;
                    case 2:
                        Console.WriteLine("Calling Franchise menu");
                        FranchiseMenuDriver fmd = new FranchiseMenuDriver();
                        exit = fmd.RunMenu();
                        break;
                    case 3:
                        Console.WriteLine("Calling Customer menu");
                        CustomerMenuDriver cmd = new CustomerMenuDriver();
                        exit = cmd.RunMenu();
                        break;
                    case 4:
                        // set running to exit
                        running = false;
                        break;
                }
            }

            runTests();
        }

        public static void runTests()
        {
            /* Testing Code starts here */
            InventoryItem ii = new InventoryItem();
            ii.Id = 1;
            ii.Name = "Rabbit";
            ii.StockLevel = 5;

            Console.WriteLine(ii.StockLevel);
            ii.ReStock(5);
            Console.WriteLine(ii.StockLevel);
            ii.ReStock(-1);
            Console.WriteLine(ii.StockLevel);

            JsonReader jsr = new JsonReader();
            InventoryList il = (InventoryList)jsr.ReadInventoryFile("JSON\\owner_inventory.json");

            try
            {
                il.PrintItems();
                Console.WriteLine("\n");
                il.Restock(1, 5);
                il.PrintItems();
                //il.WriteToFile("JSON\\owner_inventory.json");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Invalid reference return");
            }

            /* Test Stock Requests */
            StockRequestList srl = (StockRequestList)jsr.ReadRequestFile("JSON\\stockRequests.json");
            try
            {
                srl.PrintItems();
                Console.WriteLine("\nprint filtered\n");
                srl.PrintFilteredItems(true);
                Console.WriteLine("\nattempt process request 1\n");
                srl.ProcessRequest(1);
                /*srl.PrintItems();*/
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Invalid reference return");
            }

            //JsonReader js = new JsonReader();

            Console.ReadLine();
            /* Testing Code ends here*/
        }
    }
}
