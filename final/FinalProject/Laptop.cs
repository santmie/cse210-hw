public class Laptop : AssetManager
{
    private static int _totalLaptopQuantity ;

    public Laptop(string assetName, string assetType, int assetQuantity, int totalLaptopQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalLaptopQuantity = totalLaptopQuantity; // Initialize the static variable
    }

    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total laptop quantity
        _totalLaptopQuantity += individualAssetQuantity;

        return _totalLaptopQuantity; // Return the individual asset quantity
    }
}