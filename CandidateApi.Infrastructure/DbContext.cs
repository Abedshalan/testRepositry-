using System.Xml.Linq;
using CandidateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Candidate entity
            modelBuilder.Entity<Candidate>(entity =>
            {
                // Configure Id as the primary key and set it to auto-increment
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                // Configure required fields
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Comment).IsRequired();
            });
        }
    }
}
