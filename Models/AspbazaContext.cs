using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Aplikacja2.Models;

namespace Aplikacja2.Models;

public partial class AspbazaContext : DbContext
{
    public AspbazaContext()
    {
    }

    public AspbazaContext(DbContextOptions<AspbazaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kategorie> Kategories { get; set; }

    public virtual DbSet<Komentarze> Komentarzes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Tagi> Tagis { get; set; }

    public virtual DbSet<Uzytkownicy> Uzytkownicies { get; set; }

    public virtual DbSet<PostKategorie> PostKategories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1CFKOAP\\SQLEXPRESS;Database=ASPBaza1;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kategorie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kategori__3213E83F67C52F77");

            entity.ToTable("kategorie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Komentarze>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__komentar__3213E83FB3F9E713");

            entity.ToTable("komentarze");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Tresc).HasColumnName("tresc");
            entity.Property(e => e.UzytkownikId).HasColumnName("uzytkownik_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Komentarzes)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__komentarz__post___4316F928");

            entity.HasOne(d => d.Uzytkownik).WithMany(p => p.Komentarzes)
                .HasForeignKey(d => d.UzytkownikId)
                .HasConstraintName("FK__komentarz__uzytk__4222D4EF");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post__3213E83F747EAAA3");

            entity.ToTable("post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataUtworzenia)
                .HasColumnType("datetime")
                .HasColumnName("data_utworzenia");
            entity.Property(e => e.Tresc).HasColumnName("tresc");
            entity.Property(e => e.Tytul)
                .HasMaxLength(255)
                .HasColumnName("tytul");
            entity.Property(e => e.UzytkownikId).HasColumnName("uzytkownik_id");

            entity.HasOne(d => d.Uzytkownik).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UzytkownikId)
                .HasConstraintName("FK__post__uzytkownik__398D8EEE");

            entity.HasMany(d => d.Kategoria).WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostKategorie",
                    r => r.HasOne<Kategorie>().WithMany()
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__post_kate__kateg__3F466844"),
                    l => l.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__post_kate__post___3E52440B"),
                    j =>
                    {
                        j.HasKey("PostId", "KategoriaId").HasName("PK__post_kat__23A3DBF287AAA5E6");
                        j.ToTable("post_kategorie");
                        j.IndexerProperty<int>("PostId").HasColumnName("post_id");
                        j.IndexerProperty<int>("KategoriaId").HasColumnName("kategoria_id");
                    });

            entity.HasMany(d => d.Tags).WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTagi",
                    r => r.HasOne<Tagi>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__post_tagi__tag_i__48CFD27E"),
                    l => l.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__post_tagi__post___47DBAE45"),
                    j =>
                    {
                        j.HasKey("PostId", "TagId").HasName("PK__post_tag__4AFEED4D83382A9C");
                        j.ToTable("post_tagi");
                        j.IndexerProperty<int>("PostId").HasColumnName("post_id");
                        j.IndexerProperty<int>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Tagi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tagi__3213E83FAB4AFFC2");

            entity.ToTable("tagi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Uzytkownicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__uzytkown__3213E83F186BCE24");

            entity.ToTable("uzytkownicy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Haslo)
                .HasMaxLength(255)
                .HasColumnName("haslo");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(255)
                .HasColumnName("nazwa");
        });
        modelBuilder.Entity<PostKategorie>()
        .HasKey(pk => new { pk.PostId, pk.KategoriaId });

        modelBuilder.Entity<PostKategorie>()
            .HasOne(pk => pk.Post)
            .WithMany(p => p.PostKategorie)
            .HasForeignKey(pk => pk.PostId);

        modelBuilder.Entity<PostKategorie>()
            .HasOne(pk => pk.Kategoria)
            .WithMany(k => k.PostKategorie)
            .HasForeignKey(pk => pk.KategoriaId);



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Aplikacja2.Models.PostKategorie> PostKategorie { get; set; } = default!;
}
