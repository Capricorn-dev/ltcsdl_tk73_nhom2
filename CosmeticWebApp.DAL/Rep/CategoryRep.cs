using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class CategoryRep
    {
        //Khởi tạo giá trị
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public CategoryRep()
        {
            _context = new CosmeticContext();
        }
        // Các class được trả về là một object để chứa các giá trị đã tạo
        //Tạo
        public object Create(Category category)
        {
            try
            {
                _context.Category.Add(category);
                _context.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        //Sửa
        public object Update(String id, CategoryReq req)
        {
            try
            {
                //Khởi tạo đối tượng tìm id trong bảng
                //Tìm id
                //Đây là row dữ liệu trả về theo ID
                var searchResult = _context.Category.FirstOrDefault(value => value.CategoryId == id);
                //Tìm thấy
                if (searchResult != null)
                {
                    //Gán giá trị qua search result
                    //Không gán mã
                    searchResult.Name = req.Name;
                    searchResult.Description = req.Description;
                    searchResult.CreatedDate = req.CreatedDate;
                    searchResult.Note = req.Note;
                    //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
                    _context.Category.Update(searchResult);
                    _context.SaveChanges();
                    return searchResult;
                }
                //Không tìm thấy
                else
                {
                    return "Unable to update: not found ID.";
                }
            }
            catch (Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        //Xóa
        public object Delete(String id)
        {
            //Tìm dữ liệu theo id
            var searchResult = _context.Category.FirstOrDefault(value => value.CategoryId == id);
            try
            {
                if (searchResult != null)
                {
                    _context.Remove(searchResult);
                    _context.SaveChanges();
                    return searchResult;
                }
                else
                {
                    return "Unable to delete: not found ID.";
                }
            }
            catch(Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
            
        }
        //Tìm
        //public object Search()
        //{
        //    using (var context = new CosmeticContext())
        //    {
        //        var data = context.DanhMuc.ToList();
        //        return data;
        //    }
        //}

            //public IQueryable<DanhMuc> All
            //{
            //    get
            //    {
            //        using (var context = new CosmeticContext())
            //        {
            //            IQueryable<DanhMuc> result = context.DanhMuc;
            //            //2 dòng này giống nhau về ý nghĩa nhưng cách viết khác nhau. Đều trả về tất cả giá trị của 1 bảng
            //            return result;
            //            //return context.DanhMuc;
            //        }
            //    }
            //}

            //Đây là hàm lấy tất cả giá trị của 1 bảng
            //Sử dụng IQueryable<DanhMuc> để chỉ đích danh là trả về giá trị nào
            //KHÔNG THỂ SỬ DỤNG using (var context = new CosmeticContext()) VÌ ĐỂ GET DATA PHẢI CÓ ĐỐI TƯỢNG DÙNG CHUNG
            //PHẢI KHỞI TẠO GIÁ TRỊ VÀ CÓ PHƯƠNG THỨC KHỞI TẠO
        public IQueryable<Category> All
        {
            get
            {
                IQueryable<Category> result = _context.Category;
                //2 dòng này giống nhau về ý nghĩa nhưng cách viết khác nhau. Đều trả về tất cả giá trị của 1 bảng
                return result;
                //return context.DanhMuc;
            }
        }
        
    }
}
