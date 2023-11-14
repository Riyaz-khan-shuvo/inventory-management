using InventoryManagement.Service.Models.Configurations;

namespace InventoryManagement.Service.Models.Enrols;

public class WareHouseModel:MasterModel
{
    public int CompanyId { get; set; }
    public CompanyModel Company { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int CountryId { get; set; }
    public CountryModel Country { get; set; }
}