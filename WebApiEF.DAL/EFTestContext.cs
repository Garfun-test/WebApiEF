using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiEF.DAL.Models;

namespace WebApiEF.DAL
{
    public partial class EFTestContext : IdentityDbContext
    {
        public EFTestContext()
        {
        }

        public EFTestContext(DbContextOptions<EFTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agreement> Agreement { get; set; }
        public virtual DbSet<AgreementDetails> AgreementDetails { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.; database=EFTest; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agreement>(entity =>
            {
                entity.HasKey(e => e.IdAgreement)
                    .HasName("PK__Agreemen__71D3B89F76F05CF1");

                entity.Property(e => e.IdAgreement)
                    .HasColumnName("Id_Agreement")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateAgreement)
                    .HasColumnName("Date_Agreement")
                    .HasColumnType("date");

                entity.Property(e => e.IdClient).HasColumnName("Id_Client");

                entity.HasOne(d => d.Clients)
                    .WithMany(p => p.Agreement)
                    .HasForeignKey(d => d.IdClient);
            });

            modelBuilder.Entity<AgreementDetails>(entity =>
            {
                entity.HasKey(e => new { e.IdAgreement, e.IdProduct })
                    .HasName("PK__Agreemen__176223A15781285A");

                entity.ToTable("Agreement_Details");

                entity.Property(e => e.IdAgreement).HasColumnName("Id_Agreement");

                entity.Property(e => e.IdProduct).HasColumnName("Id_Product");

                entity.HasOne(d => d.IdAgreementNavigation)
                    .WithMany(p => p.AgreementDetails)
                    .HasForeignKey(d => d.IdAgreement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agreement__Id_Ag__2B3F6F97");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.AgreementDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agreement__Id_Pr__2C3393D0");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PK__Clients__668DFF3FE4DC8774");

                entity.Property(e => e.IdClient)
                    .HasColumnName("Id_Client")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);                              
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__6B19B3E751BADAA3");

                entity.Property(e => e.IdProduct)
                    .HasColumnName("Id_Product")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NameProduct)
                    .IsRequired()
                    .HasColumnName("Name_Product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceRetail).HasColumnName("Price_Retail");

                entity.Property(e => e.PriceWholesale).HasColumnName("Price_Wholesale");                
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
