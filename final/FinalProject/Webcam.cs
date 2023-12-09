// Class representing a Webcam, inheriting from BaseAssetManager
public class Webcam : BaseAssetManager
{
    // Static variable to store the total quantity of Webcams
    private static int _totalWebcamQuantity;

    // Constructor for initializing Webcam properties
    public Webcam(string assetName, string assetType, int assetQuantity, int totalWebcamQuantity) 
        : base(assetName, assetType, assetQuantity)
    {
        _totalWebcamQuantity = totalWebcamQuantity; // Initialize the static variable
    }

    // Override method to update the total quantity of Webcams
    public override int UpdateTotalQuantity()
    {
        // Call the base class implementation to get the individual asset quantity
        int individualAssetQuantity = base.UpdateTotalQuantity();

        // Update the total Webcam quantity
        _totalWebcamQuantity += individualAssetQuantity;

        return _totalWebcamQuantity; // Return the updated total Webcam quantity
    }
}
