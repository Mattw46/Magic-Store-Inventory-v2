using System;

public abstract class Screen
{
    protected const int InvalidInputFormat = -1;
    private int maxItems;

    protected abstract void PrintMenu();

    public abstract int GetMenuItem();

    protected int GetMenuInput(int lastItem)
    {
        bool valid = false;
        int input = 0;
        string errorString = "";

        while (!valid)
        {
            // print menu
            PrintMenu();
            if (errorString.Length > 0) { Console.WriteLine(errorString); }

            // get valid input
            input = GetInput();

            if (input >= 1 && input <= lastItem)
            {
                valid = true;
            }
            else if (input == InvalidInputFormat)
            {
                errorString = "\nInvalid input, only numbers allowed\nEnter an option:";
            }
            else
            {
                errorString = "Invalid numuber try again";
            }
        }

        return input;
    }

    /* returns -1 if enter pressed without input
       this indicates to exit */
    public int GetInput()
    {
        int number = 0;

        try
        {
            string input = Console.ReadLine();
            if (input.Equals(""))
            {
                return -1;
            }
            number = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid input");
            return InvalidInputFormat;
        }
        return number;
    }

    public bool GetBoolInput()
    {

        bool validInput = false;
        bool result = false;
        while (!validInput)
        {
            Console.Clear();
            Console.WriteLine("Enter Filter to use True or False");
            string input = Console.ReadLine();

            switch (input)
            {
                case "TRUE":
                    return true;
                case "T":
                    return true;
                case "True":
                    return true;
                case "true":
                    return true;
                case "FALSE":
                    return false;
                case "F":
                    return false;
                case "False":
                    return false;
                case "false":
                    return false;
                default:
                    Console.WriteLine("Invalid input: please retry\nPress any key to continue");
                    Console.ReadLine();
                    break;
        }
        }
        

        return result;
    }
}
