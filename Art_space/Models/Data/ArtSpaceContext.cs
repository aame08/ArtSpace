using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Art_space.Models.Data;

public partial class ArtSpaceContext : DbContext
{
    public ArtSpaceContext()
    {
    }

    public ArtSpaceContext(DbContextOptions<ArtSpaceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArtForm> ArtForms { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Epoch> Epoches { get; set; }

    public virtual DbSet<Evaluation> Evaluations { get; set; }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    public virtual DbSet<FavoriteExhibit> FavoriteExhibits { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<StorageLocation> StorageLocations { get; set; }

    public virtual DbSet<TechniqueOfExecution> TechniqueOfExecutions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=ame0372;database=art_space", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ArtForm>(entity =>
        {
            entity.HasKey(e => e.IdArtForm).HasName("PRIMARY");

            entity.ToTable("art_form");

            entity.Property(e => e.IdArtForm).HasColumnName("id_art_form");
            entity.Property(e => e.NameAF)
                .HasMaxLength(50)
                .HasColumnName("name_a_f");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor).HasName("PRIMARY");

            entity.ToTable("authors");

            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.DateBirth).HasColumnName("date_birth");
            entity.Property(e => e.DateDeath).HasColumnName("date_death");
            entity.Property(e => e.NameAuthor)
                .HasMaxLength(50)
                .HasColumnName("name_author");
            entity.Property(e => e.SurnameAuthor)
                .HasMaxLength(50)
                .HasColumnName("surname_author");
        });

        modelBuilder.Entity<Epoch>(entity =>
        {
            entity.HasKey(e => e.IdEra).HasName("PRIMARY");

            entity.ToTable("epoch");

            entity.Property(e => e.IdEra).HasColumnName("id_era");
            entity.Property(e => e.NameEra)
                .HasMaxLength(50)
                .HasColumnName("name_era");
        });

