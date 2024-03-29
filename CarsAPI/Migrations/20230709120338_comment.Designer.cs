﻿// <auto-generated />
using System;
using CarsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarsAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230709120338_comment")]
    partial class comment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarsAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Toyota",
                            ClassId = 1,
                            Description = "Spacious and reliable sedan.",
                            ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Jaguar/F-TYPE/7810/1675671305429/front-left-side-47.jpg?tr=w-456",
                            Model = "Corolla",
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            Brand = "BMW",
                            ClassId = 4,
                            Description = "Fast exlusive car",
                            ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/BMW/M2/10257/1686225075596/front-left-side-47.jpg?tr=w-456",
                            Model = "M3",
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Skoda",
                            ClassId = 1,
                            Description = "Comfortable and fuel-efficient sedan.",
                            ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Bentley/Continental/7771/1676965640042/front-left-side-47.jpg?tr=w-456",
                            Model = "Octavia",
                            Year = 2011
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Mitsubisy",
                            ClassId = 2,
                            Description = "Spacious and versatile SUV.",
                            ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/BMW/Z4/10183/1685003672330/front-left-side-47.jpg?impolicy=resize&imwidth=420",
                            Model = "Outlander",
                            Year = 2019
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Skoda",
                            ClassId = 1,
                            Description = "Spacious and versatile SUV. Lorem ipsum",
                            ImageUrl = "https://stimg.cardekho.com/images/carexteriorimages/630x420/Lamborghini/Huracan-EVO/6729/1678692048287/front-left-side-47.jpg?tr=w-456",
                            Model = "Fabia",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("CarsAPI.Models.CarClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Economy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Luxury"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("CarsAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("UserComment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostID");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("CarsAPI.Models.Posts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CarsAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("CarsAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user@test.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEAO+SpsdU6VNf7kIPa2oRYcPlEhtU6Z7Zh+k/VxxhiX/vCHqPj/FrCg4GEuDOOI7PA==",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin@test.com",
                            PasswordHash = "AQAAAAIAAYagAAAAEH/sw5mjAQtiIC3ILFfCqMD912U9uxq3ocBcHlWHsF/rD70QeLLQo1GsenRyj2WiSQ==",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("CarsAPI.Models.Car", b =>
                {
                    b.HasOne("CarsAPI.Models.CarClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("CarsAPI.Models.Comment", b =>
                {
                    b.HasOne("CarsAPI.Models.Posts", "Post")
                        .WithMany()
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarsAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarsAPI.Models.Posts", b =>
                {
                    b.HasOne("CarsAPI.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarsAPI.Models.User", b =>
                {
                    b.HasOne("CarsAPI.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
