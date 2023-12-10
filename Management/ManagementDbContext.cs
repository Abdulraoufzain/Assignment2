using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Management;

public partial class ManagementDbContext : DbContext
{
    public ManagementDbContext()
    {

    }
    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarsPart> CarsParts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = ManagementDB")
        .LogTo(log =>
         Console.WriteLine(log),
         new[] { DbLoggerCategory.Database.Command.Name },
         Microsoft.Extensions.Logging.LogLevel.Information)
         .EnableServiceProviderCaching();
        
    }
    // توضح هذه الدالة العلاقات بين الجداول وخصائص الاعمدة 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.Property(e => e.Id)
                  .ValueGeneratedNever();
            entity.Property(e => e.Gear)
                  .HasMaxLength(10)
                  .IsFixedLength();
            entity.Property(e => e.KmKm)
                  .HasMaxLength(10)
                  .IsFixedLength()
                  .HasColumnName("KM\r\nKM");
            entity.Property(e => e.Model)
                  .HasMaxLength(10)
                  .IsFixedLength();
            entity.Property(e => e.Year)
                  .HasColumnType("date");
        });

        modelBuilder.Entity<CarsPart>(entity =>
        {
            entity.HasNoKey();

             entity.HasOne(d => d.Car).WithMany()
                   .HasForeignKey(d => d.CarId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_CarsParts_Cars");

             entity.HasOne(d => d.Part).WithMany()
                   .HasForeignKey(d => d.PartId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarsParts_Parts");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id)
                  .ValueGeneratedNever();
            entity.Property(e => e.Address)
                  .HasMaxLength(10)
                  .IsFixedLength();
            entity.Property(e => e.Age)
                  .HasMaxLength(10)
                  .IsFixedLength();
            entity.Property(e => e.Name)
                  .HasMaxLength(10)
                  .IsFixedLength();
        });

        modelBuilder.Entity<Part>(entity =>
        {
             entity.Property(e => e.Id).ValueGeneratedNever();
             entity.Property(e => e.Name)
                   .HasMaxLength(10)
                   .IsFixedLength();
             entity.Property(e => e.Price)
                   .HasMaxLength(10)
                   .IsFixedLength();
             entity.Property(e => e.Qunantity)
                .HasMaxLength(10)
                .IsFixedLength();

             entity.HasOne(d => d.Supliers).WithMany(p => p.Parts)
                   .HasForeignKey(d => d.SupliersId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Parts_Suppliers");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
              entity.Property(e => e.Id).ValueGeneratedNever();
              entity.Property(e => e.Total)
                    .HasMaxLength(10)
                    .IsFixedLength();

              entity.HasOne(d => d.Car).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_Cars");

              entity.HasOne(d => d.Coustomer).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CoustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rela");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
               entity.Property(e => e.Id).ValueGeneratedNever();
               entity.Property(e => e.Address)
                     .HasMaxLength(10)
                     .IsFixedLength();
               entity.Property(e => e.Name)
                     .HasMaxLength(10)
                     .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
