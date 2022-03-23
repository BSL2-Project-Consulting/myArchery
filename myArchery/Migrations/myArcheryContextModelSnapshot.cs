﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myArchery.Data;

#nullable disable

namespace myArchery.Migrations
{
    [DbContext(typeof(myArcheryContext))]
    partial class myArcheryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Arrow", b =>
                {
                    b.Property<int>("ArrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArrId"), 1L, 1);

                    b.Property<int>("EvusroId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hitdatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PataId")
                        .HasColumnType("int");

                    b.Property<int>("PoiId")
                        .HasColumnType("int");

                    b.HasKey("ArrId");

                    b.HasIndex("EvusroId");

                    b.HasIndex("PataId");

                    b.HasIndex("PoiId");

                    b.ToTable("Arrow");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Event", b =>
                {
                    b.Property<int>("EveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EveId"), 1L, 1);

                    b.Property<int>("Arrowamount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Enddate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Eventname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Isprivat")
                        .HasColumnType("smallint");

                    b.Property<int>("ParId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("datetime2");

                    b.HasKey("EveId");

                    b.HasIndex("ParId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.EventUserRole", b =>
                {
                    b.Property<int>("EvusroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvusroId"), 1L, 1);

                    b.Property<int>("EveId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UseId")
                        .HasColumnType("int");

                    b.Property<string>("UseId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EvusroId");

                    b.HasIndex("EveId");

                    b.HasIndex("RolId");

                    b.HasIndex("UseId1");

                    b.ToTable("EventUserRole");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Parcour", b =>
                {
                    b.Property<int>("ParId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParId"), 1L, 1);

                    b.Property<int>("Counttargets")
                        .HasColumnType("int");

                    b.Property<string>("Parcourname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Postalcode")
                        .HasColumnType("int");

                    b.Property<string>("StreetHousenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParId");

                    b.ToTable("Parcour");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.ParcoursTarget", b =>
                {
                    b.Property<int>("PataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PataId"), 1L, 1);

                    b.Property<int>("ParId")
                        .HasColumnType("int");

                    b.Property<int>("TarId")
                        .HasColumnType("int");

                    b.HasKey("PataId");

                    b.HasIndex("ParId");

                    b.HasIndex("TarId");

                    b.ToTable("ParcoursTarget");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.PasswordHistory", b =>
                {
                    b.Property<int>("PhyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhyId"), 1L, 1);

                    b.Property<DateTime>("Fromdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Untildate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UseId")
                        .HasColumnType("int");

                    b.Property<string>("UseId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PhyId");

                    b.HasIndex("UseId1");

                    b.ToTable("PasswordHistory");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Point", b =>
                {
                    b.Property<int>("PoiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoiId"), 1L, 1);

                    b.Property<int>("EveId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<int>("ValueId")
                        .HasColumnType("int");

                    b.HasKey("PoiId");

                    b.HasIndex("EveId");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Role", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<string>("Rolename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Target", b =>
                {
                    b.Property<int>("TarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarId"), 1L, 1);

                    b.Property<string>("Targetname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TarId");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Getnewsletter")
                        .HasColumnType("int");

                    b.Property<int>("Isactive")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UseId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Vname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myArchery.Persistance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Arrow", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.EventUserRole", "Evusro")
                        .WithMany("Arrows")
                        .HasForeignKey("EvusroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myArchery.Persistance.Models.ParcoursTarget", "Pata")
                        .WithMany("Arrows")
                        .HasForeignKey("PataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myArchery.Persistance.Models.Point", "Poi")
                        .WithMany("Arrows")
                        .HasForeignKey("PoiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evusro");

                    b.Navigation("Pata");

                    b.Navigation("Poi");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Event", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.Parcour", "Par")
                        .WithMany("Events")
                        .HasForeignKey("ParId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Par");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.EventUserRole", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.Event", "Eve")
                        .WithMany("EventUserRoles")
                        .HasForeignKey("EveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myArchery.Persistance.Models.Role", "Rol")
                        .WithMany("EventUserRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myArchery.Persistance.Models.User", "Use")
                        .WithMany("EventUserRoles")
                        .HasForeignKey("UseId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eve");

                    b.Navigation("Rol");

                    b.Navigation("Use");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.ParcoursTarget", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.Parcour", "Par")
                        .WithMany("ParcoursTargets")
                        .HasForeignKey("ParId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myArchery.Persistance.Models.Target", "Tar")
                        .WithMany("ParcoursTargets")
                        .HasForeignKey("TarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Par");

                    b.Navigation("Tar");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.PasswordHistory", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.User", "Use")
                        .WithMany("PasswordHistories")
                        .HasForeignKey("UseId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Use");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Point", b =>
                {
                    b.HasOne("myArchery.Persistance.Models.Event", "Eve")
                        .WithMany("Points")
                        .HasForeignKey("EveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eve");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Event", b =>
                {
                    b.Navigation("EventUserRoles");

                    b.Navigation("Points");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.EventUserRole", b =>
                {
                    b.Navigation("Arrows");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Parcour", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("ParcoursTargets");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.ParcoursTarget", b =>
                {
                    b.Navigation("Arrows");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Point", b =>
                {
                    b.Navigation("Arrows");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Role", b =>
                {
                    b.Navigation("EventUserRoles");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.Target", b =>
                {
                    b.Navigation("ParcoursTargets");
                });

            modelBuilder.Entity("myArchery.Persistance.Models.User", b =>
                {
                    b.Navigation("EventUserRoles");

                    b.Navigation("PasswordHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
