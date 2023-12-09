// Base class for managing different types of assets
public abstract class BaseAssetManager
{
    // Protected variables to store asset information
    protected string _assetName;
    protected string _assetType;
    protected int _assetQuantity;

    // Properties representing asset details for laptop and cpu
    public virtual string _processor { get; set; }
    public virtual string _ram { get; set; }
    public virtual string _storageCapacity { get; set; }
    public virtual string _sizeMonitor { get; set; }

    // Constructor to initialize common asset properties
    public BaseAssetManager(string assetName, string assetType, int assetQuantity)
    {
        _assetName = assetName;
        _assetType = assetType;
        _assetQuantity = assetQuantity;
    }

    // Method to get the asset name
    public string GetAssetName()
    {
        return _assetName;
    }

    // Method to get the asset type
    public string GetAssetType()
    {
        return _assetType;
    }

    // Method to get the asset quantity
    public int GetAssetQuantity()
    {
        return _assetQuantity;
    }

    // Virtual method to update the total quantity (specific to each asset type)
    public virtual int UpdateTotalQuantity()
    {
        return _assetQuantity;
    }
}
