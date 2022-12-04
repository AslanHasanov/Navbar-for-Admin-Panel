using DemoApplication.Database.Models.Common;
using NavbarAdminPanel.Database.Models;

namespace DemoApplication.Database.Models
{
    public class Navbar: BaseEntity, IAuditable
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public bool IsBold { get; set; }
        public bool IsHeader { get; set; }
        public bool IsFooter { get; set; }
        public List<SubNavbar> SubNavbars { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
