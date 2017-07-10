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

    protected int GetInput()
    {
        int number = 0;

        try
        {
            number = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("invalid input");
            return InvalidInputFormat;
        }
        return number;
    }
}
