using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class BrandRep
    {
        //Khởi tạo đối tượng context
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public BrandRep()
        {
            _context = new CosmeticContext(); //Sử dụng thay cho using var context
        }
        // Các class được trả về là một object để chứa các giá trị đã tạo
        //Tạo
        public object Create(Brand brand)
        {
            try
            {
                _context.Brand.Add(brand);
                _context.SaveChanges();
                return brand;
            }
            catch (Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }

        public object Update(String id, BrandReq req)
        {
            try
            {
                //Khởi tạo đối tượng tìm id trong bảng
                //Tìm id
                //Đây là row dữ liệu trả về theo ID
                var searchResult = _context.Brand.FirstOrDefault(value => value.BrandId == id);
                //Tìm thấy
                if (searchResult != null)
                {
                    //Gán giá trị qua search result
                    //Không gán mã
                    searchResult.Name = req.Name;
                    searchResult.PhoneNumber = req.PhoneNumber;
                    searchResult.Email = req.Email;
                    searchResult.Description = req.Description;
                    searchResult.StartedDate = req.StartedDate;
                    searchResult.Note = req.Note;
                    //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
                    _context.Brand.Update(searchResult);
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
        public object Delete(String id)
        {
            //Tìm dữ liệu theo id
            var searchResult = _context.Brand.FirstOrDefault(value => value.BrandId == id);
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
            catch (Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        public IQueryable<Brand> All
        {
            get
            {
                IQueryable<Brand> result = _context.Brand;
                //2 dòng này giống nhau về ý nghĩa nhưng cách viết khác nhau. Đều trả về tất cả giá trị của 1 bảng
                return result;
                //return context.Brand;
            }
        }
    }
}
