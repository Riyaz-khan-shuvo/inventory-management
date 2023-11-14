using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagement.Helpers.Base;

/// <inheritdoc />
public class UserInfoBase : ControllerBase
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    /// <value>
    /// The user identifier.
    /// </value>
    public long? UserId => User.Identity?.IsAuthenticated ?? false ? long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!) : null;

    /// <summary>
    /// Gets the user email.
    /// </summary>
    /// <value>
    /// The user email.
    /// </value>
    public string UserEmail => User.Identity?.IsAuthenticated ?? false ? User.FindFirstValue(ClaimTypes.Email) : null;

    /// <summary>
    /// Gets the mobile number.
    /// </summary>
    /// <value>
    /// The mobile number.
    /// </value>
    public string MobileNumber => User.Identity?.IsAuthenticated ?? false ? User.FindFirstValue(ClaimTypes.MobilePhone) : null;

    /// <summary>
    /// Gets the name of the user.
    /// </summary>
    /// <value>
    /// The name of the user.
    /// </value>
    public string UserName => User.Identity?.IsAuthenticated ?? false ? User.Identity.Name : null;

    /// <summary>
    /// Gets the full name of the user.
    /// </summary>
    /// <value>
    /// The full name of the user.
    /// </value>
    public string UserFullName => User.Identity?.IsAuthenticated ?? false ? User.FindFirstValue(ClaimTypes.GivenName) : null;

    /// <summary>
    /// Gets the roles.
    /// </summary>
    /// <value>
    /// The roles.
    /// </value>
    public List<string> Roles => User.Identity?.IsAuthenticated ?? false ? User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList() : null;

    /// <summary>
    /// Gets a value indicating whether this instance is head office user.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is head office user; otherwise, <c>false</c>.
    /// </value>
    public bool IsHeadOfficeUser => (User.Identity?.IsAuthenticated ?? false) && bool.Parse(User.FindFirstValue("IsHeadOfficeUser")!);
}