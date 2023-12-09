using System;
using System.Collections.Generic;

// Class to manage creation of different asset types
public static class AssetTypeManager
{
    // Default values for standard Laptop and CPU assets
    private const string _defaultProcessorImac = "M1 Chipset";
    private const string _defaultProcessor = "i5";
    private const string _defaultRAM = "16G";
    private const string _defaultStorageCapacity = "256GB";

    // Method to create an asset based on asset type and name
    public static BaseAssetManager CreateAsset(
        string assetName, string assetType, int assetQuantity, int totalQuantity)
    {
        return assetName switch
        {
            // Standard Laptop and CPU
            "Laptop" or "CPU" when assetType == "Standard" => CreateStandardAsset(assetName, assetType, assetQuantity, totalQuantity),

            // Non-standard Laptop and CPU
            "Laptop" or "CPU" when assetType == "Non Standard" => CreateNonStandard(assetName, assetType, assetQuantity, totalQuantity),

            // Mac Laptop and CPU
            "Laptop" or "CPU" when IsMacAssetType(assetType) => CreateMacAsset(assetName, assetType, assetQuantity, totalQuantity),

            // Monitors and other peripheral assets
            "Monitor" => CreateMonitor(assetName, assetType, assetQuantity, totalQuantity),
            "Headset" or "Webcam" or "Mouse" or "Keyboard" or "Internet Connectivity" => CreatePeripheralAsset(assetName, assetType, assetQuantity, totalQuantity),

            // Invalid asset type
            _ => throw new InvalidOperationException("<< Invalid asset type. Please try again. >>")
        };
    }

    // Check if the asset type is a Mac
    private static bool IsMacAssetType(string assetType)
    {
        switch (assetType)
        {
            case "Macbook Pro":
            case "Macbook Air":
            case "Macmini-Care":
            case "Macmini-RCC":
            case "iMac":
                return true;
            default:
                return false;
        }
    }

    // Method to create peripheral assets (headset, webcam, mouse, keyboard, internet connectivity)
    private static BaseAssetManager CreatePeripheralAsset(
        string assetName, string assetType, int assetQuantity, int totalQuantity)
    {
        return assetName switch
        {
            "Headset" => new Headset(assetName, assetType, assetQuantity, totalQuantity),
            "Webcam" => new Webcam(assetName, assetType, assetQuantity, totalQuantity),
            "Mouse" => new Mouse(assetName, assetType, assetQuantity, totalQuantity),
            "Keyboard" => new Keyboard(assetName, assetType, assetQuantity, totalQuantity),
            "Internet Connectivity" => new InternetConnectivity(assetName, assetType, assetQuantity, totalQuantity),
            _ => throw new InvalidOperationException("<< Invalid asset type. Please try again. >>")
        };
    }

    // Method to create standard assets (laptop and CPU)
    private static BaseAssetManager CreateStandardAsset(
        string assetName, string assetType, int assetQuantity, int totalQuantity)
    {
        return assetName switch
        {
            "Laptop" => new Laptop(assetName, assetType, assetQuantity, totalQuantity, _defaultProcessor, _defaultRAM, _defaultStorageCapacity),
            "CPU" => new CPU(assetName, assetType, assetQuantity, totalQuantity, _defaultProcessor, _defaultRAM, _defaultStorageCapacity),
            _ => throw new InvalidOperationException("<< Invalid asset type. Please try again. >>")
        };
    }

    // Method to create non-standard laptop and CPU
    private static BaseAssetManager CreateNonStandard(
        string assetName, string assetType, int assetQuantity, int totalQuantity)
    {
        List<string> processorOptions = new List<string> { "i5", "i7" };
        List<string> ramOptions = new List<string> { "16G", "32G" };
        List<string> storageOptions = new List<string> { "256GB", "500GB" };

        return assetName switch
        {
            "Laptop" => new Laptop(assetName, assetType, assetQuantity, totalQuantity,
                GetValidOption(processorOptions, "Processor"),
                GetValidOption(ramOptions, "RAM"),
                GetValidOption(storageOptions, "Storage Capacity")),
            "CPU" => new CPU(assetName, assetType, assetQuantity, totalQuantity,
                GetValidOption(processorOptions, "Processor"),
                GetValidOption(ramOptions, "RAM"),
                GetValidOption(storageOptions, "Storage Capacity")),
            _ => throw new InvalidOperationException("<< Invalid asset type. Please try again. >>")
        };
    }

    // Method to create Mac Laptop and CPU
    private static BaseAssetManager CreateMacAsset(
        string assetName, string assetType, int assetQuantity, int totalQuantity)
    {
        List<string> ramOptions = new List<string> { "16G", "32G" };
        List<string> storageOptions = new List<string> { "256GB", "500GB" };

        return assetName switch
        {
            "Laptop" => new Laptop(assetName, assetType, assetQuantity, totalQuantity,
                _defaultProcessorImac,
                GetValidOption(ramOptions, "RAM"),
                GetValidOption(storageOptions, "Storage Capacity")),
            "CPU" => new CPU(assetName, assetType, assetQuantity, totalQuantity,
                _defaultProcessorImac,
                GetValidOption(ramOptions, "RAM"),
                GetValidOption(storageOptions, "Storage Capacity")),
            _ => throw new InvalidOperationException("<< Invalid asset type. Please try again. >>")
        };
    }

    // Method to create monitor assets
    private static BaseAssetManager CreateMonitor(
        string assetName, string assetType, int assetQuantity, int totalQuantity)
    {
        List<string> sizeOptions = new List<string> { "18.5", "19", "21.5", "24", "27" };

        return new Monitor(assetName, assetType, assetQuantity, totalQuantity,
            GetValidOption(sizeOptions, "Monitor Size"));
    }

    // Method to get a valid user-selected option from a list
    private static string GetValidOption(List<string> options, string optionType)
    {
        Console.WriteLine($"Select {optionType}:");

        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($" {i + 1}. {options[i]}");
        }

        int selection = AssetNameManager.GetValidUserSelection(options.Count);
        return options[selection - 1];
    }
}
