// Class representing a Laptop, inheriting from BaseAssetManager
public class Laptop : BaseAssetManager
{
    // Instance variable to store the total quantity of laptops
    private int _totalLaptopQuantity;

    // Properties representing default values for a Laptop
    public override string _processor { get; set; } = "i5";
    public override string _ram { get; set; } = "16G";
    public override string _storageCapacity { get; set; } = "256GB";

    // Constructor for initializing Laptop properties
    public Laptop(string assetName, string assetType, int assetQuantity, int totalLaptopQuantity, string processor, string ram, string storageCapacity)
        : base(assetName, assetType, assetQuantity)
    {
        _totalLaptopQuantity = totalLaptopQuantity; // Initialize the instance variable
        _processor = processor; // Set the values passed to the constructor
        _ram = ram;
        _storageCapacity = storageCapacity;
    }

    // Override method to update the total quantity of laptops
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total laptop quantity
        _totalLaptopQuantity += individualAssetQuantity;

        return _totalLaptopQuantity; // Return the updated total laptop quantity
    }
}
