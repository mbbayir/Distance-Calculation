using Microsoft.EntityFrameworkCore;
using BurakAPI.Models;
using Microsoft.Extensions.Configuration;

namespace BurakAPI.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TarifeHesaplayiciModel> TarifeHesaplayiciModels { get; set; }
    }

}
