using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.Book.Add;
using DemoApplication.ViewModels.Admin.Navbar;
using DemoApplication.ViewModels.Admin.SubNavbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NavbarAdminPanel.Database.Models;
using AddViewModel = DemoApplication.ViewModels.Admin.SubNavbar.AddViewModel;
using ListItemViewModel = DemoApplication.ViewModels.Admin.SubNavbar.ListItemViewModel;
using UpdateViewModel = DemoApplication.ViewModels.Admin.SubNavbar.UpdateViewModel;

namespace DemoApplication.Controllers.Admin
{
    [Route("admin/subnavbar")]
    public class SubNavbarController : Controller
    {
        private readonly DataContext _dataContext;
        

        public SubNavbarController(DataContext dataContext )
        {
            _dataContext = dataContext;
           
        }

        #region List

        [HttpGet("list", Name = "admin-subnavbar-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.SubNavbars
                
                .Select(sn => new ListItemViewModel
                (sn.Id, sn.Title,sn.URL,sn.Order, sn.Navbar.Title ))
                .ToListAsync();
                       
                       
                     
            return View("~/Views/Admin/SubNavbar/List.cshtml", model);
        }

        #endregion

        #region Add

        [HttpGet("add", Name = "admin-subnavbar-add")]
        public async Task<IActionResult> AddAsync()
        {
            var model = new AddViewModel
            {
                Navbar = await _dataContext.Navbars.Select(n => new NavListItemViewModel(n.Id, n.Title)).ToListAsync()
            };
            return View("~/Views/Admin/SubNavbar/Add.cshtml",model);
        }

        [HttpPost("add", Name = "admin-subnavbar-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           
            var subNavbar = new SubNavbar
            {
                Id = model.Id,
                Title = model.Title,
                URL = model.URL,
                NavbarId = model.NavbarId,
                Order= model.Order,
             
           


            };
            await _dataContext.SubNavbars.AddAsync(subNavbar);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-subnavbar-list");





        }


        #endregion




        #region Update

        [HttpGet("update/{id}", Name = "admin-subnavbar-update")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(b => b.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {
                Id = subnavbar.Id,
                Title = subnavbar.Title,
                URL = subnavbar.URL,
                Order = subnavbar.Order,
                NavbarId= subnavbar.NavbarId,
                Navbar = await _dataContext.Navbars
                    .Select(n => new NavListItemViewModel(n.Id , n.Title))
                    .ToListAsync()


            };

            return View("~/Views/Admin/SubNavbar/Update.cshtml", model);
        }

        [HttpPost("update/{id}", Name = "admin-subnavbar-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {
            var subnavbar = await _dataContext.SubNavbars.Include(n => n.Navbar).FirstOrDefaultAsync(n => n.Id == model.Id);
            if (subnavbar is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/SubNavbar/Update.cshtml");
            }


            subnavbar.Title = model.Title;
            subnavbar.URL = model.URL;
            subnavbar.Order = model.Order;
            subnavbar.NavbarId = model.NavbarId;

 
           

            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-subnavbar-list");
        }

        #endregion

        #region Delete 

        [HttpPost("delete/{id}", Name = "admin-subnavbar-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(n => n.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            _dataContext.SubNavbars.Remove(subnavbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-subnavbar-list");
        }
        #endregion
    }
}
