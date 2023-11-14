using InventoryManagement.Service.Models.Configurations;

namespace InventoryManagement.Service.Models.Enrols;

public class CurrencyModel:MasterModel
{
    public long CountryId { get; set; }
    public long CompanyId { get; set; }
    public string CurrencyName { get; set; }
    public string CurrencyCode { get; set; }
    public string Syambol { get; set; }
    public bool IsDefault { get; set; }

    public CountryModel Country { get; set; }
    public CompanyModel Company { get; set; }
}