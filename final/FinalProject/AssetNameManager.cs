using System;
using System.Collections.Generic;

// Class to manage asset names and details
public static class AssetNameManager
{
    // Display details of the asset, including specific details for different asset types
    public static void DisplayAssetDetails(BaseAssetManager asset, string assetType, int assetQuantity)
    {
        string details;

        if (asset is Laptop laptop)
        {
            details = $"< Type = {assetType} , Quantity = {assetQuantity}, Processor = {laptop._processor}, RAM = {laptop._ram}, Storage Capacity = {laptop._storageCapacity} >";
        }
        else if (asset is CPU cpu)
        {
            details = $"< Type = {assetType} , Quantity = {assetQuantity}, Processor = {cpu._processor}, RAM = {cpu._ram}, Storage Capacity = {cpu._storageCapacity} >";
        }
        else if (asset is Monitor monitor)
        {
            details = $"< Type = {assetType} , Quantity = {assetQuantity}, Monitor Size = {monitor._sizeMonitor} >";
        }
        else
        {
            details = $"< Type = {assetType} , Quantity = {assetQuantity} >";
        }

        Console.WriteLine(details);
    }

    // Get asset name, quantity, and type from user input
    public static void UseAssetName(string assetName, out string assetType, out int assetQuantity)
    {
        Console.Write($"What is the quantity required with this {assetName}? ");
        assetQuantity = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"Select {assetName} types:");

        List<string> options = GetAssetOptions(assetName);
        DisplayAssetOptions(options);
        assetType = GetUserSelection(options);
    }

    // Display asset options to the user
    public static void DisplayAssetOptions(List<string> options)
    {
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($" {i + 1}. {options[i]}");
        }
    }

    // Get user selection from displayed options
    public static string GetUserSelection(List<string> options)
    {
        int selection = GetValidUserSelection(options.Count);
        return options[selection - 1];
    }

    // Get available options for a specific asset
    public static List<string> GetAssetOptions(string assetName)
    {
        return assetName switch
        {
            "Laptop" => new List<string> { "Standard", "Non Standard", "Macbook Pro", "Macbook Air" },
            "CPU" => new List<string> { "Standard", "Non Standard", "Macmini-Care", "Macmini-RCC", "iMac" },
            "Monitor" => new List<string> { "Single Monitor", "Dual Monitor" },
            "Headset" => new List<string> { "USB", "QD" },
            "Webcam" or "Mouse" or "Keyboard" => new List<string> { "USB", "Wireless" },
            "Internet Connectivity" => new List<string> { "Wired LAN", "Wireless (Wi-Fi)" },
            _ => throw new ArgumentOutOfRangeException(nameof(assetName)),
        };
    }

    // Get valid user selection within the specified range
    public static int GetValidUserSelection(int maxOption)
    {
        int selection;
        while (true)
        {
            Console.Write("Enter the number corresponding to your selection: ");
            if (int.TryParse(Console.ReadLine(), out selection) && selection >= 1 && selection <= maxOption)
            {
                break;
            }
            else
            {
                Console.WriteLine("<< Invalid selection. Please try again. >>");
            }
        }

        return selection;
    }
}
