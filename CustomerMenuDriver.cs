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
        OwnerMenu om = new OwnerMenu();

        while (CurrentMenu)
        {
            int input = om.GetMenuItem();

            switch (input)
            {
                case 1:
                    // call something
                    Console.WriteLine("Calling option 1");
                    break;
                case 2:
                    Console.WriteLine("Calling option 2");
                    break;
                case 3:
                    Console.WriteLine("Calling option 3");
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
}
