using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pr3;

public partial class PartersPr2Context : DbContext
{
    public PartersPr2Context()
    {
    }

    public PartersPr2Context(DbContextOptions<PartersPr2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersProduct> PartnersProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TypeOfPartner> TypeOfPartners { get; set; }

    public virtual DbSet<TypesProduct> TypesProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=PartersPR2;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Partners_pkey");

            entity.Property(e => e.DirectorName).HasColumnName("Director name");
            entity.Property(e => e.Inn).HasColumnName("INN");

            entity.HasOne(d => d.IdTypePartnerNavigation).WithMany(p => p.Partners)
                .HasForeignKey(d => d.IdTypePartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partners_typesPartner");
        });

        modelBuilder.Entity<PartnersProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Partners_Product_pkey");

            entity.ToTable("Partners_Products");

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Partners_Product_Id_seq\"'::regclass)");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.IdPartner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partners_products_partners");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.PartnersProducts)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_partners_products_products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Products_pkey");

            entity.Property(e => e.MinCostForProduct).HasColumnType("money");

            entity.HasOne(d => d.IdTypeProductNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdTypeProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_products");
        });

        modelBuilder.Entity<TypeOfPartner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypeOfPartners_pkey");

            entity.Property(e => e.TypeOfPartner1).HasColumnName("TypeOfPartner");
        });

        modelBuilder.Entity<TypesProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesProducts_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
