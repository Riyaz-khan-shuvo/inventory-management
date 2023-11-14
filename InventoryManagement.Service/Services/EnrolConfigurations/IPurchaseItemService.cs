using InventoryManagement.Core;
using InventoryManagement.Core.Collections;
using InventoryManagement.Service.Models.Enrols;
using InventoryManagement.Service.Services.Base;
using InventoryManagement.Sql.Entities.Enrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Services.EnrolConfigurations;

public interface IPurchaseItemService : IBaseService<PurchaseItem>
{
    Task<Dropdown<PurchaseItemModel>> GetDropdownAsync(string search = null, int size = CommonVariables.DropdownSize);
    Task<Paging<PurchaseItemModel>> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null);
    Task<Paging<PurchaseItemModel>> GetFilterAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string filterText1 = null);

    Task<PurchaseItemModel> GetPurchaseItemDetailAsync(long purchaseDetailsId);
    Task<PurchaseItemModel> AddPurchaseItemDetailAsync(PurchaseItemModel model);
    Task<PurchaseItemModel> UpdatePurchaseItemDetailAsync(long purchaseDetailsId, PurchaseItemModel model);
    Task<PurchaseItemModel> UpdatePurchaseItemDetailAsync(long purchaseDetailsId, string model);
    Task<PurchaseItemModel> DeletePurchaseItemDetailAsync(long purchaseDetailsId);

}