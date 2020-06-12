using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class ProductSvc
    {
        //Khởi tạo đối tượng
        private readonly ProductRep _rep;
        //Phương thức khởi tạo
        public ProductSvc()
        {
            _rep = new ProductRep();
        }
        public object CreateProduct(ProductReq req)
        {
            //Khởi tạo giá trị
            Product product = new Product();
            //Gán giá trị
            product.ProductId = req.ProductId;
            product.Name = req.Name;
            product.Price = req.Price;
            product.BrandId = req.BrandId;
            product.CategoryId = req.CategoryId;
            product.Unit = req.Unit;
            product.UnitsInStock = req.UnitsInStock;
            product.Discount = req.Discount;
            product.UnitsInStock = req.UnitsInStock;
            product.Description = req.Description;
            product.CreatedDate = req.CreatedDate;
            product.Note = req.Note;
            product.Picture = req.Picture;
            //Tạo giá trị và trả về
            return _rep.Create(product);
        }
        public object UpdateProduct(String id, ProductReq req)
        {
            //Tạo giá trị và trả về
            return _rep.Update(id ,req);
        }
        public object SearchProduct(int size, int page, String keyWord)
        {
            //Khởi tạo các đối tượng
            //Lấy tất cả giá trị
            var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Có dữ liệu
                allValues = _rep.All.Where(value => value.ProductId.Contains(keyWord) //Kiểm tra theo mã
                || value.Name.Contains(keyWord)); //Kiểm tra theo tên
            }
            //Độ dời
            int offset = (page - 1) * size;
            //Tổng số dữ liệu
            int total = allValues.Count();
            //Tổng số trang
            //Ví dụ: 12 DL / Size 5 thì bằng 2 sẽ dư 2. Do đó phải có 3 trang để chứa đủ 12 DL
            int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            //Dữ liệu theo trang
            var data = allValues.Skip(offset).Take(size).ToList(); //Trả về danh sách
            var result = new
            {
                Data = data,
                totalRecords = total,
                Page = page,
                Size = size,
                TotalPages = totalPage
            };
            return result;
        }
        public object DeleteProduct(String id)
        {
            return _rep.Delete(id);
        }
    }
}
