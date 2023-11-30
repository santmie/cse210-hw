public class Monitor : AssetManager
{
    private static int _totalMonitorQuantity ;

    public Monitor(string assetName, string assetType, int assetQuantity, int totalMonitorQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalMonitorQuantity = totalMonitorQuantity; // Initialize the static variable
    }

    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Monitor quantity
        _totalMonitorQuantity += individualAssetQuantity;

        return _totalMonitorQuantity; // Return the individual asset quantity
    }
}