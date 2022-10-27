
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using demo1.Models;

namespace demo1.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public DbSet<Apartment>? apartments { get; set; }
        public DbSet<Apartment>? users { get; set; }
        public DbSet<demo1.Models.User> User { get; set; }
    }
}
