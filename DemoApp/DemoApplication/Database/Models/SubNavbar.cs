using DemoApplication.Database.Models;
using DemoApplication.Database.Models.Common;

namespace NavbarAdminPanel.Database.Models
{
    public class SubNavbar : BaseEntity
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public int NavbarId { get; set; }
        public Navbar Navbar { get; set; }

    }
}
