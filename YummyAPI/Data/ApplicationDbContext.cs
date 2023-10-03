using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YummyAPI.Models;

namespace YummyAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<EcomPortfolio> ecomPortfolios { get; set; }

        public DbSet<Book>  Books { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
