using InventoryManagement.Core;
using InventoryManagement.Core.Collections;

namespace InventoryManagement.Service.Services.Base;

public interface IBaseService<T> where T : class
{
    /// <summary>
    /// Gets the page asynchronous.
    /// </summary>
    /// <param name="pageIndex">Index of the page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <returns></returns>
    Task<Paging<T>> GetPageAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize);
    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<List<T>> GetAllAsync();
    /// <summary>
    /// Finds the asynchronous.
    /// </summary>
    /// <param name="Id">The identifier.</param>
    /// <returns></returns>
    Task<T> FindAsync(long Id);
    /// <summary>
    /// Firsts the or default asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<T> FirstOrDefaultAsync(long id);
    /// <summary>
    /// Inserts the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task<T> InsertAsync(T entity);
    /// <summary>
    /// Inserts the range asynchronous.
    /// </summary>
    /// <param name="entities">The entities.</param>
    /// <returns></returns>
    Task<List<T>> InsertRangeAsync(List<T> entities);
    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task<T> UpdateAsync(long id, T entity);
    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task<T> UpdateAsync(T entity);
    /// <summary>
    /// Updates the range asynchronous.
    /// </summary>
    /// <param name="entities">The entities.</param>
    /// <returns></returns>
    Task<List<T>> UpdateRangeAsync(List<T> entities);
    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task DeleteAsync(long id);
    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    Task DeleteAsync(T entity);
    /// <summary>
    /// Deletes the range asynchronous.
    /// </summary>
    /// <param name="entities">The entities.</param>
    /// <returns></returns>
    Task DeleteRangeAsync(List<T> entities);
}