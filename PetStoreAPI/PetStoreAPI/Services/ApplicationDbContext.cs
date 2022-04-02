using Microsoft.EntityFrameworkCore;
using PetStoreAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreAPI.Services
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Breed>()
            .HasKey(b => new { b.Category, b.AnimalBreed });

            builder.Entity<User>()
                .HasKey(u => new { u.Id });

           

            

            builder.Entity<AnimalOrderItem>()
                .HasKey(aoi => new { aoi.AnimalOrderId, aoi.AnimalId });

            builder.Entity<OrderItem>()
                .HasKey(ai => new { ai.MerchandiseId, ai.MerchandiseOrderId });

            builder.Entity<SaleItem>()
                .HasKey(si => new { si.SaleId, si.MerchandiseId });
            builder.Entity<SaleAnimal>()
                .HasKey(sa => new { sa.SaleId, sa.AnimalId });
            
                
            //couldn't determine dependent from model so configured manually 
            builder.Entity<CustomerAccount>()
                .HasOne(ca => ca.Customer)
                .WithOne(c => c.CustomerAccount)
                .HasForeignKey<CustomerAccount>(c => c.CustomerId);
            //fixes may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints eror during migration
            builder.Entity<Employee>()
                .HasMany(e => e.Sales)
                .WithOne(s => s.Employee)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AnimalOrder>()
               .HasOne(e => e.Supplier)
               .WithMany(s => s.AnimalOrders)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<MerchandiseOrder>()
              .HasOne(e => e.Supplier)
              .WithMany(s => s.MerchandiseOrders)
              .OnDelete(DeleteBehavior.NoAction);

            //Fix for no type detected error warning 
            builder.Entity<Animal>()
                .Property(a => a.ListPrice)
                .HasColumnType("money");
            builder.Entity<AnimalOrder>()
                .Property(ao => ao.ShippingCost)
                .HasColumnType("money");

            builder.Entity<AnimalOrderItem>()
                .Property(aoi => aoi.Cost)
                .HasColumnType("money");

            builder.Entity<CustomerAccount>()
                .Property(ca => ca.Balance)
                .HasColumnType("money");

            builder.Entity<Merchandise>()
                .Property(m => m.ListPrice)
                .HasColumnType("money");

            builder.Entity<MerchandiseOrder>()
                .Property(mo => mo.ShippingCost)
                .HasColumnType("money");

            builder.Entity<OrderItem>()
                .Property(oi => oi.Cost)
                .HasColumnType("money");

            builder.Entity<Sale>()
                .Property(s => s.SalesTax)
                .HasColumnType("money");

            builder.Entity<SaleAnimal>()
                .Property(sa => sa.SalePrice)
                .HasColumnType("money");

            builder.Entity<SaleItem>()
                .Property(si => si.SalePrice)
                .HasColumnType("money");



        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalOrder> AnimalOrders { get; set; }
        public DbSet<AnimalOrderItem> AnimalOrderItems { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Merchandise> Merchandise { get; set; }
        public DbSet<MerchandiseOrder> MerchandiseOrders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleAnimal> SaleAnimals { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
