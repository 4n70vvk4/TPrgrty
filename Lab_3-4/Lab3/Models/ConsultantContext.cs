using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class ConsultantContext : DbContext
    {
        public ConsultantContext(DbContextOptions<ConsultantContext> options) : base(options)
        {
        }
        public DbSet<Consultant> Consultants { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
    }
}
