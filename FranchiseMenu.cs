using System;

public class FranchiseMenu : Screen
{
    int maxItems;

    public FranchiseMenu()
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
        Console.WriteLine("Welcome to Marvellous Magic (Franchise Holder - name)");
        Console.WriteLine("======================================\n");
        Console.WriteLine("      1.    Display Inventory\n");
        Console.WriteLine("      2.    Display Inventory (Threshold)\n");
        Console.WriteLine("      3.    Add New Inventory Item\n");
        Console.WriteLine("      4.    Return to Main Menu\n");
        Console.WriteLine("      5.    Exit\n\n");
        Console.WriteLine("Enter an option:");
    }
}
