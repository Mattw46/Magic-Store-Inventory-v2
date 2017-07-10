using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class InventoryList
{
    List<InventoryItem> list;

    public InventoryList(string JsonText)
	{
        list = JsonConvert.DeserializeObject<List<InventoryItem>>(JsonText);
    }

    public void PrintItems()
    {
        string header = $"{"ID",-5}{"Product",-25}{"CurrentStock",-25}";
        Console.WriteLine(header);
        foreach (var item in list)
        {
            string line = $"{item.Id,-5}{item.Name,-25}{item.StockLevel,-25}";
            Console.WriteLine(line);
        }
    }

    public void Restock(int id, int qty)
    {
        foreach (var item in list)
        {
            if (item.Id == id)
            {
                item.ReStock(qty);
                return;
            }
        }
    }

    /* Direct access to list
       should only be used in limite situations */
    public List<InventoryItem> GetInventoryList()
    {
        return list;
    }

    public void WriteToFile(string filename)
    {
        //JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = JsonConvert.SerializeObject(list);
        JsonReader jsr = new JsonReader();
        jsr.WriteFile(jsonString, filename);
    }
}
