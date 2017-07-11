using System;

public class OwnerMenuDriver
{
    bool CurrentMenu;

    public OwnerMenuDriver()
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
                    om.DisplayStockRequests();
                    //DisplayAllStockRequests stockRequests = new DisplayAllStockRequests();
                    //stockRequests.ProcessRequests();
                    break;
                case 2:
                    om.DisplayFilteredStockRequests();
                    //DisplayAllStockRequests filteredStockRequests = new DisplayAllStockRequests();
                    //filteredStockRequests.ProcessFilteredRequests();
                    break;
                case 3:
                    om.DisplayPoducts();
                    //DisplayProductLines dpl = new DisplayProductLines();
                    //dpl.ProcessRequests();
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
