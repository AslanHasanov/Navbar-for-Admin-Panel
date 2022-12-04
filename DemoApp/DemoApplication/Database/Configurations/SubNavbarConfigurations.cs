using DemoApplication.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NavbarAdminPanel.Database.Models;
using System.Reflection.Emit;

namespace DemoApplication.Database.Configurations
{
    public class SubNavbarConfigurations : IEntityTypeConfiguration<SubNavbar>
    {
        public void Configure(EntityTypeBuilder<SubNavbar> builder)
        {
            builder
               .HasOne(b => b.Navbar)
               .WithMany(a => a.SubNavbars)
               .HasForeignKey(b => b.NavbarId);
        }
    }
}
