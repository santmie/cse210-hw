// Class representing a Headset, inheriting from BaseAssetManager
public class Headset : BaseAssetManager
{
    // Static variable to store the total quantity of Headsets
    private static int _totalHeadsetQuantity;

    // Constructor for initializing Headset properties
    public Headset(string assetName, string assetType, int assetQuantity, int totalHeadsetQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalHeadsetQuantity = totalHeadsetQuantity; // Initialize the static variable
    }

    // Override method to update the total quantity of Headsets
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Headset quantity
        _totalHeadsetQuantity += individualAssetQuantity;

        return _totalHeadsetQuantity; // Return the updated total Headset quantity
    }
}
