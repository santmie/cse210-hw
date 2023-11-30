using System;
using System.Collections.Generic;
using System.IO;

public class SaveLoad
{
    private const string _laptop = "Laptop";
    private const string _cpu = "CPU";
    private const string _monitor = "Monitor";

    public void SaveData(string fileName, int totalLaptopQuantity, int totalCPUQuantity, int totalMonitorQuantity,  List<AssetManager> assetList)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Total Laptop,Total CPU,Total Monitor"); //skip the 1st line
                writer.WriteLine($"{totalLaptopQuantity},{totalCPUQuantity},{totalMonitorQuantity}");

                writer.WriteLine("Asset Name,Asset Type,Requested Quantity");; //skip the 3rd line

                foreach (AssetManager asset in assetList)
                {
                    string assetLine = GetAssetLine(asset);
                    writer.WriteLine(assetLine);
                }
            }

            Console.WriteLine($"Assets saved to {fileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving assets: {ex.Message}");
        }
    }

    private string GetAssetLine(AssetManager asset)
    {
        return $"{asset.GetAssetName()},{asset.GetAssetType()},{asset.GetAssetQuantity()}";
    }

public void LoadData(string fileName, ref int totalLaptopQuantity, ref int totalCPUQuantity, ref int totalMonitorQuantity,List<AssetManager> assetList, Program program)
{
    try
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            // Read the first three lines to skip the header

            string firstLine = reader.ReadLine(); //skip the 1st line

            string secondLine = reader.ReadLine();
            string[] totalQuantities = secondLine.Split(',');


            string thirdLine = reader.ReadLine(); //skip the 3rd line

            
            totalLaptopQuantity = int.Parse(totalQuantities[0]);
            totalCPUQuantity = int.Parse(totalQuantities[1]);
            totalMonitorQuantity = int.Parse(totalQuantities[2]);

            assetList.Clear();

            while (!reader.EndOfStream)
            {
                string assetLine = reader.ReadLine();
                string[] assetProperties = assetLine.Split(',');

                ParseAsset(assetProperties, assetList, totalLaptopQuantity, totalCPUQuantity, totalMonitorQuantity);
            }

            Console.WriteLine();
            Console.WriteLine($"--- Assets loaded from {fileName}.---");
            Console.WriteLine();
            
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error loading assets: {ex.Message}");
    }
}


private void ParseAsset(string[] assetProperties, List<AssetManager> assetList, int totalLaptopQuantity, int totalCPUQuantity, int totalMonitorQuantity)
{
    try
    {
        if (assetProperties.Length < 3)
        {
            Console.WriteLine("Invalid asset data: Insufficient data");
            return;
        }

        string assetName = assetProperties[0];
        string assetType = assetProperties[1];

        if (!int.TryParse(assetProperties[2], out int assetQuantity))
        {
            Console.WriteLine($"Invalid quantity for {assetName}: {assetProperties[2]}");
            return;
        }

        assetList.Add(new Laptop(assetName, assetType, assetQuantity, totalLaptopQuantity));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error parsing asset: {ex.Message}");
    }

}
}