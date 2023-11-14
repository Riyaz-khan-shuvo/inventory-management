
using InventoryManagement.Service.Models.Configurations;
using Newtonsoft.Json;

namespace InventoryManagement.Service.Models.Enrols;

public class ItemModel:MasterModel
{
    public long SubCategoryId { get; set; }
    public long CompanyId { get; set; }
    public long UnitId { get; set; }
    public string ItemCode { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string Measure { get; set; }
    public double Measurevalue { get; set; }
    public double UnitPrice { get; set; }
    public double SellPrice { get; set; }
    public double OldUnitPrice { get; set; }
    public double OldSellPrice { get; set; }
    public string ReOrderLevel { get; set; }
    public double Stock { get; set; }
    [JsonIgnore]
    public SubCategoryModel SubCategory { get; set; }
    [JsonIgnore]
    public CompanyModel Company { get; set; }
    [JsonIgnore]
    public UnitModel Unit { get; set; }
}