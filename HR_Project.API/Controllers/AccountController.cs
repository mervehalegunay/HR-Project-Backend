using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_Project.API.Models;
using HR_Project.Domain.Entitites.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Project.API.Controllers
{
     [ApiController]
    [Route("api/account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            userManager = userManager;
            signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginVM login)
        {
             if (ModelState.IsValid)
            {
				AppUser appuser = await userManager.FindByNameAsync(login.UserName);
				if (appuser != null)
				{
					if (appuser.isDeleted == false)
					{
						if (appuser.Status == Domain.Enums.Status.Active)
						{
                            await signInManager.SignOutAsync();
                            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appuser, login.Password, false, false);
                            if (result.Succeeded)
                            {
                                bool isUser = await userManager.IsInRoleAsync(appuser, "Standard User");
                                bool isAdmin = await userManager.IsInRoleAsync(appuser, "admin");

                                if (isUser)
                                {
                                    if (Url.IsLocalUrl(login.ReturnUrl))
                                    {
                                        return Redirect(login.ReturnUrl);
                                    }
                                }

                                if (isAdmin)
                                {
                                    return RedirectToAction("Dashboard", "Admin");
                                }
                            }

                            else
                            {
                                ModelState.AddModelError(nameof(login.UserName), "Login failed : username or password is wrong.");
                                return Ok(login);
                            }

                        }

						else
						{
							ModelState.AddModelError(("Inactive"), "Login failed : Account is not active.");

                        }
						
                    }
					else
					{
                        ModelState.AddModelError(("Deleted"), "Login failed : User is deleted.");
                        return Ok(login);
                    }

                    
                }
				else
				{
                    ModelState.AddModelError(nameof(login.UserName), "Login failed : username or password is wrong.");
                }
				
            }
            return Ok("Login successful");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVM user)
        {
           
			if (user.Password != user.RepeatPassword)
			{
				ModelState.AddModelError(nameof(user.Password), "Sign Up Failed : Paswords does not match.");
			}

			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					UserName = user.UserName,
					Email = user.Email,
					FirstName = user.FirstName,
					LastName = user.LastName,
					isDeleted = false

				};


				IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

				if (result.Succeeded)
				{
					string roleName = "Standard User";

					result = await userManager.AddToRoleAsync(appUser, roleName);

					if (!result.Succeeded)
					{
						Errors(result);
					}

					return RedirectToAction("Index");
				}

				else
				{
					foreach (IdentityError item in result.Errors)
					{
						ModelState.AddModelError("Create User", $"{item.Code} - {item.Description}");
					}
				}
			}


            return Ok("Registration successful");
        }

     

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
           
			AppUser user = await userManager.FindByIdAsync(id);

			if (user != null)
			{
				user.isDeleted = true;
				IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Logout");
                }
                else
                {
                    Errors(result);

                }
            }
			else
			{
                ModelState.AddModelError("User", "User Not Found");
            }


            return Ok("User deleted successfully");
        }

        // [HttpGet("profile/{id}")]
        // public async Task<IActionResult> UserProfile(string id)
        // {
        //     // Kullanıcı profil bilgilerini getirme işlemleri
        //     // ...

        //     return Ok("User profile information");
        // }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            
			await signInManager.SignOutAsync();
            return Ok("Logout successful");
        }
        private void Errors(IdentityResult result)
		{
			foreach (IdentityError item in result.Errors)
			{
				ModelState.AddModelError("UpdateUser", $"{item.Code} - {item.Description}");
			}
		}
    }
}