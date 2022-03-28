using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using myArchery.Persistance.Models;

namespace myArchery.Persistance
{
    public partial class ArcheryDbContext : DbContext
    {
        public ArcheryDbContext()
        {
        }

        public ArcheryDbContext(DbContextOptions<ArcheryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arrow> Arrows { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventUserRole> EventUserRoles { get; set; } = null!;
        public virtual DbSet<Parcour> Parcours { get; set; } = null!;
        public virtual DbSet<ParcoursTarget> ParcoursTargets { get; set; } = null!;
        public virtual DbSet<Point> Points { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Target> Targets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Archery;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arrow>(entity =>
            {
                entity.HasKey(e => e.ArrId);

                entity.ToTable("Arrow");

                entity.HasIndex(e => e.EvusroId, "IX_Arrow_EvusroId");

                entity.HasIndex(e => e.PataId, "IX_Arrow_PataId");

                entity.HasIndex(e => e.PoiId, "IX_Arrow_PoiId");

                entity.HasOne(d => d.Evusro)
                    .WithMany(p => p.Arrows)
                    .HasForeignKey(d => d.EvusroId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pata)
                    .WithMany(p => p.Arrows)
                    .HasForeignKey(d => d.PataId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Poi)
                    .WithMany(p => p.Arrows)
                    .HasForeignKey(d => d.PoiId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EveId);

                entity.ToTable("Event");

                entity.HasIndex(e => e.ParId, "IX_Event_ParId");

                entity.HasOne(d => d.Par)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ParId);
            });

            modelBuilder.Entity<EventUserRole>(entity =>
            {
                entity.HasKey(e => e.EvusroId);

                entity.ToTable("EventUserRole");

                entity.HasIndex(e => e.EveId, "IX_EventUserRole_EveId");

                entity.HasIndex(e => e.RolId, "IX_EventUserRole_RolId");

                entity.HasIndex(e => e.UseId, "IX_EventUserRole_UseId");

                entity.HasOne(d => d.Eve)
                    .WithMany(p => p.EventUserRoles)
                    .HasForeignKey(d => d.EveId);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.EventUserRoles)
                    .HasForeignKey(d => d.RolId);

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.EventUserRoles)
                    .HasForeignKey(d => d.UseId);
            });

            modelBuilder.Entity<Parcour>(entity =>
            {
                entity.HasKey(e => e.ParId);

                entity.ToTable("Parcour");
            });

            modelBuilder.Entity<ParcoursTarget>(entity =>
            {
                entity.HasKey(e => e.PataId);

                entity.ToTable("ParcoursTarget");

                entity.HasIndex(e => e.ParId, "IX_ParcoursTarget_ParId");

                entity.HasIndex(e => e.TarId, "IX_ParcoursTarget_TarId");

                entity.HasOne(d => d.Par)
                    .WithMany(p => p.ParcoursTargets)
                    .HasForeignKey(d => d.ParId);

                entity.HasOne(d => d.Tar)
                    .WithMany(p => p.ParcoursTargets)
                    .HasForeignKey(d => d.TarId);
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => e.PoiId);

                entity.ToTable("Point");

                entity.HasIndex(e => e.EveId, "IX_Point_EveId");

                entity.HasOne(d => d.Eve)
                    .WithMany(p => p.Points)
                    .HasForeignKey(d => d.EveId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.ToTable("Role");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.HasKey(e => e.TarId);

                entity.ToTable("Target");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
