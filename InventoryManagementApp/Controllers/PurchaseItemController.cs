using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers.Configurations;

/// <inheritdoc />
[Route("api/[controller]")]
[ApiController]
public class PurchaseItemController : GenericBaseController<PurchaseItem>
{
    private readonly IPurchaseItemService _purchaseItemService;

    /// <inheritdoc />
    public PurchaseItemController(IPurchaseItemService purchaseDetailsService) : base(purchaseDetailsService)
    {
        _purchaseItemService = purchaseDetailsService;
    }
    /// <summary>
    /// Gets the dropdown asynchronous.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _purchaseItemService.GetDropdownAsync(searchText);

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
    public async Task<IActionResult> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        var res = await _purchaseItemService.GetSearchAsync(pageIndex, pageSize, searchText);

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
    public async Task<IActionResult> GetFilterAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string filterText1 = null /*string filterText2 = null*/)
    {
        var res = await _purchaseItemService.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Gets the purchase item detail asynchronous.
    /// </summary>
    /// <param name="purchaseDetailsId">The purchase details identifier.</param>
    /// <returns></returns>
    [HttpGet("{purchaseDetailsId}")]
    public async Task<IActionResult> GetPurchaseItemDetailAsync(long purchaseDetailsId)
    {
        var res = await _purchaseItemService.GetPurchaseItemDetailAsync(purchaseDetailsId);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Adds the purchase item detail asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> AddPurchaseItemDetailAsync([FromForm] PurchaseItemModel model)
    {
        var res = await _purchaseItemService.AddPurchaseItemDetailAsync(model);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Updates the purchase item detail asynchronous.
    /// </summary>
    /// <param name="purchaseDetailsId">The purchase details identifier.</param>
    /// <param name="purchaseDetails">The purchase details.</param>
    /// <returns></returns>
    [HttpPut("{purchaseDetailsId}")]
    public async Task<IActionResult> UpdatePurchaseItemDetailAsync(long purchaseDetailsId, [FromForm] PurchaseItemModel purchaseDetails)
    {

        var res = await _purchaseItemService.UpdatePurchaseItemDetailAsync(purchaseDetailsId, purchaseDetails);

        return new ApiOkActionResult(res);
    }

    [HttpDelete("{purchaseDetailsId}")]
    public async Task<IActionResult> DeletePurchaseItemDetailAsync(long purchaseDetailsId)
    {
        var res = await _purchaseItemService.DeletePurchaseItemDetailAsync(purchaseDetailsId);

        return new ApiOkActionResult(res);
    }
}