﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240121232509_InitialSetUpandSeeding")]
    partial class InitialSetUpandSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Models.ImportTaxCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ImportTaxCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Uncategorised0",
                            Rate = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Uncategorised5",
                            Rate = 5.0
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImportTaxCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TaxCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImportTaxCategoryId");

                    b.HasIndex("TaxCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImportTaxCategoryId = 1,
                            Name = "Book",
                            Price = 12.49,
                            TaxCategoryId = 3
                        },
                        new
                        {
                            Id = 2,
                            ImportTaxCategoryId = 1,
                            Name = "Music CD",
                            Price = 14.99,
                            TaxCategoryId = 2
                        },
                        new
                        {
                            Id = 3,
                            ImportTaxCategoryId = 1,
                            Name = "Chocolate Bar",
                            Price = 0.84999999999999998,
                            TaxCategoryId = 4
                        },
                        new
                        {
                            Id = 4,
                            ImportTaxCategoryId = 2,
                            Name = "Imported Box of Chocolates",
                            Price = 10.0,
                            TaxCategoryId = 4
                        },
                        new
                        {
                            Id = 5,
                            ImportTaxCategoryId = 2,
                            Name = "Imported Bottle of Perfume",
                            Price = 47.5,
                            TaxCategoryId = 2
                        },
                        new
                        {
                            Id = 6,
                            ImportTaxCategoryId = 2,
                            Name = "Imported Bottle of Perfume",
                            Price = 27.989999999999998,
                            TaxCategoryId = 2
                        },
                        new
                        {
                            Id = 7,
                            ImportTaxCategoryId = 1,
                            Name = "Bottle of Perfume",
                            Price = 18.989999999999998,
                            TaxCategoryId = 2
                        },
                        new
                        {
                            Id = 8,
                            ImportTaxCategoryId = 1,
                            Name = "Packet of Paracetemol",
                            Price = 9.75,
                            TaxCategoryId = 5
                        },
                        new
                        {
                            Id = 9,
                            ImportTaxCategoryId = 2,
                            Name = "Imported Box of Chocolates",
                            Price = 11.25,
                            TaxCategoryId = 4
                        });
                });

            modelBuilder.Entity("DataAccess.Models.TaxCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TaxCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Uncategorised0",
                            Rate = 0.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Uncategorised10",
                            Rate = 10.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Books",
                            Rate = 0.0
                        },
                        new
                        {
                            Id = 4,
                            Name = "Food",
                            Rate = 0.0
                        },
                        new
                        {
                            Id = 5,
                            Name = "Medical",
                            Rate = 0.0
                        });
                });

            modelBuilder.Entity("DataAccess.Models.Product", b =>
                {
                    b.HasOne("DataAccess.Models.ImportTaxCategory", "ImportTaxCategory")
                        .WithMany()
                        .HasForeignKey("ImportTaxCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.TaxCategory", "TaxCategory")
                        .WithMany()
                        .HasForeignKey("TaxCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImportTaxCategory");

                    b.Navigation("TaxCategory");
                });
#pragma warning restore 612, 618
        }
    }
}