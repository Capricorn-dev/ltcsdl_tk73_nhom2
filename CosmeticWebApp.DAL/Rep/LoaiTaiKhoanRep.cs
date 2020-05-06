using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class LoaiTaiKhoanRep
    {
        // Các class được trả về là một object để chứa các giá trị đã tạo
        //Tạo
        public object Create(LoaiTaiKhoan loaiTaiKhoan)
        {
            using(var context = new CosmeticContext()) //Sửa dụng datacontext
            {
                try
                {
                    context.LoaiTaiKhoan.Add(loaiTaiKhoan);
                    context.SaveChanges();
                    return loaiTaiKhoan;
                }
                catch(Exception ex)
                {
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        //Sửa
        public object Update(LoaiTaiKhoan loaiTaiKhoan)
        {
            using(var context = new CosmeticContext())
            {
                try
                {
                    context.LoaiTaiKhoan.Update(loaiTaiKhoan);
                    context.SaveChanges();
                    return loaiTaiKhoan;
                }
                catch (Exception ex)
                {
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
    }
}
