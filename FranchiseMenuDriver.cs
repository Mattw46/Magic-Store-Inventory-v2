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
        OwnerMenu om = new OwnerMenu();

        while (CurrentMenu)
        {
            int input = om.GetMenuItem();

            switch (input)
            {
                case 1:
                    //DisplayInventory di = new DisplayInventory();
                    //di.ProcessRequests();
                    break;
                case 2:
                    //DisplayInventoryThreshold dit = new DisplayInventoryThreshold();
                    //dit.ProcessRequests();
                    break;
                case 3:
                    //AddNewInventoryItem AddNew = new AddNewInventoryItem();
                    //AddNew.ProcessRequests();
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
