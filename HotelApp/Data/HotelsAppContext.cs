using HotelApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HotelApp.Data
{
    public class HotelsAppContext : IdentityDbContext<ApplicationUser>
    {
        public HotelsAppContext(DbContextOptions<HotelsAppContext> options) : base(options) { }

        public DbSet<Hotels> Hotels { get; set; }
    }
  
}
        