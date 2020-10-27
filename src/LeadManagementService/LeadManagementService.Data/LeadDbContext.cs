using LeadManagementService.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeadManagementService.Data
{
    public class LeadDbContext : DbContext
    {
        public DbSet<LeadDocument> LeadDocuments { get; set; }

        public LeadDbContext(DbContextOptions<LeadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeadDocument>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<LeadDocument>()
                .Property(p => p.Lead)
                .HasColumnType("jsonb");
        }
            
    }
}