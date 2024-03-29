﻿// <auto-generated />
using System;
using Aplikacja2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplikacja2.Migrations
{
    [DbContext(typeof(AspbazaContext))]
    partial class AspbazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aplikacja2.Models.Kategorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nazwa");

                    b.HasKey("Id")
                        .HasName("PK__kategori__3213E83F67C52F77");

                    b.ToTable("kategorie", (string)null);
                });

            modelBuilder.Entity("Aplikacja2.Models.Komentarze", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tresc");

                    b.Property<int?>("UzytkownikId")
                        .HasColumnType("int")
                        .HasColumnName("uzytkownik_id");

                    b.HasKey("Id")
                        .HasName("PK__komentar__3213E83FB3F9E713");

                    b.HasIndex("PostId");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("komentarze", (string)null);
                });

            modelBuilder.Entity("Aplikacja2.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataUtworzenia")
                        .HasColumnType("datetime")
                        .HasColumnName("data_utworzenia");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tresc");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("tytul");

                    b.Property<int?>("UzytkownikId")
                        .HasColumnType("int")
                        .HasColumnName("uzytkownik_id");

                    b.HasKey("Id")
                        .HasName("PK__post__3213E83F747EAAA3");

                    b.HasIndex("UzytkownikId");

                    b.ToTable("post", (string)null);
                });

            modelBuilder.Entity("Aplikacja2.Models.PostKategorie", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "KategoriaId");

                    b.HasIndex("KategoriaId");

                    b.ToTable("PostKategorie");
                });

            modelBuilder.Entity("Aplikacja2.Models.Tagi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nazwa");

                    b.HasKey("Id")
                        .HasName("PK__tagi__3213E83FAB4AFFC2");

                    b.ToTable("tagi", (string)null);
                });

            modelBuilder.Entity("Aplikacja2.Models.Uzytkownicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("haslo");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("nazwa");

                    b.HasKey("Id")
                        .HasName("PK__uzytkown__3213E83F186BCE24");

                    b.ToTable("uzytkownicy", (string)null);
                });

            modelBuilder.Entity("PostKategorie", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<int>("KategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("kategoria_id");

                    b.HasKey("PostId", "KategoriaId")
                        .HasName("PK__post_kat__23A3DBF287AAA5E6");

                    b.HasIndex("KategoriaId");

                    b.ToTable("post_kategorie", (string)null);
                });

            modelBuilder.Entity("PostTagi", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("post_id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("PostId", "TagId")
                        .HasName("PK__post_tag__4AFEED4D83382A9C");

                    b.HasIndex("TagId");

                    b.ToTable("post_tagi", (string)null);
                });

            modelBuilder.Entity("Aplikacja2.Models.Komentarze", b =>
                {
                    b.HasOne("Aplikacja2.Models.Post", "Post")
                        .WithMany("Komentarzes")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK__komentarz__post___4316F928");

                    b.HasOne("Aplikacja2.Models.Uzytkownicy", "Uzytkownik")
                        .WithMany("Komentarzes")
                        .HasForeignKey("UzytkownikId")
                        .HasConstraintName("FK__komentarz__uzytk__4222D4EF");

                    b.Navigation("Post");

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Aplikacja2.Models.Post", b =>
                {
                    b.HasOne("Aplikacja2.Models.Uzytkownicy", "Uzytkownik")
                        .WithMany("Posts")
                        .HasForeignKey("UzytkownikId")
                        .HasConstraintName("FK__post__uzytkownik__398D8EEE");

                    b.Navigation("Uzytkownik");
                });

            modelBuilder.Entity("Aplikacja2.Models.PostKategorie", b =>
                {
                    b.HasOne("Aplikacja2.Models.Kategorie", "Kategoria")
                        .WithMany("PostKategorie")
                        .HasForeignKey("KategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplikacja2.Models.Post", "Post")
                        .WithMany("PostKategorie")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("PostKategorie", b =>
                {
                    b.HasOne("Aplikacja2.Models.Kategorie", null)
                        .WithMany()
                        .HasForeignKey("KategoriaId")
                        .IsRequired()
                        .HasConstraintName("FK__post_kate__kateg__3F466844");

                    b.HasOne("Aplikacja2.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__post_kate__post___3E52440B");
                });

            modelBuilder.Entity("PostTagi", b =>
                {
                    b.HasOne("Aplikacja2.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__post_tagi__post___47DBAE45");

                    b.HasOne("Aplikacja2.Models.Tagi", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .IsRequired()
                        .HasConstraintName("FK__post_tagi__tag_i__48CFD27E");
                });

            modelBuilder.Entity("Aplikacja2.Models.Kategorie", b =>
                {
                    b.Navigation("PostKategorie");
                });

            modelBuilder.Entity("Aplikacja2.Models.Post", b =>
                {
                    b.Navigation("Komentarzes");

                    b.Navigation("PostKategorie");
                });

            modelBuilder.Entity("Aplikacja2.Models.Uzytkownicy", b =>
                {
                    b.Navigation("Komentarzes");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
