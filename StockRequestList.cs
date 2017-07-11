using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class StockRequestList
{
    List<StockRequest> list;
    InventoryList inventory;
    JsonReader jsr;
     
    public StockRequestList(string JsonText)
    {
        //Console.WriteLine(JsonText);
        list = JsonConvert.DeserializeObject<List<StockRequest>>(JsonText);

        jsr = new JsonReader();
        inventory = (InventoryList) jsr.ReadInventoryFile("JSON\\owner_inventory.json");
    }

    public void PrintItems()
    {
        PrintHeader();

        foreach (var item in list)
        {
            string line = $"{item.Id,-5}{item.Store,-15}{item.Product,-20}{item.Quantity,-25}{item.GetCurrentStock(),-25}{item.GetAvailability(),-15}";
            Console.WriteLine(line);
        }
    }

    public void PrintFilteredItems(bool filter)
    {
        PrintHeader();

        foreach (var item in list)
        {
            if (item.GetAvailability() == filter)
            { 
            string line = $"{item.Id,-5}{item.Store,-15}{item.Product,-20}{item.Quantity,-25}{item.GetCurrentStock(),-25}{item.GetAvailability(),-15}";
            Console.WriteLine(line);
            }
        }
    }

    public void PrintHeader()
    {
        string header = $"{"ID",-5}{"Store",-15}{"Product",-20}{"Quantity",-25}{"Current Stock",-25}{"Stock Availability",-15}";
        Console.WriteLine("Stock Requests\n\n");
        Console.WriteLine(header);
        Console.WriteLine(new string('=', header.Length));
    }

    public void ProcessRequest(int id)
    {
        StockRequest toRemove = null;

        foreach (var request in list) // interate stockRequests
       {
            if (request.Id == id && request.GetAvailability() == true)
            {
                // found correct stock request
                var il = inventory.GetInventoryList();
                foreach(var item in il)
                {
                    if (item.Name.Equals(request.Product))
                    {
                        toRemove = request;
                        // update store qty
                        UpdateStore(request);
                        // decrement owner qty
                        UpdateOwner(request);
                    }
                }
                
            }
        }
        list.Remove(toRemove);
        WriteStockRequest();
        //return false;
    }

    public void UpdateStore(StockRequest request)
    {
        Console.WriteLine("Update store: " + request.Store + " by " + request.Quantity);
        // open file
        string filename = "JSON\\" + request.Store + "_Franchise_Inventory.json";
        InventoryList StoreInventory = (InventoryList)jsr.ReadInventoryFile(filename);
        List<InventoryItem> list = StoreInventory.GetInventoryList();
        // update
        foreach (var item in list)
        {
            if (item.Name.Equals(request.Product))
            {
                Console.WriteLine("update: " + item.Id + " " + item.Name + " " + request.Quantity);
                item.ReStock(request.Quantity);
            }
        }
        
        // write
    }

    public void UpdateOwner(StockRequest request)
    {
        Console.WriteLine("update owner: product " + request.Product + " qty " + request.Quantity);
        // open file
        string filename = "JSON\\owner_inventory.json";
        InventoryList StoreInventory = (InventoryList)jsr.ReadInventoryFile(filename);
        List<InventoryItem> list = StoreInventory.GetInventoryList();
        // update
        foreach (var item in list)
        {
            if (item.Name.Equals(request.Product))
            {
                Console.WriteLine("update: " + item.Id + " " + item.Name + " " + item.StockLevel + " " + request.Quantity);
                item.StockLevel = item.StockLevel - request.Quantity;
            }
        }

        // write
    }

    public void WriteStockRequest()
    {
        string jsonString = JsonConvert.SerializeObject(list);
        JsonReader jsr = new JsonReader();
        jsr.WriteFile(jsonString, "JSON\\stockrequests.json");
    }
}
