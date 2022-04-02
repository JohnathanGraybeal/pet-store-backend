﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetStoreAPI.Services;

namespace PetStoreAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220307043319_userMig")]
    partial class userMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AnimalId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BreedCategory")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Breed");

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateBorn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageHeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageWidth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Registered")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BreedCategory", "Category");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.AnimalOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RecievedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("money");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("AnimalOrders");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.AnimalOrderItem", b =>
                {
                    b.Property<int>("AnimalOrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderId");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.HasKey("AnimalOrderId", "AnimalId");

                    b.HasIndex("AnimalId");

                    b.ToTable("AnimalOrderItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Breed", b =>
                {
                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category");

                    b.Property<string>("AnimalBreed")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Breed");

                    b.Property<string>("CategoryAnimalCategory")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Category", "AnimalBreed");

                    b.HasIndex("CategoryAnimalCategory");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Category", b =>
                {
                    b.Property<string>("AnimalCategory")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category");

                    b.Property<string>("Registration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimalCategory");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CityId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<int?>("Population1980")
                        .HasColumnType("int");

                    b.Property<int?>("Population1990")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.CustomerAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReleased")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeLevel")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxPayerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Merchandise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ItemId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Category");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("money");

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Merchandise");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.MerchandiseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PONumber")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RecievedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("money");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SupplierId");

                    b.ToTable("MerchandiseOrders");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.OrderItem", b =>
                {
                    b.Property<int>("MerchandiseId")
                        .HasColumnType("int")
                        .HasColumnName("ItemId");

                    b.Property<int>("MerchandiseOrderId")
                        .HasColumnType("int")
                        .HasColumnName("PONumber");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("MerchandiseId", "MerchandiseOrderId");

                    b.HasIndex("MerchandiseOrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Preferences", b =>
                {
                    b.Property<int>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KeyId");

                    b.ToTable("Preferences");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RevisionId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Revisions");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SaleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SalesTax")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.SaleAnimal", b =>
                {
                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("money");

                    b.HasKey("SaleId", "AnimalId");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.ToTable("SaleAnimals");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.SaleItem", b =>
                {
                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("MerchandiseId")
                        .HasColumnType("int")
                        .HasColumnName("ItemId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("money");

                    b.HasKey("SaleId", "MerchandiseId");

                    b.HasIndex("MerchandiseId");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SupplierId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Animal", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Breed", "Breed")
                        .WithMany("Animals")
                        .HasForeignKey("BreedCategory", "Category");

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.AnimalOrder", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Employee", "Employee")
                        .WithMany("AnimalOrders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("PetStoreAPI.Models.Entities.Supplier", "Supplier")
                        .WithMany("AnimalOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Employee");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.AnimalOrderItem", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Animal", "Animal")
                        .WithMany("AnimalOrderItems")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStoreAPI.Models.Entities.AnimalOrder", "AnimalOrder")
                        .WithMany("AnimalOrderItems")
                        .HasForeignKey("AnimalOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("AnimalOrder");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Breed", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Category", null)
                        .WithMany("Breeds")
                        .HasForeignKey("CategoryAnimalCategory");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Customer", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.City", "City")
                        .WithMany("Customers")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.CustomerAccount", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Customer", "Customer")
                        .WithOne("CustomerAccount")
                        .HasForeignKey("PetStoreAPI.Models.Entities.CustomerAccount", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Employee", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.City", "City")
                        .WithMany("Employees")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Merchandise", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.MerchandiseOrder", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Employee", "Employee")
                        .WithMany("MerchandiseOrders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStoreAPI.Models.Entities.Supplier", "Supplier")
                        .WithMany("MerchandiseOrders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.OrderItem", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Merchandise", "Merchandise")
                        .WithMany("OrderItems")
                        .HasForeignKey("MerchandiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStoreAPI.Models.Entities.MerchandiseOrder", "MerchandiseOrder")
                        .WithMany("OrderItems")
                        .HasForeignKey("MerchandiseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchandise");

                    b.Navigation("MerchandiseOrder");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Sale", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Customer", "Customer")
                        .WithMany("Sales")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PetStoreAPI.Models.Entities.Employee", "Employee")
                        .WithMany("Sales")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.SaleAnimal", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Animal", "Animal")
                        .WithOne("SaleAnimal")
                        .HasForeignKey("PetStoreAPI.Models.Entities.SaleAnimal", "AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStoreAPI.Models.Entities.Sale", "Sale")
                        .WithMany("SaleAnimals")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.SaleItem", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.Merchandise", "Merchandise")
                        .WithMany("SaleItems")
                        .HasForeignKey("MerchandiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetStoreAPI.Models.Entities.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchandise");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Supplier", b =>
                {
                    b.HasOne("PetStoreAPI.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Animal", b =>
                {
                    b.Navigation("AnimalOrderItems");

                    b.Navigation("SaleAnimal");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.AnimalOrder", b =>
                {
                    b.Navigation("AnimalOrderItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Breed", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Category", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.City", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Customer", b =>
                {
                    b.Navigation("CustomerAccount");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Employee", b =>
                {
                    b.Navigation("AnimalOrders");

                    b.Navigation("MerchandiseOrders");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Merchandise", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.MerchandiseOrder", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Sale", b =>
                {
                    b.Navigation("SaleAnimals");

                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("PetStoreAPI.Models.Entities.Supplier", b =>
                {
                    b.Navigation("AnimalOrders");

                    b.Navigation("MerchandiseOrders");
                });
#pragma warning restore 612, 618
        }
    }
}