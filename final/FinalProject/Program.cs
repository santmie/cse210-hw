using System;
using System.Collections.Generic;

//Project Name: IT Asset Management System

// Progress Update:
// Completed:
// 1. Automatically loaded the 'IT Asset Inventory.txt' and populated the list by calling the LoadAssets() and ListAssets() methods.
// 2. Added the main menu selection.
// 3. Added selection for 3 asset types - Laptop, CPU, and Monitor.
// 4. Created a separate class to handle Asset choices - AssetChooser.cs.
// 5. Created a Base class named AssetManager and child classes for each asset type to store the asset name, type, and quantity.
// 6. Implemented the SaveLoad class for saving and loading assets to a predefined text file named 'IT Asset Inventory.txt.'

//In Progress:
//1. To create selection and classes for other asset types: Headset, Webcam, Mouse, Keyboard, Internet Connectivity
//2. To add the type and other details per Asset selection:
    //Laptop = Standard, Non Standard , Macbook Pro, Macbook Air
    //CPU = Standard, Non Standard , Macmini - Care, Macmini - RCC, iMac
        //Standard = Processor - i5 | RAM- 16G | Storage Capacity - 256GB
        //Non Standard = Processor - i5, i7 | RAM- 16G, 32G | Storage Capacity - 256GB, 500GB
        //Macbook Pro, Macbook Air, Macmini-Care, Macmini - RCC, iMac = Processor - M1 Chipset | RAM- 16G, 32G | Storage Capacity - 256GB, 500GB

    //Monitor - Single Monitor,Dual Monitor / Monitor Size - 18.5, 19, 21.5, 24, 27
    //Headset - USB, QD
    //Webcam, Mouse and Keyboard - USB,Wireless
    //Internet Connectivity - Wired LAN, Wireless (Wi-Fi)
public class Program
{
    private List<AssetManager> _assetList = new List<AssetManager>();
    private int _totalLaptopQuantity = 0;
    private int _totalCPUQuantity = 0;
    private int _totalMonitorQuantity = 0;

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    private void Run()
    {
        LoadAssets();
        ListAssets();
        while (true)
        {
            DisplayMenu();
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine();
        DisplayTotalQuantities();
        DisplayMenuOptions();

        int choice = GetUserChoice();

        switch (choice)
        {
            case 1:
                AddNewAsset();
                break;

            case 2:
                Console.WriteLine();
                ListAssets();
                break;

            case 3:
                SaveAssets();
                break;

            case 4:
                Environment.Exit(0); // Exit the program
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private void DisplayTotalQuantities()
    {
        Console.WriteLine($"Total quantity requested per Asset Type:");
        Console.WriteLine($" Laptop = {_totalLaptopQuantity}");
        Console.WriteLine($" CPU = {_totalCPUQuantity}");
        Console.WriteLine($" Monitor = {_totalMonitorQuantity}");
        Console.WriteLine();
    }

    private void DisplayMenuOptions()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Add new asset request");
        Console.WriteLine(" 2. Show list of requested assets");
        Console.WriteLine(" 3. Save IT Asset Inventory file");
        Console.WriteLine(" 4. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private int GetUserChoice()
    {
        return int.Parse(Console.ReadLine());
    }

private void AddNewAsset()
{
    Console.WriteLine("The types of Assets are:");
    AssetChooser.DisplayAssetTypes();
    Console.Write("Which type of asset would you like to request? ");

    int assetChoice = GetUserChoice();
    string assetName;
    string assetType;
    int assetQuantity;

    switch (assetChoice)
    {
        case 1:
        case 2:
        case 3:
            assetName = AssetChooser.GetAssetName(assetChoice);
            AssetChooser.DeclareAndAddAsset(assetName, _assetList, ref _totalLaptopQuantity, ref _totalCPUQuantity, ref _totalMonitorQuantity, out assetType, out assetQuantity);
            break;

        default:
            Console.WriteLine("Invalid choice.");
            return; // Return without further processing if the choice is invalid
    }
}


    private void ListAssets()
    {
        Console.WriteLine("The requested assets are:");
        for (int i = 0; i < _assetList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_assetList[i].GetAssetName()} ({_assetList[i].GetAssetType()}) ({_assetList[i].GetAssetQuantity()})");
        }
    }

    private void SaveAssets()
    {
        string saveName = "IT Asset Inventory.txt";
        SaveLoad saveFile = new SaveLoad();
        saveFile.SaveData(saveName, _totalLaptopQuantity, _totalCPUQuantity, _totalMonitorQuantity, _assetList);
    }

    private void LoadAssets()
    {
        string loadName = "IT Asset Inventory.txt";
        SaveLoad saveLoad = new SaveLoad();
        saveLoad.LoadData(loadName, ref _totalLaptopQuantity, ref _totalCPUQuantity, ref _totalMonitorQuantity, _assetList, this);
    }

}