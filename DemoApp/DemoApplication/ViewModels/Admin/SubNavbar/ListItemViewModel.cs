using NavbarAdminPanel.Database.Models;

namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class ListItemViewModel
    {   public int Id { get; set; } 
        public string Title { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
    
        public string Navbar { get; set; }

        public ListItemViewModel(int id, string title, string url, int order,  string navbar)
        {
            Id = id;
            Title = title;
            URL = url;
            Order = order;
          
            Navbar = navbar;
        }
    }
}
