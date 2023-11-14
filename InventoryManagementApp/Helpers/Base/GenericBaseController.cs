using InventoryManagement.Service.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Helpers.Base;

/// <inheritdoc />
public class GenericBaseController<T> : UserInfoBase where T : class
{
    /// <summary>
    /// The service
    /// </summary>
    protected readonly IBaseService<T> _service;

    /// <inheritdoc />
    public GenericBaseController(IBaseService<T> service)
    {
        _service = service;
    }

    /// <summary>
    /// Gets the page asynchronous.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <returns></returns>
    [HttpGet("page")]
    public virtual async Task<IActionResult> GetPageAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize)
    {
        var data = await _service.GetPageAsync(pageIndex, pageSize);

        return new ApiOkActionResult(data);
    }

    /// <summary>
    /// Finds the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpGet("find/{id}")]
    public async Task<IActionResult> FindAsync(long id)
    {
        return Ok(await _service.FindAsync(id));
    }

    //[HttpGet("gets")]
    //public virtual async Task<IActionResult> GetsAsync()
    //{
    //    return Ok(await _service.GetAllAsync());
    //}

    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    [HttpPost("add")]
    public virtual async Task<IActionResult> AddAsync(T entity)
    {
        var res = await _service.InsertAsync(entity);
        return Created("", res);
    }

    /// <summary>
    /// Edits the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    [HttpPut("edit/{id}")]
    public virtual async Task<IActionResult> EditAsync(long id, T entity)
    {
        var res = await _service.UpdateAsync(id, entity);
        return Ok(res);
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    [HttpDelete("delete/{id}")]
    public virtual async Task<IActionResult> DeleteAsync(long id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    [HttpPost("delete")]
    public virtual async Task<IActionResult> DeleteAsync(T entity)
    {
        Type type = entity.GetType();
        var Id = (long)type.GetProperty("Id")?.GetValue(entity)!;
        await _service.DeleteAsync(Id);
        return NoContent();
    }
}