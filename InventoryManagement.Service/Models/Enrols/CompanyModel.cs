using InventoryManagement.Service.Models.Configurations;

namespace InventoryManagement.Service.Models.Enrols;

public class CompanyModel: MasterModel
{
    public long? UserId { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public long? CountryId { get; set; }
    public long? StateId { get; set; }
    public long? CityId { get; set; }
    public string ZipCode { get; set; }
    public string ContactNumber { get; set; }
    public UserModel User { get; set; }
    public CountryModel Country { get; set; }
    public StateModel State { get; set; }
    public CityModel City { get; set; }
}