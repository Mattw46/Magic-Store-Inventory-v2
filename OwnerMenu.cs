using System;

public class OwnerMenu : Screen
{
    int maxItems;
    JsonReader jsr;

    public OwnerMenu()
    {
        maxItems = 5;
        jsr = new JsonReader();
    }

    public override int GetMenuItem()
    {
        return GetMenuInput(maxItems);
    }

    protected override void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Marvellous Magic (Owner)");
        Console.WriteLine("======================================\n");
        Console.WriteLine("      1.    Display All Stock Requests\n");
        Console.WriteLine("      2.    Display Stock Requests (True/False)\n");
        Console.WriteLine("      3.    Display All Product Lines\n");
        Console.WriteLine("      4.    Return to Main Menu\n");
        Console.WriteLine("      5.    Exit\n\n");
        Console.WriteLine("Enter an option:");
    }

    // testing below

    public void DisplayStockRequests()
    {
        bool running = true;
        StockRequestList srl = (StockRequestList)jsr.ReadRequestFile("JSON\\stockRequests.json");

        while (running)
        {
            Console.Clear();
            srl.PrintItems();
            int selected = GetInput();
            if (selected > 0 && selected <= (srl.GetListSize() + 1))
            {
                // process
                srl.ProcessRequest(selected);
            }
            else if (selected == -1)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid input try again\npress eny key to continue:");
                Console.ReadLine();
            }
        }
    }

    public void DisplayFilteredStockRequests()
    {
        bool filter;
        filter = GetBoolInput();

        bool running = true;
        StockRequestList srl = (StockRequestList)jsr.ReadRequestFile("JSON\\stockRequests.json");

        while (running)
        {
            Console.Clear();
            srl.PrintItems();
            int selected = GetInput();
            if (selected > 0 && selected <= (srl.GetListSize() + 1))
            {
                // process
                //srl.ProcessRequest(selected);
                srl.PrintFilteredItems(filter);
            }
            else if (selected == -1)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid input try again\npress eny key to continue:");
                Console.ReadLine();
            }
        }
    }

    public void DisplayPoducts()
    {
        JsonReader jsr = new JsonReader();
        InventoryList il = (InventoryList)jsr.ReadInventoryFile("JSON\\owner_inventory.json");
        //InventoryList il = new InventoryList();
        il.PrintItems();
        Console.WriteLine("\nPress Any Key To Continue\n");
        Console.ReadLine();
    }
}