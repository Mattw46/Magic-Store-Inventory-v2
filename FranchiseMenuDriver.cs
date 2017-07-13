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
                    DisplayInvenotryThreshold();
                    Console.ReadLine();
                    break;
                case 3:
                    AddNewInvenotry();
                    Console.ReadLine();
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
            list = GetInventoryList(storeFile);
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
        bool validStore = false;
        string store = "";

        while (!validStore)
        {
            Console.Clear();
            Console.WriteLine("Enter Store Name");
            store = Console.ReadLine();
            if (ValidateStore(store))
            {
                validStore = true;
            }
        }
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

    public bool ValidateStore(string input)
    {
        switch (input)
        {
            case "CBD":
                return true;
            case "North":
                return true;
            case "South":
                return true;
            case "West":
                return true;
            case "Olinda":
                return true;
        }
        return false;
    }
}
