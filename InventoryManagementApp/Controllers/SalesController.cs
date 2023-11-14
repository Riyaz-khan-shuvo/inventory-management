using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers.Configurations;

/// <inheritdoc />
[Route("api/[controller]")]
[ApiController]
public class SalesController : GenericBaseController<Sales>
{
    private readonly ISalesService _salesService;

    /// <inheritdoc />
    public SalesController(ISalesService salesService) : base(salesService)
    {
        _salesService = salesService;
    }
    /// <summary>
    /// Gets the dropdown asynchronous.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _salesService.GetDropdownAsync(searchText);

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
        var res = await _salesService.GetSearchAsync(pageIndex, pageSize, searchText);

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
        var res = await _salesService.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Gets the sales detail asynchronous.
    /// </summary>
    /// <param name="salesId">The sales identifier.</param>
    /// <returns></returns>
    [HttpGet("{salesId}")]
    public async Task<IActionResult> GetSalesDetailAsync(long salesId)
    {
        var res = await _salesService.GetSalesDetailAsync(salesId);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Adds the sales detail asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> AddSalesDetailAsync([FromForm] SalesModel model)
    {
        var res = await _salesService.AddSalesDetailAsync(model);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Updates the sales detail asynchronous.
    /// </summary>
    /// <param name="salesId">The sales identifier.</param>
    /// <param name="sales">The sales.</param>
    /// <returns></returns>
    [HttpPut("{salesId}")]
    public async Task<IActionResult> UpdateSalesDetailAsync(long salesId, [FromForm] SalesModel sales)
    {

        var res = await _salesService.UpdateSalesDetailAsync(salesId, sales);

        return new ApiOkActionResult(res);
    }
}