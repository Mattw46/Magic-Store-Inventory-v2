using System;

public class FranchiseMenuDriver
{
    bool CurrentMenu;

    public FranchiseMenuDriver()
    {
        CurrentMenu = true;
    }

    public bool RunMenu()
    {
        bool exit = false;
        //OwnerMenu om = new OwnerMenu();
        FranchiseMenu fm = new FranchiseMenu();

        while (CurrentMenu)
        {
            int input = fm.GetMenuItem();

            switch (input)
            {
                case 1:
                    DisplayInventory();
                    Console.ReadLine();
                    break;
                case 2:
                    //DisplayInventoryThreshold dit = new DisplayInventoryThreshold();
                    //dit.ProcessRequests();
                    break;
                case 3:
                    //AddNewInventoryItem AddNew = new AddNewInventoryItem();
                    //AddNew.ProcessRequests();
                    break;
                case 4:
                    CurrentMenu = false;
                    break;
                case 5:
                    CurrentMenu = false;
                    exit = true;
                    break;
            }
        }
        return exit;
    }

    public void DisplayInventory()
    {
        InventoryList list = null;
        while (list == null)
        {
            string storeFile = GetStore();
            Console.WriteLine("File is: " + storeFile);
            list = GetInventoryList(storeFile);
            Console.ReadLine();
        }
        int threshold = GetThreshold();
        list.PrintFranchiseItems(threshold);
    }

    public void DisplayInvenotryThreshold()
    {
        JsonReader jsr = new JsonReader();
        InventoryList il = (InventoryList)jsr.ReadInventoryFile("JSON\\owner_inventory.json");
    }

    public void AddNewInvenotry()
    {
        JsonReader jsr = new JsonReader();
        InventoryList il = (InventoryList)jsr.ReadInventoryFile("JSON\\owner_inventory.json");
    }

    /* prompts user for store name
       returns file name for store inventory*/
    public string GetStore()
    {
        Console.Clear();
        Console.WriteLine("Enter Store Name");
        string store = Console.ReadLine();
        return "JSON\\" + store + "_Franchise_Inventory.json";
    }

    public InventoryList GetInventoryList(string storeFile)
    {
        JsonReader jsr = new JsonReader();
        InventoryList il = (InventoryList)jsr.ReadInventoryFile(storeFile);
        return il;
    }

    public int GetThreshold()
    {
        bool notValid = true;
        int threshold = 0;
        while (notValid)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter threshold for low stock:");
                threshold = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, only numbers accepted\npress any key to continue");
                Console.ReadLine();
            }
            notValid = false;
        }
        return threshold;
    }
}
