using System.Data;
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

    /// <summary>
    /// Stored Procedure execution to retrieve Descendants in a tree (Identity number specified or not)
    /// </summary>
    /// <param name="identityNumber">The identity number</param>
    /// <param name="pageNumber">The page number</param>
    /// <returns></returns>
    //[DbFunction("GetDescendantsByIdentityNumber", schema: "site")]
    public Tuple<IQueryable<Person>, int> GetDescendantsByIdentityNumber(string? identityNumber, int pageNumber)
    {
        var idParameter = new SqlParameter("@IdentityNumber", string.IsNullOrEmpty(identityNumber) ? DBNull.Value : (object)identityNumber);
        var pageSizeParameter = new SqlParameter("@PageSize", 8);
        var pageNumberParameter = new SqlParameter("@PageNumber", pageNumber);

        var maxPagesParameter = new SqlParameter
        {
            ParameterName = "@MaxPages",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };

        var persons = Set<Person>()
            .FromSqlInterpolated(
                $"[site].[GetDescendantsByIdentityNumber] {idParameter}, {pageSizeParameter}, {pageNumberParameter}, {maxPagesParameter}");
        

        // Retrieve the value of the output parameter
        var maxPages = (int)maxPagesParameter.Value;

        return Tuple.Create(persons, maxPages);
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
