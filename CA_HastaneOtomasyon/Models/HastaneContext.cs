using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_HastaneOtomasyon.Models;

public partial class HastaneContext : DbContext
{
    public HastaneContext()
    {
    }

    public HastaneContext(DbContextOptions<HastaneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doktorlar> Doktorlars { get; set; }

    public virtual DbSet<HastaBilgileri> HastaBilgileris { get; set; }

    public virtual DbSet<Hastalar> Hastalars { get; set; }

    public virtual DbSet<Odalar> Odalars { get; set; }

    public virtual DbSet<Odemeler> Odemelers { get; set; }

    public virtual DbSet<Randevular> Randevulars { get; set; }

    public virtual DbSet<TahlilSonuclari> TahlilSonuclaris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=ABILGILI\\SQLEXPRESS;database=hastane;Integrated Security=SSPI;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doktorlar>(entity =>
        {
            entity.ToTable("Doktorlar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiplomaTarihi).HasColumnType("date");
            entity.Property(e => e.DoktorAd).HasMaxLength(50);
            entity.Property(e => e.DoktorSoyad).HasMaxLength(50);
            entity.Property(e => e.UzmanlikAlani).HasMaxLength(50);
        });

        modelBuilder.Entity<HastaBilgileri>(entity =>
        {
            entity.ToTable("HastaBilgileri");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adres).HasMaxLength(250);
            entity.Property(e => e.DogumTarihi).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.TelefonNo)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.HastaBilgileri)
                .HasForeignKey<HastaBilgileri>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HastaBilgileri_Hastalar");
        });

        modelBuilder.Entity<Hastalar>(entity =>
        {
            entity.ToTable("Hastalar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HastaAd).HasMaxLength(50);
            entity.Property(e => e.HastaSoyad).HasMaxLength(50);
            entity.Property(e => e.Tckn)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Odalar>(entity =>
        {
            entity.ToTable("Odalar");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Odalar)
                .HasForeignKey<Odalar>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Odalar_Doktorlar");
        });

        modelBuilder.Entity<Odemeler>(entity =>
        {
            entity.ToTable("Odemeler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Miktar).HasColumnType("money");
            entity.Property(e => e.OdemeTarihi).HasColumnType("date");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Odemelers)
                .HasForeignKey(d => d.HastaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Odemeler_Hastalar");
        });

        modelBuilder.Entity<Randevular>(entity =>
        {
            entity.ToTable("Randevular");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RandevuZamani).HasColumnType("datetime");

            entity.HasOne(d => d.Doktor).WithMany(p => p.Randevulars)
                .HasForeignKey(d => d.DoktorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Randevular_Doktorlar");

            entity.HasOne(d => d.Hasta).WithMany(p => p.Randevulars)
                .HasForeignKey(d => d.HastaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Randevular_Hastalar");
        });

        modelBuilder.Entity<TahlilSonuclari>(entity =>
        {
            entity.ToTable("TahlilSonuclari");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TahlilDosyaLinki).HasMaxLength(255);
            entity.Property(e => e.TahlilZamani).HasColumnType("datetime");

            entity.HasOne(d => d.Hasta).WithMany(p => p.TahlilSonuclaris)
                .HasForeignKey(d => d.HastaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TahlilSonuclari_Hastalar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
