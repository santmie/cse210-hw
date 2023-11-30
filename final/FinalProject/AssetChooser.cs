using System;

public class AssetChooser
{
    public static void DisplayAssetTypes() =>
        Console.WriteLine(" 1. Laptop\n 2. CPU\n 3. Monitor");

    public static string GetAssetName(int assetChoice) =>
        assetChoice switch
        {
            1 => "Laptop",
            2 => "CPU",
            3 => "Monitor",
            _ => throw new ArgumentOutOfRangeException(nameof(assetChoice)),
        };

    public static void DeclareAndAddAsset(string assetName, List<AssetManager> assetList, ref int totalLaptopQuantity, ref int totalCPUQuantity, ref int totalMonitorQuantity, out string assetType, out int assetQuantity)
    {
        UseAssetName(assetName, out assetType, out assetQuantity);

        assetList.Add(CreateAsset(assetName, assetType, assetQuantity, GetTotalQuantity(assetName, totalLaptopQuantity, totalCPUQuantity, totalMonitorQuantity)));

        UpdateTotalQuantity(assetName, assetQuantity, ref totalLaptopQuantity, ref totalCPUQuantity, ref totalMonitorQuantity);
        Console.WriteLine($"{assetQuantity} - {assetType} : {assetName} request has been successfully added to the list.");
    }

    private static void UseAssetName(string assetName, out string assetType, out int assetQuantity)
    {
        Console.Write($"What is the type of the {assetName}? ");
        assetType = Console.ReadLine();
        Console.Write($"What is the quantity required with this {assetName}? ");
        assetQuantity = int.Parse(Console.ReadLine());
    }

    private static int GetTotalQuantity(string assetName, int totalLaptopQuantity, int totalCPUQuantity, int totalMonitorQuantity) =>
        assetName switch
        {
            "Laptop" => totalLaptopQuantity,
            "CPU" => totalCPUQuantity,
            "Monitor" => totalMonitorQuantity,
            _ => throw new ArgumentOutOfRangeException(nameof(assetName)),
        };

    private static void UpdateTotalQuantity(string assetName, int assetQuantity, ref int totalLaptopQuantity, ref int totalCPUQuantity, ref int totalMonitorQuantity)
    {
        switch (assetName)
        {
            case "Laptop": totalLaptopQuantity += assetQuantity; break;
            case "CPU": totalCPUQuantity += assetQuantity; break;
            case "Monitor": totalMonitorQuantity += assetQuantity; break;
            default: throw new ArgumentOutOfRangeException(nameof(assetName));
        }
    }

    private static AssetManager CreateAsset(string assetName, string assetType, int assetQuantity, int totalQuantity) =>
        assetName switch
        {
            "Laptop" => new Laptop(assetName, assetType, assetQuantity, totalQuantity),
            "CPU" => new CPU(assetName, assetType, assetQuantity, totalQuantity),
            "Monitor" => new Monitor(assetName, assetType, assetQuantity, totalQuantity),
            _ => throw new ArgumentOutOfRangeException(nameof(assetName)),
        };
}