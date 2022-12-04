using NavbarAdminPanel.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public bool IsBold { get; set; }
        [Required]
        public bool IsHeader { get; set; }
        [Required]
        public bool IsFooter { get; set; }
       
        public DateTime CreatedAt { get; set; }
        public AddViewModel()
        {

        }
        
        public AddViewModel(string title,string url, int order, bool isBold, bool isHeader, bool isFooter,  DateTime createdAt)
        {
            Title = title;
            URL = url;
            Order = order;
            IsBold = isBold;
            IsHeader = isHeader;
            IsFooter = isFooter;
            CreatedAt = createdAt;
       
        }
    }
}
