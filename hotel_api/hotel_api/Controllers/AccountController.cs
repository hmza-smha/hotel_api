
using hotel_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;
        //private RoleManager<ApplicationUser> _roleManager;

        //public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        //    RoleManager<ApplicationUser> roleManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _roleManager = roleManager;

        //}
        //[HttpPost]
        //public async Task<ApplicationUser> Register(ApplicationUser user)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = user.Username,
        //        Email = user.Email
        //    };

        //    var result = await _userManager.CreateAsync(user, user.Password);

        //    if (result.Succeeded)
        //    {
        //        //await _userManager.AddToRoleAsync(user, "DistrictManager");
        //        //await _userManager.AddToRoleAsync(user, "PropertyManager");
        //        //await _userManager.AddToRoleAsync(user, "Agent");
        //        return user;
        //    }
        //    else
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            var errorKey =
        //                error.Code.Contains("Password") ? nameof(data.Password) :
        //                error.Code.Contains("Email") ? nameof(data.Email) :
        //                error.Code.Contains("UserName") ? nameof(data.Username) :
        //                "";
        //            modelState.AddModelError(errorKey, error.Description);
        //        }
        //        return null;
        //    }
        //}
    }
}
