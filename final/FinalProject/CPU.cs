public class CPU : AssetManager
{
    private static int _totalCPUQuantity ;

    public CPU(string assetName, string assetType, int assetQuantity, int totalCPUQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalCPUQuantity = totalCPUQuantity; // Initialize the static variable
    }

    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total CPU quantity
        _totalCPUQuantity += individualAssetQuantity;

        return _totalCPUQuantity; // Return the individual asset quantity
    }
}