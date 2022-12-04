using NavbarAdminPanel.Database.Models;

namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public int NavbarId { get; set; }
        public List<NavListItemViewModel>? Navbar { get; set; }

      
    }
}
