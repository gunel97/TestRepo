using ECommerceProject.BL.Services;
using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using ECommerceProject.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Threading.Tasks;

namespace ECommerceProject.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAddressService _addressService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IAddressService addressService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _addressService = addressService;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var username = User.Identity!.Name ?? "";

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return BadRequest();

            var model = new AccountViewModel
            {
                UserName = user.UserName,
            };

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var user = new AppUser
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect.");

                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

            if(result.IsLockedOut)
            {
                ModelState.AddModelError("", $"You are banned {user.LockoutEnd.Value.AddHours(4).ToString()}.");

                return View(model);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is incorrect.");

                return View(model);
            }

            if (!string.IsNullOrEmpty(model.ReturnUrl))
                return Redirect(model.ReturnUrl);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var username = User.Identity!.Name ?? "";

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return BadRequest();

            var editAccountViewModel = new EditAccountViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                
            };
            

            return View(editAccountViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //find user
            var username = User.Identity!.Name ?? "";

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return BadRequest();

            //check password
            if (!string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                var resultPassword = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!resultPassword.Succeeded)
                {
                    foreach (var error in resultPassword.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }

            if (model.Email != user.Email /*&& !string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(user.Email)*/)
            {
                var resultEmail = await _userManager.SetEmailAsync(user, model.Email);
                if (!resultEmail.Succeeded)
                {
                    foreach (var error in resultEmail.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }

            if (model.FirstName != user.FirstName)
                user.FirstName = model.FirstName;

            if (model.LastName != user.LastName)
                user.LastName = model.LastName;

            var resultTotal = await _userManager.UpdateAsync(user);

            if (!resultTotal.Succeeded)
            {
                foreach(var error in resultTotal.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return RedirectToAction(nameof(Index));

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToWishlist(int id)
        {
            return NoContent();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public async Task <IActionResult> Address()
        {
            //var model = await _accountService.GetAddressViewModelsAsync();

            //return View(model);

            var adresses = await _addressService.GetAllAsync(predicate: x => !x.IsDeleted);

            return View(adresses.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Address));

            if (User.Identity!.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
                model.AppUserId = user!.Id;
            }

            await _addressService.CreateAsync(model);

            return RedirectToAction(nameof(Address));
        }

        public async Task<IActionResult> EditAddress(int id)
        {
            var addressViewModel = await _addressService.GetByIdAsync(id);

            if (addressViewModel == null)
                return NotFound();

            var addressUpdateViewModel = new AddressUpdateViewModel
            {
                Id= id,
                FirstName = addressViewModel.FirstName,
                LastName = addressViewModel.LastName,
                Adress = addressViewModel.Adress,
                PostalCode=addressViewModel.PostalCode,
                Phone=addressViewModel.Phone,
                Company=addressViewModel.Company,
                City=addressViewModel.City,
                Country=addressViewModel.Country,
            };

            return PartialView("_EditAddressPartial", addressUpdateViewModel);
        }

        public async Task<IActionResult> DeleteAddress (int id)
        {
            var address = await _addressService.GetByIdAsync(id);

            if (address == null)
                return BadRequest();

            var deleted = await _addressService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            else
                return RedirectToAction(nameof(Address));
        }

        [HttpPost]
        public async Task<IActionResult> EditAddress (int id, AddressUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existedAddress = await _addressService.GetByIdAsync(id);
            if (existedAddress == null)
                return BadRequest();

            existedAddress.FirstName = model.FirstName;
            existedAddress.LastName = model.LastName;
            existedAddress.Company = model.Company;
            existedAddress.City = model.City;
            existedAddress.Phone=model.Phone;
            existedAddress.PostalCode = model.PostalCode;
            existedAddress.Country = model.Country;
            existedAddress.Adress=model.Adress;

            var updated = await _addressService.UpdateAsync(id, model);

            if (updated)
                return RedirectToAction(nameof(Address));
            else
                return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
