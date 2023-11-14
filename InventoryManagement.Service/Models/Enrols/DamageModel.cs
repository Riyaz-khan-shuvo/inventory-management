namespace InventoryManagement.Service.Models.Enrols;

public class DamageModel:MasterModel
{
    public long? ItemId { get; set; }
    public ItemModel Item { get; set; }
    public double Quantity { get; set; }
    public double DamageQuantity { get; set; }
    public string DamageReason { get; set; }
    public long? CompanyId { get; set; }
    public CompanyModel Company { get; set; }
    public DateTime DamageDate { get; set; }
}