using System;

public class CustomerMenuDriver
{
    bool CurrentMenu;

    public CustomerMenuDriver()
    {
        CurrentMenu = true;
    }

    public bool RunMenu()
    {
        bool exit = false;
        CustomerMenu cm = new CustomerMenu();

        while (CurrentMenu)
        {
            int input = cm.GetMenuItem();

            switch (input)
            {
                case 1:
                    DisplayAllItems();
                    break;
                case 2:
                    BookWorkshop();
                    break;
                case 3:
                    CurrentMenu = false;
                    break;
                case 4:
                    CurrentMenu = false;
                    exit = true;
                    break;
            }
        }
        return exit;
    }

    public void DisplayAllItems()
    {
        Console.WriteLine("display all items");
        Console.ReadLine();
    }

    public void BookWorkshop()
    {
        Console.WriteLine("book workshop");
        Console.ReadLine();
    }
}
