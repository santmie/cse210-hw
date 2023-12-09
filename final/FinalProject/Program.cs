using System;
using System.Collections.Generic;
// Project Name: IT Asset Management System
// The IT Asset Management System project aims to streamline the process of managing IT assets through a user interface developed using a C# program. 
// The key features of the project include:
// 1. Automatic Loading of Asset Inventory:
// The system automatically loads data from the 'IT Asset Inventory.txt' file using the 'LoadAssets()' method.
// The 'ListAssets()' method is employed to populate the asset list.
// 2. Asset Name Selection:
// Users can select from a variety of asset names, including Laptop, CPU, Monitor, Headset, Webcam, Mouse, Keyboard, and Internet Connectivity.
// 3. Asset Types and Specifications:
//  - Laptop and CPU: Standard, Non-Standard, Macbook Pro, Macbook Air.
//       	Standard: Processor - i5, RAM - 16G, Storage Capacity - 256GB.
//       	Non-Standard: Processor - i5, i7; RAM - 16G, 32G; Storage Capacity - 256GB, 500GB.
//      	Macbook Pro, Macbook Air, Macmini-Care, Macmini-RCC, iMac: Processor - M1 Chipset, RAM - 16G, 32G; Storage Capacity - 256GB, 500GB.
//  - Monitor: Single Monitor, Dual Monitor. Monitor Size: 18.5, 19, 21.5, 24, 27.
//  - Headset: USB, QD
//  - Webcam, Mouse, and Keyboard: USB, Wireless.
//  - Internet Connectivity: Wired LAN, Wireless (Wi-Fi)
// 4. Individual and Total Asset Quantity: The system tracks individual asset quantities as well as the total quantity for each asset type.
// 5. SaveLoad Class Implementation: A SaveLoad class is implemented to facilitate the saving and loading of assets to/from the 'IT Asset Inventory.txt' file.
// 5. Deletion Option in Main Menu: Users can delete entries from the asset list, enhancing flexibility in managing asset records.

// Class to manage IT asset requests
public class Program
{
    // variables to store the list of assets and total quantities per asset
    private List<BaseAssetManager> _assetList = new List<BaseAssetManager>();
    private int _totalLaptopQuantity = 0; //Laptop initial value
    private int _totalCPUQuantity = 0; //CPU initial value
    private int _totalMonitorQuantity = 0; //Monitor initial value
    private int _totalHeadsetQuantity = 0; //Headset initial value
    private int _totalWebcamQuantity = 0; //Webcam initial value
    private int _totalMouseQuantity = 0; //Mouse initial value
    private int _totalKeyboardQuantity = 0; //Keyboard initial value
    private int _totalInternetQuantity = 0; //Internet Connectivity initial value

    // Main entry of the program
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    // Method to run the program
    private void Run()
    {
        LoadAssets();
        ListAssets();

        // Run the main loop to display the menu
        while (true)
        {
            DisplayMenu();
        }
    }

