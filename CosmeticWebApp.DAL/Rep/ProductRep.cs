using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class ProductRep
    {
        //Khởi tạo giá trị
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public ProductRep()
        {
            _context = new CosmeticContext();
        }
        // Các class được trả về là một object để chứa các giá trị đã tạo
        //Tạo
        public object Create(Product product)
        {
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        public object Update(String id, ProductReq req)
        {
            try
            {
                //Khởi tạo đối tượng tìm id trong bảng
                //Tìm id
                //Đây là row dữ liệu trả về theo ID
                var searchResult = _context.Product.FirstOrDefault(value => value.ProductId == id);
                //Tìm thấy
                if (searchResult != null)
                {
                    //Gán giá trị qua search result
                    //Không gán mã
                    searchResult.Name = req.Name;
                    searchResult.Price = req.Price;
                    searchResult.BrandId = req.BrandId;
                    searchResult.CategoryId = req.CategoryId;
                    searchResult.Unit = req.Unit;
                    searchResult.UnitsInStock = req.UnitsInStock;
                    searchResult.Discount = req.Discount;
                    searchResult.UnitsInStock = req.UnitsInStock;
                    searchResult.Description = req.Description;
                    searchResult.CreatedDate = req.CreatedDate;
                    searchResult.Note = req.Note;
                    searchResult.Picture = req.Picture;
                    //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
                    _context.Product.Update(searchResult);
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
            var searchResult = _context.Product.FirstOrDefault(value => value.ProductId == id);
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
        public IQueryable<Product> All
        {
            get
            {
                IQueryable<Product> result = _context.Product;
                //2 dòng này giống nhau về ý nghĩa nhưng cách viết khác nhau. Đều trả về tất cả giá trị của 1 bảng
                return result;
                //return context.Product;
            }
        }

    }
}
