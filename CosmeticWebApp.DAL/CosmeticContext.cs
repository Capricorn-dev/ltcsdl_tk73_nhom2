﻿using CosmeticWebApp.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.DAL
{
    public class CosmeticContext : DbContext
    {
        public CosmeticContext()
        {
        }

        public CosmeticContext(DbContextOptions<CosmeticContext> options)
            : base(options)
        {
        }
        public DbSet<Personal_Information> Personal_Information { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Chỉnh đường dẫn CSDL ở đây
            optionsBuilder.UseSqlServer(@"Server=.;Database=CosmeticAppDB;Trusted_Connection=True;"); //Windows Authencation
            //optionsBuilder.UseSqlServer(@"Data Source =.\SQLEXPRESS; Initial Catalog = CosmeticAppDB; Persist Security Info = True; User ID = sa; Password = sa;
            //Pooling = False; MultipleActiveResultSets = False; Encrypt = False; TrustServerCertificate = True"; //SQL Server Authencation
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Fluent API sử dụng tạo bảng mới many - many chi tiết đơn hàng
            modelBuilder.Entity<OrderDetails>().HasKey(sc => new { sc.OrderId, sc.ProductId });

            modelBuilder.Entity<OrderDetails>()
                .HasOne<Orders>(sc => sc.Orders)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(sc => sc.OrderId);

            modelBuilder.Entity<OrderDetails>()
               .HasOne<Product>(sc => sc.Product)
               .WithMany(s => s.OrderDetails)
               .HasForeignKey(sc => sc.ProductId);

            //Fluent API sử dụng tạo bảng mới many - many giỏ hàng
            modelBuilder.Entity<Cart>().HasKey(sc => new { sc.Account, sc.ProductId });

            modelBuilder.Entity<Cart>()
                .HasOne<Personal_Information>(sc => sc.Personal_Information)
                .WithMany(s => s.Cart)
                .HasForeignKey(sc => sc.Account);

            modelBuilder.Entity<Cart>()
               .HasOne<Product>(sc => sc.Product)
               .WithMany(s => s.Cart)
               .HasForeignKey(sc => sc.ProductId);

            //Fluent API sử dụng tạo 2 foreign key từ bảng thông tin cá nhân qua đơn hàng

            modelBuilder.Entity<Orders>()
                .HasOne(m => m.Customer)
                .WithMany(m => m.OrdersByCus)
                .HasForeignKey(m => m.CusId);

            modelBuilder.Entity<Orders>()
                .HasOne(m => m.Employee)
                .WithMany(m => m.OrdersByEmp)
                .HasForeignKey(m => m.EmpId);
        }
    }
}

///Sử dụng migration (Tools -> Nuget Package Manager -> Package Manager Console)
///Bước 1
///Tạo mới migration: add-migration CosmeticAppDBEng
///Bước 2
///Chuyển dữ liệu qua database: update-database –verbose
