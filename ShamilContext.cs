using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudApi;

public partial class ShamilContext : DbContext
{
    public ShamilContext()
    {
    }

    public ShamilContext(DbContextOptions<ShamilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sassi> Sassis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=(local);database=Shamil;trusted_connection=true;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sassi>(entity =>
        {
            entity.HasKey(e => e.Siraysay).HasName("PK_sassi2");

            entity.ToTable("sassi");

            entity.Property(e => e.Siraysay)
                .ValueGeneratedNever()
                .HasColumnName("siraysay");
            entity.Property(e => e.Ad)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ad");
            entity.Property(e => e.Bolme)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bolme");
            entity.Property(e => e.Haqqindainfo)
                .HasColumnType("text")
                .HasColumnName("haqqindainfo");
            entity.Property(e => e.Isheqebul)
                .HasColumnType("date")
                .HasColumnName("isheqebul");
            entity.Property(e => e.Maas).HasColumnName("maas");
            entity.Property(e => e.Mobilnomre)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mobilnomre");
            entity.Property(e => e.Sifarish).HasColumnName("sifarish");
            entity.Property(e => e.Soyad)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("soyad");
            entity.Property(e => e.Unvan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unvan");
            entity.Property(e => e.Yash)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("yash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
