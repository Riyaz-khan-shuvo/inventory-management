using InventoryManagement.Sql.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers.Configurations;

/// <inheritdoc />
[Route("api/[controller]")]
[ApiController]
public class ReturnController : GenericBaseController<Return>
{
    private readonly IReturnService _returnService;

    /// <inheritdoc />
    public ReturnController(IReturnService returnService) : base(returnService)
    {
        _returnService = returnService;
    }
    /// <summary>
    /// Gets the dropdown asynchronous.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _returnService.GetDropdownAsync(searchText);

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
        var res = await _returnService.GetSearchAsync(pageIndex, pageSize, searchText);

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
        var res = await _returnService.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Gets the return detail asynchronous.
    /// </summary>
    /// <param name="returnId">The return identifier.</param>
    /// <returns></returns>
    [HttpGet("{returnId}")]
    public async Task<IActionResult> GetReturnDetailAsync(long returnId)
    {
        var res = await _returnService.GetReturnDetailAsync(returnId);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Adds the return detail asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> AddReturnDetailAsync([FromForm] ReturnModel model)
    {
        var res = await _returnService.AddReturnDetailAsync(model);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Updates the return detail asynchronous.
    /// </summary>
    /// <param name="returnId">The return identifier.</param>
    /// <param name="returns">The returns.</param>
    /// <returns></returns>
    [HttpPut("{returnId}")]
    public async Task<IActionResult> UpdateReturnDetailAsync(long returnId, [FromForm] ReturnModel returns)
    {

        var res = await _returnService.UpdateReturnDetailAsync(returnId, returns);

        return new ApiOkActionResult(res);
    }
}