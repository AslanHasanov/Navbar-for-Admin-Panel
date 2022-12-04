using NavbarAdminPanel.Database.Models;

namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class ListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public bool IsBold { get; set; }
        public bool IsHeader { get; set; }
        public bool IsFooter { get; set; }
        public List<SubNavbar> SubNavbars { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ListItemViewModel(string title,string url, int order, bool isBold, bool isHeader, bool isFooter, List<SubNavbar> subNavbars, DateTime createdAt, DateTime updatedAt)
        {
            Title = title;
            URL = url;
            Order = order;
            IsBold = isBold;
            IsHeader = isHeader;
            IsFooter = isFooter;
            SubNavbars = subNavbars;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
