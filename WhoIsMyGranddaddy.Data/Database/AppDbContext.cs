using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Data.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define schema
        modelBuilder.HasDefaultSchema("site");

        // Configure Persons entity
        modelBuilder.Entity<Person>()
            .ToTable("Persons")
            .HasKey(p => p.Id);

        modelBuilder.Entity<Person>()
            .Property(p => p.Id)
            .HasColumnName("Id");

        modelBuilder.Entity<Person>()
            .Property(p => p.FatherId)
            .HasColumnName("FatherId");

        modelBuilder.Entity<Person>()
            .Property(p => p.MotherId)
            .HasColumnName("MotherId");

        modelBuilder.Entity<Person>()
            .Property(p => p.Name)
            .HasColumnName("Name")
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.Surname)
            .HasColumnName("Surname")
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.BirthDate)
            .HasColumnName("BirthDate")
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Property(p => p.IdentityNumber)
            .HasColumnName("IdentityNumber")
            .IsRequired();

        // Configure foreign key relationships
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Father)
            .WithMany()
            .HasForeignKey(p => p.FatherId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Mother)
            .WithMany()
            .HasForeignKey(p => p.MotherId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    // Define the stored procedure method
    [DbFunction("GetDescendantsByIdentityNumber", schema: "site")]
    public IQueryable<Person> GetDescendantsByIdentityNumber(string? idNumber)
    {
        var parameter = new SqlParameter("@IdentityNumber", string.IsNullOrEmpty(idNumber) ? DBNull.Value : idNumber);
        
        return Set<Person>().FromSqlInterpolated($"[site].[GetDescendantsByIdentityNumber] {parameter}");
    }
    
    // Define the stored procedure method
    [DbFunction("GetRootAscendantsByIdentityNumber", schema: "site")]
    public IQueryable<Person> GetRootAscendantsByIdentityNumber(string idNumber)
    {
        var parameter = new SqlParameter("@IdentityNumber", idNumber);
        return Set<Person>().FromSqlInterpolated($"[site].[GetRootAscendantsByIdentityNumber] {parameter}");
    }
    
    public DbSet<Person> Persons { get; set; }
}
