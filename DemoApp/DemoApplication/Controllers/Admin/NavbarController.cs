using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Book.Add;
using DemoApplication.ViewModels.Admin.Navbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddViewModel = DemoApplication.ViewModels.Admin.Navbar.AddViewModel;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/navbar")]
    public class NavbarController: Controller
    {
        private readonly DataContext _dataContext;
        

        public NavbarController(DataContext dataContext )
        {
            _dataContext = dataContext;
           
        }

        #region List

        [HttpGet("list", Name = "admin-navbar-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Navbars
                .Select(n => new ListItemViewModel
                (n.Title,n.URL, n.Order, n.IsBold, n.IsHeader, n.IsFooter, n.SubNavbars, n.CreatedAt, n.UpdatedAt))
                .ToListAsync();
                       
                       
                     
            return View("~/Views/Admin/Navbar/List.cshtml", model);
        }

        #endregion

        #region Add

        [HttpGet("add", Name = "admin-navbar-add")]
        public async Task<IActionResult> AddAsync()
        {
           
            return View("~/Views/Admin/Navbar/Add.cshtml");
        }

        [HttpPost("add", Name = "admin-navbar-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_dataContext.Navbars.Any(n => n.Order == model.Order))
            {
                ModelState.AddModelError(String.Empty, "This order exists");
                return View("~/Views/Admin/Navbar/Add.cshtml");
            }

            var navbar = new Navbar
            {
                Id = model.Id,
                Title = model.Title,
                URL = model.URL,
                Order = model.Order,
                IsBold = model.IsBold,
                IsHeader = model.IsHeader,
                IsFooter = model.IsFooter,

                CreatedAt = model.CreatedAt


            };
            await _dataContext.Navbars.AddAsync(navbar);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-navbar-list");



        
           
        }


        #endregion
    }
}
