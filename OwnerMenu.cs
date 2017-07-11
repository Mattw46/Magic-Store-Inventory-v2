using System;

public class OwnerMenu : Screen
{
    int maxItems;

    public OwnerMenu()
    {
        maxItems = 5;
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

    }

    public void DisplayFilteredStockRequests()
    {

    }

    public void DisplayPoducts()
    {
        JsonReader jsr = new JsonReader();
        InventoryList il = (InventoryList)jsr.ReadInventoryFile("JSON\\owner_inventory.json");
        //InventoryList il = new InventoryList();
        il.PrintItems();
        Console.ReadLine();
    }
}