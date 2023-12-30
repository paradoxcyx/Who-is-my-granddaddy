﻿using Microsoft.EntityFrameworkCore;
using WhoIsMyGranddaddy.Data.Models;

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

    public DbSet<Person> Persons { get; set; }
}
