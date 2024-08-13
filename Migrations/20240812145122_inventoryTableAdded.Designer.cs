﻿// <auto-generated />
using System;
using InventoryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20240812145122_inventoryTableAdded")]
    partial class inventoryTableAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventoryManagementSystem.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventoryId");

                    b.ToTable("inventories");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.HasIndex("InventoryId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.TransactionStock", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionID");

                    b.HasIndex("InventoryId");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.Product", b =>
                {
                    b.HasOne("InventoryManagementSystem.Models.Inventory", null)
                        .WithMany("products")
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.Supplier", b =>
                {
                    b.HasOne("InventoryManagementSystem.Models.Inventory", null)
                        .WithMany("suppliers")
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.TransactionStock", b =>
                {
                    b.HasOne("InventoryManagementSystem.Models.Inventory", null)
                        .WithMany("transactionStocks")
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("InventoryManagementSystem.Models.Inventory", b =>
                {
                    b.Navigation("products");

                    b.Navigation("suppliers");

                    b.Navigation("transactionStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
