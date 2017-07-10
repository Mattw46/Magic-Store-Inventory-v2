using System;

public class MainMenu : Screen
{
    //const int InvalidInputFormat = -1;
    int maxItems;

    public MainMenu()
    {
        maxItems = 4;
    }

    public override int GetMenuItem()
    {
        return GetMenuInput(maxItems);
    }

    protected override void PrintMenu() // consider calling abstract method of create interface
    {
        Console.Clear();
        Console.WriteLine("Welcome to Marvellous Magic");
        Console.WriteLine("======================================\n");
        Console.WriteLine("      1.    Owner\n");
        Console.WriteLine("      2.    Franchise Owner\n");
        Console.WriteLine("      3.    Customer\n");
        Console.WriteLine("      4.    Quit\n\n");
        Console.WriteLine("Enter an option:");
    }

}
