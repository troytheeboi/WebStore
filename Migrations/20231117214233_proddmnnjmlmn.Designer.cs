﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebStore;

#nullable disable

namespace WebStore.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231117214233_proddmnnjmlmn")]
    partial class proddmnnjmlmn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("ordersOrderId")
                        .HasColumnType("int");

                    b.Property<int>("productsProdId")
                        .HasColumnType("int");

                    b.HasKey("ordersOrderId", "productsProdId");

                    b.HasIndex("productsProdId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("ProductShoppingCart", b =>
                {
                    b.Property<int>("productsProdId")
                        .HasColumnType("int");

                    b.Property<int>("shoppingCartsCartId")
                        .HasColumnType("int");

                    b.HasKey("productsProdId", "shoppingCartsCartId");

                    b.HasIndex("shoppingCartsCartId");

                    b.ToTable("ProductShoppingCart");
                });

            modelBuilder.Entity("WebStore.Models.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ManagerID")
                        .HasColumnType("int");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.HasKey("BranchId");

                    b.ToTable("branches");
                });

            modelBuilder.Entity("WebStore.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CatDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CatId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebStore.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId");

                    b.HasIndex("BranchId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("WebStore.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("float");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebStore.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PaymentId");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("WebStore.Models.Product", b =>
                {
                    b.Property<int>("ProdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.HasKey("ProdId");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebStore.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("productProdId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("productProdId");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("WebStore.Models.ShoppingCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("shoppingCarts");
                });

            modelBuilder.Entity("WebStore.Models.Supplier", b =>
                {
                    b.Property<int>("supplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("supplierAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("supplierName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("supplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("WebStore.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("ordersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("productsProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductShoppingCart", b =>
                {
                    b.HasOne("WebStore.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("productsProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("shoppingCartsCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebStore.Models.Employee", b =>
                {
                    b.HasOne("WebStore.Models.Branch", "branch")
                        .WithMany("employees")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("branch");
                });

            modelBuilder.Entity("WebStore.Models.Order", b =>
                {
                    b.HasOne("WebStore.Models.Customer", "customer")
                        .WithMany("orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.Models.Payment", "payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("payment");
                });

            modelBuilder.Entity("WebStore.Models.Product", b =>
                {
                    b.HasOne("WebStore.Models.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.Models.Supplier", "supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("supplier");
                });

            modelBuilder.Entity("WebStore.Models.Review", b =>
                {
                    b.HasOne("WebStore.Models.Customer", "customer")
                        .WithMany("reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebStore.Models.Product", "product")
                        .WithMany("reviews")
                        .HasForeignKey("productProdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("product");
                });

            modelBuilder.Entity("WebStore.Models.ShoppingCart", b =>
                {
                    b.HasOne("WebStore.Models.Customer", "Customer")
                        .WithOne("cart")
                        .HasForeignKey("WebStore.Models.ShoppingCart", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WebStore.Models.Branch", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("WebStore.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebStore.Models.Customer", b =>
                {
                    b.Navigation("cart")
                        .IsRequired();

                    b.Navigation("orders");

                    b.Navigation("reviews");
                });

            modelBuilder.Entity("WebStore.Models.Product", b =>
                {
                    b.Navigation("reviews");
                });
#pragma warning restore 612, 618
        }
    }
}