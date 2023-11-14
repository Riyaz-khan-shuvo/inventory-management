namespace InventoryManagement.Service.Models.Enrols;

public class PurchaseModel :MasterModel
{
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


    //public List<SelectListItem> Items { get; set; }
    //public string[] SelectedItems { get; set; }

    //public CompanyModel Company { get; set; }
    //public UserModel User { get; set; }
    //public SupplierModel Supplier { get; set; }

    public ICollection<PurchaseItemModel> PurchaseItems { get; set; } = new HashSet<PurchaseItemModel>();
}