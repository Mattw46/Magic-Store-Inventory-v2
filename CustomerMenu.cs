using System;

public class CustomerMenu : Screen
{
    int maxItems;

    public CustomerMenu()
    {
        maxItems = 4;
    }

    public override int GetMenuItem()
    {
        return GetMenuInput(maxItems);
    }

    protected override void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Marvellous Magic");
        Console.WriteLine("======================================\n");
        Console.WriteLine("      1.    Display Products\n");
        Console.WriteLine("      2.    Display Workshops\n");
        Console.WriteLine("      3.    Return to Main Menu\n");
        Console.WriteLine("      4.    Exit\n\n");
        Console.WriteLine("Enter an option:");
    }
}
