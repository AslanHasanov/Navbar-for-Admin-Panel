using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace DemoApplication.ViewComponents
{

    [ViewComponent(Name = "NavbarFooter")]
    public class NavbarViewComponentFooter : ViewComponent
    {
        private readonly DataContext _datacontext;
        public NavbarViewComponentFooter(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _datacontext.Navbars.Include(n=> n.SubNavbars.OrderBy(sn => sn.Order))
                .Where(n => n.IsFooter).OrderBy(n => n.Order).ToList();

            return View("~/Views/Shared/Components/Navbar/NavbarFooter.cshtml", model);
        }
    }
}
