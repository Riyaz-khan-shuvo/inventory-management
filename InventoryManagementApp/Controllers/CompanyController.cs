using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Controllers;

/// <inheritdoc />
[Route("api/[controller]")]
[ApiController]
public class CompanyController : GenericBaseController<Company>
{
    private readonly ICompanyService _companyService;

    /// <summary>Initializes a new instance of the <see cref="CompanyController" /> class.</summary>
    /// <param name="companyService">The company service.</param>
    public CompanyController(ICompanyService companyService) : base(companyService)
    {
        this._companyService = companyService;
    }


    /// <summary>
    /// Get Dropdown
    /// </summary>
    /// <param name="searchText"></param>
    /// <returns></returns>
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetDropdownAsync(string searchText = null)
    {
        var res = await _companyService.GetDropdownAsync(searchText);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="searchText"></param>
    /// <returns></returns>
    [HttpGet("search")]
    public async Task<IActionResult> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        var res = await _companyService.GetSearchAsync(pageIndex, pageSize, searchText);

        return new ApiOkActionResult(res);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="filterText1"></param>
    /// <returns></returns>
    [HttpGet("filter")]
    public async Task<IActionResult> GetFilterAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string filterText1 = null /*string filterText2 = null*/)
    {
        var res = await _companyService.GetFilterAsync(pageIndex, pageSize, filterText1 /*filterText2*/);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns></returns>
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetCompanyDetailsAsync(long companyId)
    {
        var res = await _companyService.GetCompanyDetailsAsync(companyId);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost()]
    public async Task<IActionResult> AddCompanyDetailsAsync([FromForm] CompanyModel model)
    {
        var res = await _companyService.AddCompanyDetailsAsync(model);

        return new ApiOkActionResult(res);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="companyId"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("{companyId}")]
    public async Task<IActionResult> UpdateCompanyDetailsAsync(long companyId, [FromForm] CompanyModel model)
    {

        var res = await _companyService.UpdateCompanyDetailsAsync(companyId, model);

        return new ApiOkActionResult(res);
    }
}