using NavbarAdminPanel.Database.Models;

namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class NavListItemViewModel
    {   public int Id { get; set; } 
        public string Title { get; set; }
        public NavListItemViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
