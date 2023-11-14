using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers;

/// <inheritdoc />
[Route("api/[controller]")]
[ApiController]
public class CurrencyController : GenericBaseController<Currency>
{
    private readonly ICurrencyService _currencyService;

    /// <inheritdoc />
    public CurrencyController(ICurrencyService currencyService) : base(currencyService)
    {
        this._currencyService = currencyService;
    }

    /// <summary>Gets the dropdown asynchronous.</summary>
    /// <param name="searchText">The search text.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _currencyService.GetDropdownAsync(searchText);

        return new ApiOkActionResult(res);
    }

    /// <summary>Gets the search asynchronous.</summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="searchText">The search text.</param>
    /// <returns>
    ///   <br />
    /// </returns>
    [HttpGet("search")]
    public async Task<IActionResult> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        var res = await _currencyService.GetSearchAsync(pageIndex, pageSize, searchText);

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
        var res = await _currencyService.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Gets the currency details asynchronous.
    /// </summary>
    /// <param name="currencyId">The currency identifier.</param>
    /// <returns></returns>
    [HttpGet("{currencyId}")]
    public async Task<IActionResult> GetCurrencyDetailsAsync(long currencyId)
    {
        var res = await _currencyService.GetCurrencyDetailsAsync(currencyId);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Adds the currency details asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> AddCurrencyDetailsAsync([FromForm] CurrencyModel model)
    {
        var res = await _currencyService.AddCurrencyDetailsAsync(model);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Updates the currency details asynchronous.
    /// </summary>
    /// <param name="currencyId">The currency identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPut("{currencyId}")]
    public async Task<IActionResult> UpdateCurrencyDetailsAsync(long currencyId, [FromForm] CurrencyModel model)
    {

        var res = await _currencyService.UpdateCurrencyDetailsAsync(currencyId, model);

        return new ApiOkActionResult(res);
    }
}