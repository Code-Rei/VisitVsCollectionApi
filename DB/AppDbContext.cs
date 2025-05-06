using ClientAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UnitWise> UnitWise { get; set; }
        public DbSet<odNPA> odNPA { get; set; }
    }
}
