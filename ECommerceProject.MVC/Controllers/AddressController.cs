using ECommerceProject.BL.Services.Contracts;
using ECommerceProject.BL.ViewModels;
using ECommerceProject.DA.DataContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly UserManager<AppUser> _userManager;

        public AddressController(IAddressService addressService, UserManager<AppUser> userManager)
        {
            _addressService = addressService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var adresses = await _addressService.GetAllAsync(predicate: x => !x.IsDeleted);

            return View(adresses.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Address));

            if (User.Identity!.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
                model.AppUserId = user!.Id;
            }

            await _addressService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var addressViewModel = await _addressService.GetByIdAsync(id);

            if (addressViewModel == null)
                return NotFound();

            var addressUpdateViewModel = new AddressUpdateViewModel
            {
                Id = id,
                FirstName = addressViewModel.FirstName,
                LastName = addressViewModel.LastName,
                Adress = addressViewModel.Adress,
                PostalCode = addressViewModel.PostalCode,
                Phone = addressViewModel.Phone,
                Company = addressViewModel.Company,
                City = addressViewModel.City,
                Country = addressViewModel.Country,
            };

            return PartialView("_EditAddressPartial", addressUpdateViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var address = await _addressService.GetByIdAsync(id);

            if (address == null)
                return BadRequest();

            var deleted = await _addressService.DeleteAsync(id);

            if (deleted)
                return NoContent();
            else
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddressUpdateViewModel model)
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
            existedAddress.Phone = model.Phone;
            existedAddress.PostalCode = model.PostalCode;
            existedAddress.Country = model.Country;
            existedAddress.Adress = model.Adress;

            var updated = await _addressService.UpdateAsync(id, model);

            if (updated)
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
    }
}
