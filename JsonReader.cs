using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class JsonReader
{
	public JsonReader()
	{
	}

    public object ReadInventoryFile(string filename)
    {
        try { 
            var file = File.ReadAllText(filename);
            Console.WriteLine(file.ToString());
            InventoryList il = new InventoryList(file);
            return il;
        }
        catch(FileNotFoundException)
        {
            return null;
        }
        
    }

    public object ReadRequestFile(string filename)
    {
        try
        {
            var file = File.ReadAllText(filename);
            StockRequestList srl = new StockRequestList(file);
            return srl;
        }
        catch (FileNotFoundException)
        {
            return null;
        }

    }

    public void WriteFile(string jsonString, string filename)
    {
        try { 
            File.WriteAllText(filename,jsonString);
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("Unable to write to: " + filename + 
                " The update has not been saved");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
