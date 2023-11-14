using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers;

/// <summary>
/// 
/// </summary>
/// <seealso cref="InventoryManagement.Helpers.Base.GenericBaseController&lt;InventoryManagement.Sql.Entities.Enrols.Purchase&gt;" />
[Route("api/[controller]")]
[ApiController]
public class PurchaseController : GenericBaseController<Purchase>
{
    private readonly IPurchaseService _purchaseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="PurchaseController"/> class.
    /// </summary>
    /// <param name="purchasesMasterService">The purchases master service.</param>
    public PurchaseController(IPurchaseService purchasesMasterService) : base(purchasesMasterService)
    {
        _purchaseService = purchasesMasterService;
    }

    /// <summary>
    /// Adds the purchase detail asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddPurchaseDetailAsync([FromBody] PurchaseModel model)
    {
        var res = await _purchaseService.AddPurchaseDetailAsync(model);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// Gets the dropdown asynchronous.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _purchaseService.GetDropdownAsync(searchText);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// Gets the filter asynchronous.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="filterText1">The filter text1.</param>
    /// <returns></returns>
    [HttpGet("filter")]
    public async Task<IActionResult> GetFilterAsync(int pageIndex = CommonVariables.pageIndex,
        int pageSize = CommonVariables.pageSize, string filterText1 = null /*string filterText2 = null*/)
    {
        var res = await _purchaseService.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// Gets the purchase detail asynchronous.
    /// </summary>
    /// <param name="purchaseId">The purchase identifier.</param>
    /// <returns></returns>
    [HttpGet("{purchaseId}")]
    public async Task<IActionResult> GetPurchaseDetailAsync(long purchaseId)
    {
        var res = await _purchaseService.GetPurchaseDetailAsync(purchaseId);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// Gets the search asynchronous.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    [HttpGet("search")]
    public async Task<IActionResult> GetSearchAsync(int pageIndex = CommonVariables.pageIndex,
        int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        var res = await _purchaseService.GetSearchAsync(pageIndex, pageSize, searchText);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// Updates the purchase detail asynchronous.
    /// </summary>
    /// <param name="purchaseId">The purchase identifier.</param>
    /// <param name="purchasesMaster">The purchases master.</param>
    /// <returns></returns>
    [HttpPut("{purchaseId}")]
    public async Task<IActionResult> UpdatePurchaseDetailAsync(long purchaseId,
        [FromBody] PurchaseModel purchasesMaster)
    {
        var res = await _purchaseService.UpdatePurchaseDetailAsync(purchaseId, purchasesMaster);

        return new ApiOkActionResult(res);
    }
}