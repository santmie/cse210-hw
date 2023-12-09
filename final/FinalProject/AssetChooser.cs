using System;
using System.Collections.Generic;

// Class to choose, declare, and add assets
public class AssetChooser
{
    // Method to display available asset types
    public static void DisplayAssetTypes() =>
        Console.WriteLine(" 1. Laptop\n 2. CPU\n 3. Monitor\n 4. Headset\n 5. Webcam\n 6. Mouse\n 7. Keyboard\n 8. Internet Connectivity");

    // Method to get asset name based on user choice
    public static string GetAssetName(int assetChoice) =>
        assetChoice switch
        {
            1 => "Laptop",
            2 => "CPU",
            3 => "Monitor",
            4 => "Headset",
            5 => "Webcam",
            6 => "Mouse",
            7 => "Keyboard",
            8 => "Internet Connectivity",
            _ => throw new ArgumentOutOfRangeException(nameof(assetChoice)),
        };

    // Method to declare and add a new asset to the list
    public static void DeclareAndAddAsset(
        string assetName, List<BaseAssetManager> assetList,
        ref int totalLaptopQuantity, ref int totalCPUQuantity, ref int totalMonitorQuantity,
        ref int totalHeadsetQuantity, ref int totalWebcamQuantity, ref int totalMouseQuantity,
        ref int totalKeyboardQuantity, ref int totalInternetQuantity,
        out string assetType, out int assetQuantity)
    {
        AssetNameManager.UseAssetName(assetName, out assetType, out assetQuantity);

        // Create a new asset based on the asset name and type
        BaseAssetManager newAsset = AssetTypeManager.CreateAsset(assetName, assetType, assetQuantity,
            AssetQuantityManager.GetTotalQuantity(assetName, totalLaptopQuantity, totalCPUQuantity, totalMonitorQuantity,
            totalHeadsetQuantity, totalWebcamQuantity, totalMouseQuantity, totalKeyboardQuantity, totalInternetQuantity));

        // Add the new asset to the list
        assetList.Add(newAsset);

        // Update the total quantity for the specific asset type
        AssetQuantityManager.UpdateTotalQuantity(assetName, assetQuantity, ref totalLaptopQuantity, ref totalCPUQuantity,
            ref totalMonitorQuantity, ref totalHeadsetQuantity, ref totalWebcamQuantity,
            ref totalMouseQuantity, ref totalKeyboardQuantity, ref totalInternetQuantity);

        Console.WriteLine($"== {assetName} request has been successfully added to the list. ==");

        // Display asset details
        AssetNameManager.DisplayAssetDetails(newAsset, assetType, assetQuantity);
    }
}
