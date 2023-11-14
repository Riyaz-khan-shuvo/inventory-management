using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers;

/// <inheritdoc />
[Route("api/[controller]")]
[ApiController]
public class DamageController : GenericBaseController<Damage>
{
    private readonly IDamageService _damage;

    /// <inheritdoc />
    public DamageController(IDamageService damage) : base(damage)
    {
        _damage= damage;
    }
    /// <summary>
    /// Gets the dropdown asynchronous.
    /// </summary>
    /// <param name="searchText">The search text.</param>
    /// <returns></returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _damage.GetDropdownAsync(searchText);

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
        var res = await _damage.GetSearchAsync(pageIndex, pageSize, searchText);

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
        var res = await _damage.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Gets the damage details asynchronous.
    /// </summary>
    /// <param name="damageId">The damage identifier.</param>
    /// <returns></returns>
    [HttpGet("{damageId}")]
    public async Task<IActionResult> GetDamageDetailsAsync(long damageId)
    {
        var res = await _damage.GetDamageDetailsAsync(damageId);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Adds the damage details asynchronous.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> AddDamageDetailsAsync([FromBody] DamageModel model)
    {
        var res = await _damage.AddDamageDetailsAsync(model);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// Updates the damage details asynchronous.
    /// </summary>
    /// <param name="damageId">The damage identifier.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    [HttpPut("{damageId}")]
    public async Task<IActionResult> UpdateDamageDetailsAsync(long damageId, [FromBody] DamageModel model)
    {

        var res = await _damage.UpdateDamageDetailsAsync(damageId, model);

        return new ApiOkActionResult(res);
    }
}