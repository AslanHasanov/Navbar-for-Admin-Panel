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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ListItemViewModel(int id ,string title,string url, int order, bool isBold, bool isHeader, bool isFooter,  DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Title = title;
            URL = url;
            Order = order;
            IsBold = isBold;
            IsHeader = isHeader;
            IsFooter = isFooter;
          
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
