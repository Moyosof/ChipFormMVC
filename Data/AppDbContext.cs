using ChipsForm.Models;
using Microsoft.EntityFrameworkCore;

namespace ChipsForm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Form> Forms { get; set; }
    }
}
