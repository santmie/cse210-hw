using System;
using System.Collections.Generic;
using System.IO;

// Class responsible for saving and loading assets
public class SaveLoad
{
    private const string _laptop = "Laptop";
    private const string _cpu = "CPU";
    private const string _monitor = "Monitor";
    private const string _headset = "Headset";
    private const string _webcam = "Webcam";
    private const string _mouse = "Mouse";
    private const string _keyboard = "Keyboard";
    private const string _internetConnectivity = "Internet Connectivity";

    // Save asset data to a file
    public void SaveData(string fileName, int totalLaptopQuantity, int totalCPUQuantity, int totalMonitorQuantity, int totalHeadsetQuantity, int totalWebcamQuantity, int totalMouseQuantity, int totalKeyboardQuantity, int totalInternetQuantity, List<BaseAssetManager> assetList)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Write total quantities to the file
                writer.WriteLine("Total Laptop,Total CPU,Total Monitor,Total Headset,Total Webcam,Total Mouse,Total Keyboard,Total Internet Connectivity");
                writer.WriteLine($"{totalLaptopQuantity},{totalCPUQuantity},{totalMonitorQuantity},{totalHeadsetQuantity},{totalWebcamQuantity},{totalMouseQuantity},{totalKeyboardQuantity},{totalInternetQuantity}");

                // Write asset header to the file
                writer.WriteLine("Asset Name,Asset Type,Requested Quantity");

                // Write each asset to the file
                foreach (BaseAssetManager asset in assetList)
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

    // Get a formatted string representation of an asset
    private string GetAssetLine(BaseAssetManager asset)
    {
        string assetLine;

        if (asset is Laptop laptop)
        {
            assetLine = $"{laptop.GetAssetName()},{laptop.GetAssetType()},{laptop.GetAssetQuantity()},{laptop._processor},{laptop._ram},{laptop._storageCapacity}";
        }
        else if (asset is CPU cpu)
        {
            assetLine = $"{cpu.GetAssetName()},{cpu.GetAssetType()},{cpu.GetAssetQuantity()},{cpu._processor},{cpu._ram},{cpu._storageCapacity}";
        }
        else if (asset is Monitor monitor)
        {
            assetLine = $"{monitor.GetAssetName()},{monitor.GetAssetType()},{monitor.GetAssetQuantity()},{monitor._sizeMonitor}";
        }
        else
        {
            assetLine = $"{asset.GetAssetName()},{asset.GetAssetType()},{asset.GetAssetQuantity()}";
        }

        return assetLine;
    }

    // Load asset data from a file
    public void LoadData(string fileName, ref int totalLaptopQuantity, ref int totalCPUQuantity, ref int totalMonitorQuantity, ref int totalHeadsetQuantity, ref int totalWebcamQuantity, ref int totalMouseQuantity, ref int totalKeyboardQuantity, ref int totalInternetQuantity, List<BaseAssetManager> assetList, Program program)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Read the first three lines to skip the header
                string firstLine = reader.ReadLine();
                string secondLine = reader.ReadLine();
                string thirdLine = reader.ReadLine();

                // Parse total quantities
                string[] totalQuantities = secondLine.Split(',');
                totalLaptopQuantity = int.Parse(totalQuantities[0]);
                totalCPUQuantity = int.Parse(totalQuantities[1]);
                totalMonitorQuantity = int.Parse(totalQuantities[2]);
                totalHeadsetQuantity = int.Parse(totalQuantities[3]);
                totalWebcamQuantity = int.Parse(totalQuantities[4]);
                totalMouseQuantity = int.Parse(totalQuantities[5]);
                totalKeyboardQuantity = int.Parse(totalQuantities[6]);
                totalInternetQuantity = int.Parse(totalQuantities[7]);

                // Clear the asset list
                assetList.Clear();

                // Read and parse each line to load assets
                while (!reader.EndOfStream)
                {
                    string assetLine = reader.ReadLine();
                    string[] assetProperties = assetLine.Split(',');

                    ParseAsset(assetProperties, assetList, totalLaptopQuantity, totalCPUQuantity, totalMonitorQuantity, totalHeadsetQuantity, totalWebcamQuantity, totalMouseQuantity, totalKeyboardQuantity, totalInternetQuantity);
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

    // Parse asset properties and create corresponding asset objects
    private void ParseAsset(string[] assetProperties, List<BaseAssetManager> assetList, int totalLaptopQuantity, int totalCPUQuantity, int totalMonitorQuantity, int totalHeadsetQuantity, int totalWebcamQuantity, int totalMouseQuantity, int totalKeyboardQuantity, int totalInternetQuantity)
    {
        try
        {
            if (assetProperties.Length < 3)
            {
                Console.WriteLine("<< Invalid asset data: Insufficient data >>");
                return;
            }

            string assetName = assetProperties[0];
            string assetType = assetProperties[1];

            if (!int.TryParse(assetProperties[2], out int assetQuantity))
            {
                Console.WriteLine($"Invalid quantity for {assetName}: {assetProperties[2]}");
                return;
            }

            string processor = "";
            string ram = "";
            string storageCapacity = "";
            string sizeMonitor = "";

            if (assetProperties.Length > 3)
            {
                processor = assetProperties[3];
                if (assetName == _monitor)
                {
                    sizeMonitor = processor;
                    processor = "";
                }
            }

            if (assetProperties.Length > 4)
            {
                ram = assetProperties[4];
            }

            if (assetProperties.Length > 5)
            {
                storageCapacity = assetProperties[5];
            }

            // Create different types of assets based on assetName
            switch (assetName)
            {
                case _laptop:
                    assetList.Add(new Laptop(assetName, assetType, assetQuantity, totalLaptopQuantity, processor, ram, storageCapacity));
                    break;
                case _cpu:
                    assetList.Add(new CPU(assetName, assetType, assetQuantity, totalCPUQuantity, processor, ram, storageCapacity));
                    break;
                case _monitor:
                    assetList.Add(new Monitor(assetName, assetType, assetQuantity, totalMonitorQuantity, sizeMonitor));
                    break;
                case _headset:
                    assetList.Add(new Headset(assetName, assetType, assetQuantity, totalHeadsetQuantity));
                    break;
                case _webcam:
                    assetList.Add(new Webcam(assetName, assetType, assetQuantity, totalWebcamQuantity));
                    break;
                case _mouse:
                    assetList.Add(new Mouse(assetName, assetType, assetQuantity, totalMouseQuantity));
                    break;
                case _keyboard:
                    assetList.Add(new Keyboard(assetName, assetType, assetQuantity, totalKeyboardQuantity));
                    break;
                case _internetConnectivity:
                    assetList.Add(new InternetConnectivity(assetName, assetType, assetQuantity, totalInternetQuantity));
                    break;
                default:
                    Console.WriteLine($"Unknown asset type: {assetName}");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing asset: {ex.Message}");
        }
    }
}
