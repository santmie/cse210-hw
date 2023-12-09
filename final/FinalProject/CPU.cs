// Class representing a CPU, inheriting from BaseAssetManager
public class CPU : BaseAssetManager
{
    // Instance variable to store the total quantity of CPUs
    private int _totalCPUQuantity;

    // Properties representing default values for a CPU
    public override string _processor { get; set; } = "i5";
    public override string _ram { get; set; } = "16G";
    public override string _storageCapacity { get; set; } = "256GB";

    // Constructor for initializing CPU properties
    public CPU(string assetName, string assetType, int assetQuantity, int totalCPUQuantity, string processor, string ram, string storageCapacity)
        : base(assetName, assetType, assetQuantity)
    {
        _totalCPUQuantity = totalCPUQuantity; // Initialize the instance variable
        _processor = processor; // Set the values passed to the constructor
        _ram = ram;
        _storageCapacity = storageCapacity;
    }

    // Override method to update the total quantity of CPUs
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total CPU quantity
        _totalCPUQuantity += individualAssetQuantity;

        return _totalCPUQuantity; // Return the updated total CPU quantity
    }
}
