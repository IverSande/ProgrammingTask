using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class AritmaContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AritmaContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AritmaContext(DbContextOptions<AritmaContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<TypeLoan> TypeLoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("vercelTest"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("loan_pkey");

            entity.ToTable("loan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.LoanType)
                .HasColumnType("character varying")
                .HasColumnName("loan_type");

            entity.HasOne(d => d.LoanTypeNavigation).WithMany(p => p.Loans)
                .HasForeignKey(d => d.LoanType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk");
        });

        modelBuilder.Entity<TypeLoan>(entity =>
        {
            entity.HasKey(e => e.LoanType).HasName("loan_types_pkey");

            entity.ToTable("type_loans");

            entity.Property(e => e.LoanType)
                .HasColumnType("character varying")
                .HasColumnName("loan_type");
            entity.Property(e => e.Interest).HasColumnName("interest");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
