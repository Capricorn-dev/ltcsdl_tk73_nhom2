using CosmeticWebApp.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.DAL
{
    public class CosmeticContext : DbContext
    {
        public DbSet<ThongTinCaNhan> ThongTinCaNhan { get; set; }
        public DbSet<LoaiTaiKhoan> LoaiTaiKhoan { get; set; }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=CosmeticAppDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Fluent API sử dụng tạo bảng mới many - many chi tiết đơn hàng
            modelBuilder.Entity<ChiTietDonHang>().HasKey(sc => new { sc.MaDH, sc.MaSP });

            modelBuilder.Entity<ChiTietDonHang>()
                .HasOne<DonHang>(sc => sc.DonHang)
                .WithMany(s => s.ChiTietDonHang)
                .HasForeignKey(sc => sc.MaDH);

            modelBuilder.Entity<ChiTietDonHang>()
               .HasOne<SanPham>(sc => sc.SanPham)
               .WithMany(s => s.ChiTietDonHang)
               .HasForeignKey(sc => sc.MaSP);

            //Fluent API sử dụng tạo 2 foreign key từ bảng thông tin cá nhân qua đơn hàng

            modelBuilder.Entity<DonHang>()
                .HasOne(m => m.KhachHang)
                .WithMany(m => m.DonHangKhachHang)
                .HasForeignKey(m => m.MaKH);

            modelBuilder.Entity<DonHang>()
                .HasOne(m => m.NhanVien)
                .WithMany(m => m.DonHangNhanVien)
                .HasForeignKey(m => m.MaNV);

        }
    }
}

///Sử dụng migration (Tool -> Nuget Package Manager -> Package Manager Console)
///Bước 1
///Tạo mới migration: add-migration CreateCosmeticAppDB
///Bước 2
///Chuyển dữ liệu qua database: update-database –verbose