        modelBuilder.Entity<Evaluation>(entity =>
        {
            entity.HasKey(e => new { e.IdExhibit, e.IdUser })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("evaluation");

            entity.HasIndex(e => e.IdUser, "fk_ev_u");

            entity.Property(e => e.IdExhibit).HasColumnName("id_exhibit");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.IdExhibitNavigation).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.IdExhibit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ev_e");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Evaluations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ev_u");
        });

        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.HasKey(e => e.IdExhibit).HasName("PRIMARY");

            entity.ToTable("exhibits");

            entity.HasIndex(e => e.IdArtForm, "fk_e_af");

            entity.HasIndex(e => e.IdEra, "fk_e_e");

            entity.HasIndex(e => e.IdGenre, "fk_e_g");

            entity.HasIndex(e => e.IdStorageLocation, "fk_e_sl");

            entity.Property(e => e.IdExhibit).HasColumnName("id_exhibit");
            entity.Property(e => e.CountryCreation)
                .HasMaxLength(50)
                .HasColumnName("country_creation");
            entity.Property(e => e.DescriptionExhibit)
                .HasColumnType("text")
                .HasColumnName("description_exhibit");
            entity.Property(e => e.IdArtForm).HasColumnName("id_art_form");
            entity.Property(e => e.IdEra).HasColumnName("id_era");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.IdStorageLocation).HasColumnName("id_storage_location");
            entity.Property(e => e.NameExhibit)
                .HasMaxLength(100)
                .HasColumnName("name_exhibit");
            entity.Property(e => e.NumberViews).HasColumnName("number_views");
            entity.Property(e => e.YearCreation).HasColumnName("year_creation");

            entity.HasOne(d => d.IdArtFormNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.IdArtForm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_e_af");

            entity.HasOne(d => d.IdEraNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.IdEra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_e_e");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_e_g");

            entity.HasOne(d => d.IdStorageLocationNavigation).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.IdStorageLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_e_sl");

            entity.HasMany(d => d.IdAuthors).WithMany(p => p.IdExhibits)
                .UsingEntity<Dictionary<string, object>>(
                    "ExhibitsAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("IdAuthor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_ea_a"),
                    l => l.HasOne<Exhibit>().WithMany()
                        .HasForeignKey("IdExhibit")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_ea_e"),
                    j =>
                    {
                        j.HasKey("IdExhibit", "IdAuthor")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("exhibits_authors");
                        j.HasIndex(new[] { "IdAuthor" }, "fk_ea_a");
                        j.IndexerProperty<int>("IdExhibit").HasColumnName("id_exhibit");
                        j.IndexerProperty<int>("IdAuthor").HasColumnName("id_author");
                    });

            entity.HasMany(d => d.IdETs).WithMany(p => p.IdExhibits)
                .UsingEntity<Dictionary<string, object>>(
                    "ExhibitsTechnique",
                    r => r.HasOne<TechniqueOfExecution>().WithMany()
                        .HasForeignKey("IdET")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_et_t"),
                    l => l.HasOne<Exhibit>().WithMany()
                        .HasForeignKey("IdExhibit")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_et_e"),
                    j =>
                    {
                        j.HasKey("IdExhibit", "IdET")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("exhibits_technique");
                        j.HasIndex(new[] { "IdET" }, "fk_et_t");
                        j.IndexerProperty<int>("IdExhibit").HasColumnName("id_exhibit");
                        j.IndexerProperty<int>("IdET").HasColumnName("id_e_t");
                    });
        });

        modelBuilder.Entity<FavoriteExhibit>(entity =>
        {
            entity.HasKey(e => new { e.IdExhibit, e.IdUser })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("favorite_exhibits");

            entity.HasIndex(e => e.IdUser, "fk_fe_u");

            entity.Property(e => e.IdExhibit).HasColumnName("id_exhibit");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.DateAddition).HasColumnName("date_addition");

            entity.HasOne(d => d.IdExhibitNavigation).WithMany(p => p.FavoriteExhibits)
                .HasForeignKey(d => d.IdExhibit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fe_e");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.FavoriteExhibits)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fe_u");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.IdGenre).HasName("PRIMARY");

            entity.ToTable("genres");

            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.NameGenre)
                .HasMaxLength(100)
                .HasColumnName("name_genre");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdImage).HasName("PRIMARY");

            entity.ToTable("images");

            entity.HasIndex(e => e.IdExhibit, "fk_i_e");

            entity.Property(e => e.IdImage).HasColumnName("id_image");
            entity.Property(e => e.IdExhibit).HasColumnName("id_exhibit");
            entity.Property(e => e.Image1)
                .HasColumnType("text")
                .HasColumnName("image");

            entity.HasOne(d => d.IdExhibitNavigation).WithMany(p => p.Images)
                .HasForeignKey(d => d.IdExhibit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_i_e");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReview).HasName("PRIMARY");

            entity.ToTable("reviews");

            entity.HasIndex(e => e.IdExhibit, "fk_r_e");

            entity.HasIndex(e => e.IdUser, "fk_r_u");

            entity.Property(e => e.IdReview).HasColumnName("id_review");
            entity.Property(e => e.Complaint).HasColumnName("complaint");
            entity.Property(e => e.DateReview).HasColumnName("date_review");
            entity.Property(e => e.IdExhibit).HasColumnName("id_exhibit");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.TextReview)
                .HasColumnType("text")
                .HasColumnName("text_review");

            entity.HasOne(d => d.IdExhibitNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdExhibit)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_r_e");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_r_u");
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.HasKey(e => e.IdStorageLocation).HasName("PRIMARY");

            entity.ToTable("storage_locations");

            entity.Property(e => e.IdStorageLocation).HasColumnName("id_storage_location");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.NameSL)
                .HasMaxLength(50)
                .HasColumnName("name_s_l");
        });

        modelBuilder.Entity<TechniqueOfExecution>(entity =>
        {
            entity.HasKey(e => e.IdET).HasName("PRIMARY");

            entity.ToTable("technique_of_execution");

            entity.Property(e => e.IdET).HasColumnName("id_e_t");
            entity.Property(e => e.NameET)
                .HasMaxLength(50)
                .HasColumnName("name_e_t");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .HasColumnName("name_role");
            entity.Property(e => e.NameUser)
                .HasMaxLength(50)
                .HasColumnName("name_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(30)
                .HasColumnName("password_user");
            entity.Property(e => e.SurnameUser)
                .HasMaxLength(50)
                .HasColumnName("surname_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
