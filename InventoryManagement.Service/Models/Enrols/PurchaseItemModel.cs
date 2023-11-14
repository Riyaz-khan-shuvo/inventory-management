using Newtonsoft.Json;

namespace InventoryManagement.Service.Models.Enrols;

public class PurchaseItemModel : MasterModel
{
    public long PurchaseId { get; set; }
    [JsonIgnore]
    public  PurchaseModel Purchase { get; set; }

    public long ItemId { get; set; }
    [JsonIgnore]
    public  ItemModel Item { get; set; }

    public string BatchNumber { get; set; }
    public double Quantity { get; set; }
    public double PurchasesPrice { get; set; }
    public double SellPrice { get; set; }
}