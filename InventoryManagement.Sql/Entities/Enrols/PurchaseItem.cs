using InventoryManagement.Sql.Entities.Base;
namespace InventoryManagement.Sql.Entities.Enrols
{
    public class PurchaseItem : BaseEntity
    {
        public long PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }

        public long ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string BatchNumber { get; set; }
        public double Quantity { get; set; }
        public double PurchasesPrice { get; set; }
        public double SellPrice { get; set; }
       

    }
}
