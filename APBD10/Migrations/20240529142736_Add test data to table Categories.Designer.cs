﻿// <auto-generated />
using APBD10.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APBD10.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240529142736_Add test data to table Categories")]
    partial class AddtestdatatotableCategories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APBD10.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountEmail")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("AccountFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("AccountLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("AccountPhone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("FK_role");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            AccountEmail = "john.doe@gmail.com",
                            AccountFirstName = "John",
                            AccountLastName = "Doe",
                            AccountPhone = "123456789",
                            RoleId = 1
                        },
                        new
                        {
                            AccountId = 2,
                            AccountEmail = "alice.smith@gmail.com",
                            AccountFirstName = "Alice",
                            AccountLastName = "Smith",
                            AccountPhone = "987654321",
                            RoleId = 2
                        },
                        new
                        {
                            AccountId = 3,
                            AccountEmail = "bob.brown@gmail.com",
                            AccountFirstName = "Bob",
                            AccountLastName = "Brown",
                            AccountPhone = "456789123",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("APBD10.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_category");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Category 1"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Category 2"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Category 3"
                        });
                });

            modelBuilder.Entity("APBD10.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("ProductDepth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("ProductHeight")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("height");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("ProductWidth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("width");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductDepth = 3.3m,
                            ProductHeight = 2.2m,
                            ProductName = "Product 1",
                            ProductWidth = 1.1m
                        },
                        new
                        {
                            ProductId = 2,
                            ProductDepth = 1.4m,
                            ProductHeight = 3.4m,
                            ProductName = "Product 2",
                            ProductWidth = 2m
                        },
                        new
                        {
                            ProductId = 3,
                            ProductDepth = 3.3m,
                            ProductHeight = 2.2m,
                            ProductName = "Product 3",
                            ProductWidth = 1.1m
                        });
                });

            modelBuilder.Entity("APBD10.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("FK_category");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products_Categories");
                });

            modelBuilder.Entity("APBD10.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Guest"
                        });
                });

            modelBuilder.Entity("APBD10.Models.ShoppingCart", b =>
                {
                    b.Property<int>("AccountID")
                        .HasColumnType("int")
                        .HasColumnName("FK_account");

                    b.Property<int>("ProductID")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("ShoppingCartAmount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.HasKey("AccountID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("Shopping_Carts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            ProductID = 1,
                            ShoppingCartAmount = 13
                        },
                        new
                        {
                            AccountID = 2,
                            ProductID = 3,
                            ShoppingCartAmount = 2
                        },
                        new
                        {
                            AccountID = 3,
                            ProductID = 2,
                            ShoppingCartAmount = 5
                        });
                });

            modelBuilder.Entity("APBD10.Models.Account", b =>
                {
                    b.HasOne("APBD10.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("APBD10.Models.ProductCategory", b =>
                {
                    b.HasOne("APBD10.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD10.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("APBD10.Models.ShoppingCart", b =>
                {
                    b.HasOne("APBD10.Models.Account", "Account")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD10.Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("APBD10.Models.Account", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("APBD10.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("APBD10.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("APBD10.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
