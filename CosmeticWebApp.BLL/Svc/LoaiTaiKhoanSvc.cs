using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.BLL
{
    public class LoaiTaiKhoanSvc
    {
        //Khởi tạo đối tượng rep
        private readonly LoaiTaiKhoanRep _rep;
        //Phương thức khởi tạo
        public LoaiTaiKhoanSvc()
        {
            _rep = new LoaiTaiKhoanRep();
        }
        public object CreateLoaiTaiKhoan(LoaiTaiKhoanReq req)
        {
            //Khởi tạo đối tượng
            LoaiTaiKhoan loaiTaiKhoan = new LoaiTaiKhoan();
            //Gán giá trị
            loaiTaiKhoan.MaLTK = req.MaLTK;
            loaiTaiKhoan.Ten = req.Ten;
            loaiTaiKhoan.GhiChu = req.GhiChu;
            //Tạo giá trị vào bảng
            _rep.Create(loaiTaiKhoan);
            //Trả về giá trị
            return loaiTaiKhoan;
        }
        public object UpdateLoaiTaiKhoan(LoaiTaiKhoanReq req)
        {
            //Khởi tạo đối tượng
            LoaiTaiKhoan loaiTaiKhoan = new LoaiTaiKhoan();
            //Gán giá trị
            loaiTaiKhoan.MaLTK = req.MaLTK;
            loaiTaiKhoan.Ten = req.Ten;
            loaiTaiKhoan.GhiChu = req.GhiChu;
            //Tạo giá trị vào bảng
            _rep.Update(loaiTaiKhoan);
            //Trả về giá trị
            return loaiTaiKhoan;
        }
    }
}
