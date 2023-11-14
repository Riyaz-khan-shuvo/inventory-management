using InventoryManagement.Sql.Entities.Base;
using InventoryManagement.Sql.Entities.Configurations;
using static InventoryManagement.Sql.Entities.Identities.IdentityModel;

namespace InventoryManagement.Sql.Entities.Enrols
{
    public class Purchase : BaseEntity
    {
        public Purchase() 
        {
            this.PurchaseItems = new HashSet<PurchaseItem>();
        }

        public long? UserId { get; set; }
        public DateTime PurchasesDate { get; set; }
        public string PurchasesCode { get; set; }
        public string PurchasesType { get; set; }
        public long? SupplierId { get; set; }
        public string Warrenty { get; set; }
        public string Attn { get; set; }
        public double LcNumber { get; set; }
        public DateTime LcDate { get; set; }
        public double PoNumber { get; set; }
        public string Remarks { get; set; }
        public long? CompanyId { get; set; }
        public double DiscountAmount { get; set; }
        public double DiscountPercent { get; set; }
        public double VatAmount { get; set; }
        public double VatPercent { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public bool Cancle { get; set; }
        public Company Company { get; set; }
        public User  User { get; set; }
        public Supplier Supplier { get; set; }


        public virtual ICollection<PurchaseItem> PurchaseItems { get; set; }


    }
}
