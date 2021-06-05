﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Persistence;

namespace Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210605120744_ShopEntitiesMigration")]
    partial class ShopEntitiesMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductUser", b =>
                {
                    b.Property<Guid>("FollowProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowersUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FollowProductId", "FollowersUserId");

                    b.HasIndex("FollowersUserId");

                    b.ToTable("ProductUser");
                });

            modelBuilder.Entity("Web.Persistence.Entities.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Web.Persistence.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotoId1")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(16,8)");

                    b.HasKey("ProductId");

                    b.HasIndex("PhotoId1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Web.Persistence.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductUser", b =>
                {
                    b.HasOne("Web.Persistence.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("FollowProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Persistence.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web.Persistence.Entities.Product", b =>
                {
                    b.HasOne("Web.Persistence.Entities.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId1");

                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}