    // Method to display the main menu
    private void DisplayMenu()
    {
        Console.WriteLine();
        DisplayTotalQuantities();
        DisplayMenuOptions();

        int choice = GetUserChoice();

        // Switch case to handle user choices
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
                DeleteAsset();
                break;

            case 4:
                SaveAssets();
                break;

            case 5:
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("<< Invalid selection. Please try again. >>");
                break;
        }
    }

    // Method to display the total quantities of assets
    private void DisplayTotalQuantities()
    {
        Console.WriteLine("Total quantity requested per Asset Type:");
        Console.WriteLine($"Laptop = {_totalLaptopQuantity}; CPU = {_totalCPUQuantity}; Monitor = {_totalMonitorQuantity}; Headset = {_totalHeadsetQuantity}; \n" +
                          $"Webcam = {_totalWebcamQuantity}; Mouse = {_totalMouseQuantity}; Keyboard = {_totalKeyboardQuantity}; Internet Connectivity = {_totalInternetQuantity}");
        Console.WriteLine();
    }

    // Method to display menu options
    private void DisplayMenuOptions()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine(" 1. Add new asset request");
        Console.WriteLine(" 2. Show list of requested assets");
        Console.WriteLine(" 3. Delete an asset request");
        Console.WriteLine(" 4. Save IT Asset Inventory file");
        Console.WriteLine(" 5. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    // Method to get user's choice
    private int GetUserChoice()
    {
        return int.Parse(Console.ReadLine());
    }

    // Method to add a new asset request
    private void AddNewAsset()
    {
        Console.WriteLine("The types of Assets are:");
        AssetChooser.DisplayAssetTypes();
        Console.Write("Which type of asset would you like to request? ");

        int assetChoice = GetUserChoice();
        string assetName;
        string assetType;
        int assetQuantity;

        if (assetChoice >= 1 && assetChoice <= 8)
        {
            assetName = AssetChooser.GetAssetName(assetChoice);
            AssetChooser.DeclareAndAddAsset(assetName, _assetList, ref _totalLaptopQuantity, ref _totalCPUQuantity, ref _totalMonitorQuantity, ref _totalHeadsetQuantity, ref _totalWebcamQuantity, ref _totalMouseQuantity, ref _totalKeyboardQuantity, ref _totalInternetQuantity, out assetType, out assetQuantity);
        }
        else
        {
            Console.WriteLine("<< Invalid selection. Please try again. >>");
            return;
        }
    }

    // Method to list all requested assets
    private void ListAssets()
    {
        Console.WriteLine("The requested assets are:");
        for (int i = 0; i < _assetList.Count; i++)
        {
            string assetName = _assetList[i].GetAssetName();
            string assetType = _assetList[i].GetAssetType();
            int assetQuantity = _assetList[i].GetAssetQuantity();

            Console.Write($"{i + 1}. {assetName} ({assetType}) ({assetQuantity})");

            // Display additional details for specific asset types
            if (assetName.Equals("Laptop", StringComparison.OrdinalIgnoreCase) || assetName.Equals("CPU", StringComparison.OrdinalIgnoreCase) || assetName.Equals("Monitor", StringComparison.OrdinalIgnoreCase))
            {
                if (_assetList[i] is Laptop laptop)
                {
                    Console.Write($", Processor: {laptop._processor}, RAM: {laptop._ram}, Storage Capacity: {laptop._storageCapacity}");
                }
                else if (_assetList[i] is CPU cpu)
                {
                    Console.Write($", Processor: {cpu._processor}, RAM: {cpu._ram}, Storage Capacity: {cpu._storageCapacity}");
                }
                else if (_assetList[i] is Monitor monitor)
                {
                    Console.Write($", Monitor Size: {monitor._sizeMonitor}");
                }
            }

            Console.WriteLine();
        }
    }

    // Method to save assets to a file
    private void SaveAssets()
    {
        string saveName = "IT Asset Inventory.txt";
        SaveLoad saveFile = new SaveLoad();
        saveFile.SaveData(saveName, _totalLaptopQuantity, _totalCPUQuantity, _totalMonitorQuantity, _totalHeadsetQuantity, _totalWebcamQuantity, _totalMouseQuantity, _totalKeyboardQuantity, _totalInternetQuantity, _assetList);
    }

    // Method to load assets from a file
    private void LoadAssets()
    {
        string loadName = "IT Asset Inventory.txt";
        SaveLoad saveLoad = new SaveLoad();
        saveLoad.LoadData(loadName, ref _totalLaptopQuantity, ref _totalCPUQuantity, ref _totalMonitorQuantity, ref _totalHeadsetQuantity, ref _totalWebcamQuantity, ref _totalMouseQuantity, ref _totalKeyboardQuantity, ref _totalInternetQuantity, _assetList, this);
    }

    // Method to delete an asset request
    private void DeleteAsset()
    {
        Console.WriteLine();
        ListAssets();
        Console.WriteLine();
        Console.Write("Enter the number of the entry to delete: ");

        if (int.TryParse(Console.ReadLine(), out int entryNumber))
        {
            if (entryNumber >= 1 && entryNumber <= _assetList.Count)
            {
                BaseAssetManager deletedAsset = _assetList[entryNumber - 1];

                string assetName = deletedAsset.GetAssetName();
                int assetQuantity = deletedAsset.GetAssetQuantity(); // Get the quantity of the specific asset

                AssetQuantityManager.UpdateTotalQuantity(
                    assetName, -assetQuantity, ref _totalLaptopQuantity, ref _totalCPUQuantity,
                    ref _totalMonitorQuantity, ref _totalHeadsetQuantity, ref _totalWebcamQuantity,
                    ref _totalMouseQuantity, ref _totalKeyboardQuantity, ref _totalInternetQuantity);

                _assetList.RemoveAt(entryNumber - 1);
                Console.WriteLine($"Entry {entryNumber} has been deleted.");
            }
            else
            {
                Console.WriteLine("<< Invalid entry number. Please enter a valid number. >>");
            }
        }
        else
        {
            Console.WriteLine("<< Invalid input. Please enter a valid number. >>");
        }
    }
}