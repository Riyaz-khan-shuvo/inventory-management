using InventoryManagement.Sql.Entities.Base;
using InventoryManagement.Sql.Entities.Enrols;

namespace InventoryManagement.Sql.Entities.Configurations
{
    public class Supplier : BaseEntity
    {
        public Supplier() 
        {
            this.PurchasesMasters = new HashSet<Purchase>();        
        }

        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public virtual ICollection<Purchase> PurchasesMasters { get; set; }
    }
}
