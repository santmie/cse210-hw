// Class representing a Monitor, inheriting from BaseAssetManager
public class Monitor : BaseAssetManager
{
    // Static variable to store the total quantity of Monitors
    private static int _totalMonitorQuantity;

    // Property representing the size of the Monitor
    public override string _sizeMonitor { get; set; }

    // Constructor for initializing Monitor properties
    public Monitor(string assetName, string assetType, int assetQuantity, int totalMonitorQuantity, string sizeMonitor) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalMonitorQuantity = totalMonitorQuantity; // Initialize the static variable
        _sizeMonitor = sizeMonitor;
    }

    // Override method to update the total quantity of Monitors
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Monitor quantity
        _totalMonitorQuantity += individualAssetQuantity;

        return _totalMonitorQuantity; // Return the updated total Monitor quantity
    }
}
