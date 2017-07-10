using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class StockRequestList
{
    List<StockRequest> list;
    JsonReader jsr;
     
    public StockRequestList(string JsonText)
    {
        //Console.WriteLine(JsonText);
        list = JsonConvert.DeserializeObject<List<StockRequest>>(JsonText);

        jsr = new JsonReader();
    }

    public void PrintItems()
    {
        PrintHeader();

        foreach (var item in list)
        {
            string line = $"{item.Id,-5}{item.Store,-15}{item.Product,-20}{item.Quantity,-25}{item.CurrentStock,-25}{item.GetAvailability(),-15}";
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
            string line = $"{item.Id,-5}{item.Store,-15}{item.Product,-20}{item.Quantity,-25}{item.CurrentStock,-25}{item.GetAvailability(),-15}";
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

    public bool ProcessRequest(int id)
    {
        InventoryList il = (InventoryList) jsr.ReadInventoryFile("JSON\\owner_inventory.json");
        List<InventoryItem> ownerInventory = il.GetInventoryList();
        
        foreach (var item in list) // loop through stock requests
        {
            // if current item was selected and available
            if (item.Id == id && item.GetAvailability() == true)
            {
                // loop through owners inventory
                foreach(var product in ownerInventory)
                {
                    // if current item has same name as select request
                    if(product.Name.Equals(item.Product))
                    {
                        // deduct quantity requested from owners inventory
                        product.StockLevel = product.StockLevel - item.Quantity;
                    }
                }
                string jsonString = JsonConvert.SerializeObject(ownerInventory);
                //jsr.WriteFile(jsonString, "JSON\\owner_inventory.json");

                // add to store inventory
                string filename = "JSON\\" + item.Store + "_Franchise_Inventory.json";
                Console.WriteLine("filename: " + filename);

                InventoryList receivingStore = (InventoryList)jsr.ReadInventoryFile(filename);
                List<InventoryItem> store = receivingStore.GetInventoryList();

                // loop to find poduct and call restock
                foreach(var product in store)
                {
                    if(product.Name == item.Product)
                    {
                        product.ReStock(item.Quantity);
                    }
                }
                jsonString = JsonConvert.SerializeObject(store);
                jsr.WriteFile(jsonString, filename);

                // remove stock request
                list.Remove(item);
                jsonString = JsonConvert.SerializeObject(store);
                jsr.WriteFile(jsonString, "JSON\\stockRequests.json");
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public void WriteToFile(string filename)
    {
        string jsonString = JsonConvert.SerializeObject(list);
        JsonReader jsr = new JsonReader();
        jsr.WriteFile(jsonString, filename);
    }
}
