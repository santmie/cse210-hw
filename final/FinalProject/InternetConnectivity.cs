// Class representing an Internet Connectivity asset, inheriting from BaseAssetManager
public class InternetConnectivity : BaseAssetManager
{
    // Static variable to store the total quantity of Internet Connectivity assets
    private static int _totalInternetQuantity;

    // Constructor for initializing Internet Connectivity properties
    public InternetConnectivity(string assetName, string assetType, int assetQuantity, int totalInternetQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalInternetQuantity = totalInternetQuantity; // Initialize the static variable
    }

    // Override method to update the total quantity of Internet Connectivity assets
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Internet Connectivity quantity
        _totalInternetQuantity += individualAssetQuantity;

        return _totalInternetQuantity; // Return the updated total Internet Connectivity quantity
    }
}
