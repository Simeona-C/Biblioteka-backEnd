using System;
using System.Collections.Generic;
using Biblioteka.BibliotekaModel;
using Biblioteka.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka;

public partial class LibraryContext : DbContext, ILibraryContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avtor> Avtors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Kategorija> Kategorijas { get; set; }

    public virtual DbSet<Lease> Leases { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DMURBSB;Initial Catalog=Library;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avtor>(entity =>
        {
            entity.ToTable("Avtor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GodinaNaRagjanje).HasColumnName("Godina na ragjanje");
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Prezime).HasMaxLength(50);
            entity.Property(e => e.Zemja).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvtorId).HasColumnName("AvtorID");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.IzdavackaKukja)
                .HasMaxLength(50)
                .HasColumnName("Izdavacka kukja");
            entity.Property(e => e.Jazik).HasMaxLength(50);
            entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");
            entity.Property(e => e.Naslov).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Avtor).WithMany(p => p.Books)
                .HasForeignKey(d => d.AvtorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Avtor");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Books)
                .HasForeignKey(d => d.KategorijaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Kategorija");
        });

        modelBuilder.Entity<Kategorija>(entity =>
        {
            entity.ToTable("Kategorija");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Opis).HasMaxLength(50);
        });

        modelBuilder.Entity<Lease>(entity =>
        {
            entity.ToTable("Lease");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Book).WithMany(p => p.Leases)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lease_Books");

            entity.HasOne(d => d.Member).WithMany(p => p.Leases)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lease_Members");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Prezime).HasMaxLength(50);
            entity.Property(e => e.TelefonskiBroj).HasColumnName("Telefonski broj");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
