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

public interface IPurchaseService : IBaseService<Purchase>
{
    /// <summary>
    /// Gets the dropdown asynchronous.
    /// </summary>
    /// <param name="search">The search.</param>
    /// <param name="size">The size.</param>
    /// <returns></returns>
    Task<Dropdown<PurchaseModel>> GetDropdownAsync(string search = null, int size = CommonVariables.DropdownSize);
    /// <summary>
    /// Gets the search asynchronous.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    Task<Paging<PurchaseModel>> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null);
    /// <summary>
    /// Gets the filter asynchronous.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="filterText1">The filter text1.</param>
    /// <returns></returns>
    Task<Paging<PurchaseModel>> GetFilterAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string filterText1 = null);

    /// <summary>
    /// Gets the purchase detail asynchronous.
    /// </summary>
    /// <param name="purchasesMasterId">The purchasesMaster identifier.</param>
    /// <returns></returns>
    Task<PurchaseModel> GetPurchaseDetailAsync(long purchasesMasterId);
    /// <summary>
    /// Adds the purchase detail asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    Task<PurchaseModel> AddPurchaseDetailAsync(PurchaseModel model);
    /// <summary>
    /// Updates the purchase detail asynchronous.
    /// </summary>
    /// <param name="purchasesMasterId">The purchases master identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    Task<PurchaseModel> UpdatePurchaseDetailAsync(long purchasesMasterId, PurchaseModel model);
    /// <summary>
    /// Updates the purchase detail asynchronous.
    /// </summary>
    /// <param name="purchasesMasterId">The purchases master identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    Task<PurchaseModel> UpdatePurchaseDetailAsync(long purchasesMasterId, string model);
}