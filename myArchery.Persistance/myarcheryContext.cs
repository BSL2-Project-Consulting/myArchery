using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using myArchery.Persistance.Models;

namespace myArchery.Persistance
{
    public partial class myarcheryContext : DbContext
    {
        public myarcheryContext()
        {
        }

        public myarcheryContext(DbContextOptions<myarcheryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arrow> Arrows { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventUserRole> EventUserRoles { get; set; } = null!;
        public virtual DbSet<Parcour> Parcours { get; set; } = null!;
        public virtual DbSet<ParcoursTarget> ParcoursTargets { get; set; } = null!;
        public virtual DbSet<PasswordHistory> PasswordHistories { get; set; } = null!;
        public virtual DbSet<Point> Points { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Target> Targets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=myarchery;user=root;password=root", ServerVersion.Parse("10.4.22-mariadb"))
                                .EnableDetailedErrors()
                                .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Arrow>(entity =>
            {
                entity.HasKey(e => e.ArrId)
                    .HasName("PRIMARY");

                entity.ToTable("arrow");

                entity.HasIndex(e => e.EvusroId, "fk_arrow_event_user_roles1_idx");

                entity.HasIndex(e => e.PataId, "fk_arrow_parcours_target1_idx");

                entity.HasIndex(e => e.PoiId, "fk_arrow_points1_idx");

                entity.Property(e => e.ArrId)
                    .HasColumnType("int(11)")
                    .HasColumnName("arr_id");

                entity.Property(e => e.EvusroId)
                    .HasColumnType("int(11)")
                    .HasColumnName("evusro_id");

                entity.Property(e => e.Hitdatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("hitdatetime");

                entity.Property(e => e.PataId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pata_id");

                entity.Property(e => e.PoiId)
                    .HasColumnType("int(11)")
                    .HasColumnName("poi_id");

                entity.HasOne(d => d.Evusro)
                    .WithMany(p => p.Arrows)
                    .HasForeignKey(d => d.EvusroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arrow_event_user_roles1");

                entity.HasOne(d => d.Pata)
                    .WithMany(p => p.Arrows)
                    .HasForeignKey(d => d.PataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arrow_parcours_target1");

                entity.HasOne(d => d.Poi)
                    .WithMany(p => p.Arrows)
                    .HasForeignKey(d => d.PoiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_arrow_points1");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EveId)
                    .HasName("PRIMARY");

                entity.ToTable("event");

                entity.HasIndex(e => e.ParId, "fk_event_parcours1_idx");

                entity.Property(e => e.EveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("eve_id");

                entity.Property(e => e.Arrowamount)
                    .HasColumnType("int(11)")
                    .HasColumnName("arrowamount");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Eventname)
                    .HasMaxLength(45)
                    .HasColumnName("eventname");

                entity.Property(e => e.Isprivat)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("isprivat");

                entity.Property(e => e.ParId)
                    .HasColumnType("int(11)")
                    .HasColumnName("par_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.HasOne(d => d.Par)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ParId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_parcours1");
            });

            modelBuilder.Entity<EventUserRole>(entity =>
            {
                entity.HasKey(e => e.EvusroId)
                    .HasName("PRIMARY");

                entity.ToTable("event_user_roles");

                entity.HasIndex(e => e.EveId, "fk_event_has_user_event1_idx");

                entity.HasIndex(e => e.UseId, "fk_event_has_user_user1_idx");

                entity.HasIndex(e => e.RolId, "fk_event_user_roles1_idx");

                entity.Property(e => e.EvusroId)
                    .HasColumnType("int(11)")
                    .HasColumnName("evusro_id");

                entity.Property(e => e.EveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("eve_id");

                entity.Property(e => e.RolId)
                    .HasColumnType("int(11)")
                    .HasColumnName("rol_id");

                entity.Property(e => e.UseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("use_id");

                entity.HasOne(d => d.Eve)
                    .WithMany(p => p.EventUserRoles)
                    .HasForeignKey(d => d.EveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_has_user_event1");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.EventUserRoles)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_user_roles1");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.EventUserRoles)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_event_has_user_user1");
            });

            modelBuilder.Entity<Parcour>(entity =>
            {
                entity.HasKey(e => e.ParId)
                    .HasName("PRIMARY");

                entity.ToTable("parcours");

                entity.Property(e => e.ParId)
                    .HasColumnType("int(11)")
                    .HasColumnName("par_id");

                entity.Property(e => e.Counttargets)
                    .HasColumnType("int(11)")
                    .HasColumnName("counttargets");

                entity.Property(e => e.Parcourname)
                    .HasMaxLength(45)
                    .HasColumnName("parcourname");

                entity.Property(e => e.Postalcode)
                    .HasColumnType("int(11)")
                    .HasColumnName("postalcode");

                entity.Property(e => e.StreetHousenumber)
                    .HasMaxLength(45)
                    .HasColumnName("street_housenumber");

                entity.Property(e => e.Town)
                    .HasMaxLength(45)
                    .HasColumnName("town");
            });

            modelBuilder.Entity<ParcoursTarget>(entity =>
            {
                entity.HasKey(e => e.PataId)
                    .HasName("PRIMARY");

                entity.ToTable("parcours_target");

                entity.HasIndex(e => e.ParId, "fk_parcours_has_target_parcours1_idx");

                entity.HasIndex(e => e.TarId, "fk_parcours_has_target_target1_idx");

                entity.Property(e => e.PataId)
                    .HasColumnType("int(11)")
                    .HasColumnName("pata_id");

                entity.Property(e => e.ParId)
                    .HasColumnType("int(11)")
                    .HasColumnName("par_id");

                entity.Property(e => e.TarId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tar_id");

                entity.HasOne(d => d.Par)
                    .WithMany(p => p.ParcoursTargets)
                    .HasForeignKey(d => d.ParId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_parcours_has_target_parcours1");

                entity.HasOne(d => d.Tar)
                    .WithMany(p => p.ParcoursTargets)
                    .HasForeignKey(d => d.TarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_parcours_has_target_target1");
            });

            modelBuilder.Entity<PasswordHistory>(entity =>
            {
                entity.HasKey(e => e.PhyId)
                    .HasName("PRIMARY");

                entity.ToTable("password_history");

                entity.HasIndex(e => e.UseId, "fk_password_history_user_idx");

                entity.Property(e => e.PhyId)
                    .HasColumnType("int(11)")
                    .HasColumnName("phy_id");

                entity.Property(e => e.Fromdate)
                    .HasColumnType("datetime")
                    .HasColumnName("fromdate");

                entity.Property(e => e.IsActive)
                    .HasColumnType("int(11)")
                    .HasColumnName("is_active");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.Untildate)
                    .HasColumnType("datetime")
                    .HasColumnName("untildate");

                entity.Property(e => e.UseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("use_id");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.PasswordHistories)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_password_history_user");
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => e.PoiId)
                    .HasName("PRIMARY");

                entity.ToTable("points");

                entity.HasIndex(e => e.EveId, "fk_points_event1_idx");

                entity.Property(e => e.PoiId)
                    .HasColumnType("int(11)")
                    .HasColumnName("poi_id");

                entity.Property(e => e.EveId)
                    .HasColumnType("int(11)")
                    .HasColumnName("eve_id");

                entity.Property(e => e.Value)
                    .HasColumnType("int(11)")
                    .HasColumnName("value");

                entity.Property(e => e.ValueId)
                    .HasColumnType("int(11)")
                    .HasColumnName("value_id");

                entity.HasOne(d => d.Eve)
                    .WithMany(p => p.Points)
                    .HasForeignKey(d => d.EveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_points_event1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.RolId)
                    .HasColumnType("int(11)")
                    .HasColumnName("rol_id");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(45)
                    .HasColumnName("rolename");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.HasKey(e => e.TarId)
                    .HasName("PRIMARY");

                entity.ToTable("target");

                entity.Property(e => e.TarId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tar_id");

                entity.Property(e => e.Targetname)
                    .HasMaxLength(45)
                    .HasColumnName("targetname");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UseId)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.UseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("use_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Getnewsletter)
                    .HasColumnType("int(11)")
                    .HasColumnName("getnewsletter");

                entity.Property(e => e.Isactive)
                    .HasColumnType("int(11)")
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nname)
                    .HasMaxLength(45)
                    .HasColumnName("nname");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password")
                    .HasComment("64 weil sha265 immer 64 zeichen lang ist ");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");

                entity.Property(e => e.Vname)
                    .HasMaxLength(45)
                    .HasColumnName("vname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
