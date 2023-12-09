using System;

// Class to manage asset quantities
public static class AssetQuantityManager
{
    // Method to get the total quantity for a specific asset type
    public static int GetTotalQuantity(
        string assetName, int totalLaptopQuantity, int totalCPUQuantity, int totalMonitorQuantity,
        int totalHeadsetQuantity, int totalWebcamQuantity, int totalMouseQuantity,
        int totalKeyboardQuantity, int totalInternetQuantity) =>
        assetName switch
        {
            "Laptop" => totalLaptopQuantity,
            "CPU" => totalCPUQuantity,
            "Monitor" => totalMonitorQuantity,
            "Headset" => totalHeadsetQuantity,
            "Webcam" => totalWebcamQuantity,
            "Mouse" => totalMouseQuantity,
            "Keyboard" => totalKeyboardQuantity,
            "Internet Connectivity" => totalInternetQuantity,
            _ => throw new ArgumentOutOfRangeException(nameof(assetName)),
        };

    // Method to update the total quantity for a specific asset type
    public static void UpdateTotalQuantity(
        string assetName, int assetQuantity, ref int totalLaptopQuantity, ref int totalCPUQuantity,
        ref int totalMonitorQuantity, ref int totalHeadsetQuantity, ref int totalWebcamQuantity,
        ref int totalMouseQuantity, ref int totalKeyboardQuantity, ref int totalInternetQuantity)
    {
        switch (assetName)
        {
            case "Laptop": totalLaptopQuantity += assetQuantity; break;
            case "CPU": totalCPUQuantity += assetQuantity; break;
            case "Monitor": totalMonitorQuantity += assetQuantity; break;
            case "Headset": totalHeadsetQuantity += assetQuantity; break;
            case "Webcam": totalWebcamQuantity += assetQuantity; break;
            case "Mouse": totalMouseQuantity += assetQuantity; break;
            case "Keyboard": totalKeyboardQuantity += assetQuantity; break;
            case "Internet Connectivity": totalInternetQuantity += assetQuantity; break;
            default: throw new ArgumentOutOfRangeException(nameof(assetName));
        }
    }
}
