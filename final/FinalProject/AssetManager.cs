public abstract class AssetManager
{
    protected string _assetName;
    protected string _assetType;
    protected int _assetQuantity;
    // protected int _adjustedQuantity;
    // protected bool _completionStatus;

    public AssetManager(string assetName, string assetType, int assetQuantity)
    {
        _assetName = assetName;
        _assetType = assetType;
        _assetQuantity = assetQuantity;
        // _adjustedQuantity  = adjustedQuantity;
        // _completionStatus = completionStatus;
    }

    public string GetAssetName()
    {
        return _assetName; 
    }

    public string GetAssetType()
    {
        return _assetType;
    }

    public int GetAssetQuantity()
    {
        return _assetQuantity; 
    }

    public virtual int UpdateTotalQuantity()
    {
        return _assetQuantity;
    }

    public virtual bool? IsComplete()
    {
        return null;
    }
}