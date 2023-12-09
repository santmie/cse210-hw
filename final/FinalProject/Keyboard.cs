// Class representing a Keyboard, inheriting from BaseAssetManager
public class Keyboard : BaseAssetManager
{
    // Static variable to store the total quantity of Keyboards
    private static int _totalKeyboardQuantity;

    // Constructor for initializing Keyboard properties
    public Keyboard(string assetName, string assetType, int assetQuantity, int totalKeyboardQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalKeyboardQuantity = totalKeyboardQuantity; // Initialize the static variable
    }

    // Override method to update the total quantity of Keyboards
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Keyboard quantity
        _totalKeyboardQuantity += individualAssetQuantity;

        return _totalKeyboardQuantity; // Return the updated total Keyboard quantity
    }
}
