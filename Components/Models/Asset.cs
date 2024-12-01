using System.Text.Json;
using System.Text.Json.Serialization;

public class Asset
{
    public Int32 id { get; set; }
    public String name { get; set; }
    public String? description { get; set; }
    public Int32 locationId { get; set; }
    public Int32? parentId { get; set; }
    public Int32 creatorId { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public List<Object>? attachments { get; set; }
    public Int32 criticalityId { get; set; }
    public List<Int32>? childrenIds { get; set; }
    public List<Int32>? teamIds { get; set; }
    public List<String>? assetTypes { get; set; }
    public Dictionary<String, Object>? extraFields { get; set; }
    public List<Int32>? vendorIds { get; set; }
}
public class AssetResponse
{
    public List<Asset> assets { get; set; }
    public String? nextCursor { get; set; }
    public String? nextPageUrl { get; set; }
}

public class ResponseAsset
{
    public Asset asset { get; set; }
}
