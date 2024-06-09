using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class AritmaContext : DbContext
{
    public AritmaContext()
    {
    }

    public AritmaContext(DbContextOptions<AritmaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<TypeLoan> TypeLoans { get; set; }

    //Should not be here with all data
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-falling-wave-a267386u-pooler.eu-central-1.aws.neon.tech;Database=aritma;Username=default;Password=B9wk7ThSjqaD");

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
