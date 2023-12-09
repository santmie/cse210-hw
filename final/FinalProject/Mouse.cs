// Class representing a Mouse, inheriting from BaseAssetManager
public class Mouse : BaseAssetManager
{
    // Static variable to store the total quantity of Mice
    private static int _totalMouseQuantity;

    // Constructor for initializing Mouse properties
    public Mouse(string assetName, string assetType, int assetQuantity, int totalMouseQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalMouseQuantity = totalMouseQuantity; // Initialize the static variable
    }

    // Override method to update the total quantity of Mice
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Mouse quantity
        _totalMouseQuantity += individualAssetQuantity;

        return _totalMouseQuantity; // Return the updated total Mouse quantity
    }
}
