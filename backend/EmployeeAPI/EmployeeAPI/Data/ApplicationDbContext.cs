using EmployeeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Qualification> Qualifications { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost; Database=EmployeeDb; Integrated Security=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1,
                    Name = "School Leaving Certificate",
                    Alias = "SLC"
                },
                new Qualification
                {
                    Id = 2,
                    Name = "Higher Secondary School",
                    Alias = "10 +2"
                },
                new Qualification
                {
                    Id = 3,
                    Name = "Bachelor",
                    Alias = "Bachelor"
                },
                new Qualification
                {
                    Id = 4,
                    Name = "Master",
                    Alias = "Master"
                });
        }
    }
}
