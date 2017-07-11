using System;
using System.Collections.Generic;

public class StockRequest
{
    public int Id { get; set; }
    public string Store { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }

    public StockRequest()
	{
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
            if (item.Id == this.Id)
            {
                return item.StockLevel;
            }
        }

        return 0;
    }
}
