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
                (n.Id, n.Title,n.URL, n.Order, n.IsBold, n.IsHeader, n.IsFooter, n.CreatedAt, n.UpdatedAt))
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
            if(!model.IsFooter && !model.IsHeader)
            {
                ModelState.AddModelError(String.Empty, "Navbar should be header or footer");
                return View("~/Views/Admin/Navbar/Add.cshtml", model);
            }
            if (!ModelState.IsValid) 
            {
                return View("~/Views/Admin/Navbar/Add.cshtml", model);
            }

            if (_dataContext.Navbars.Any(n => n.Order == model.Order))
            {
                ModelState.AddModelError(String.Empty, "This order exists");
                return View("~/Views/Admin/Navbar/Add.cshtml", model);
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

                CreatedAt = DateTime.Now


            };
            await _dataContext.Navbars.AddAsync(navbar);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-navbar-list");



        
           
        }


        #endregion


        #region Update

        [HttpGet("update/{id}", Name = "admin-navbar-update")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(b => b.Id == id);
            if (navbar is null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {
                Title = navbar.Title,
                URL = navbar.URL,
                Order = navbar.Order,
                IsBold = navbar.IsBold,
                IsHeader = navbar.IsHeader,
                IsFooter = navbar.IsFooter
            };

            return View("~/Views/Admin/Navbar/Update.cshtml", model);
        }

        [HttpPost("update/{id}", Name = "admin-navbar-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {
            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == model.Id);
            if (navbar is null)
            {
                return NotFound();
            }

            if (!model.IsFooter && !model.IsHeader)
            {
                ModelState.AddModelError(String.Empty, "Navbar should be header or footer");
                return View("~/Views/Admin/Navbar/Update.cshtml", model);
            }

            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/Navbar/Update.cshtml");
            }


            navbar.Title = model.Title;
            navbar.URL = model.URL;
            navbar.Order = model.Order;
            navbar.IsHeader = model.IsHeader;
            navbar.IsFooter = model.IsFooter;
            navbar.UpdatedAt = DateTime.Now;

            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-navbar-list");
        }

        #endregion



        #region Delete

        [HttpPost("delete/{id}", Name = "admin-navbar-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id);
            if (navbar is null)
            {
                return NotFound();
            }

            _dataContext.Navbars.Remove(navbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-navbar-list");
        }

        #endregion
    }
}
