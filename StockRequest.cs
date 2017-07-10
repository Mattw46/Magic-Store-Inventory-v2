using System;
using System.Collections.Generic;

public class StockRequest
{
    public int Id { get; set; }
    public string Store { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    //public int CurrentStock { get; set; }
    //public int CurrentStock;

    public StockRequest()
	{
        // Get stock level from Owner_inventory
        //this.CurrentStock = GetCurrentStock();

        //Console.WriteLine("Current stock: " + CurrentStock);
    }

    public bool GetAvailability()
    {
        if (Quantity > GetCurrentStock())
        {
            return false;
        }

        return true;
    }

    // 0 returned if no match found
    public int GetCurrentStock()
    {
        JsonReader jsr = new JsonReader();
        InventoryList il = (InventoryList) jsr.ReadInventoryFile("JSON\\owner_inventory.json");
        List<InventoryItem> list = il.GetInventoryList();
        foreach (var item in list)
        {
            //Console.WriteLine(item.Id + " == " + Id);
            if (item.Id == this.Id)
            {
                return item.StockLevel;
            }
        }

        return 0;
    }
}
