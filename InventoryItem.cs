using System;

public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StockLevel { get; set; }

    public InventoryItem()
	{
	}

    public void ReStock(int qty)
    {
        // ensure not negative stock count
        if (qty > 0)
        {
            StockLevel = StockLevel + qty;
        }
    }
}
