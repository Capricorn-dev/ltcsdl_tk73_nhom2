using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class CategorySvc
    {
        //Khởi tạo đối tượng
        private readonly CategoryRep _rep;
        //Phương thức khởi tạo
        public CategorySvc()
        {
            _rep = new CategoryRep();
        }
        public object CreateCategory(CategoryReq req)
        {
            //Khởi tạo giá trị
            Category category = new Category();
            //Gán giá trị
            category.CategoryId = req.CategoryId;
            category.Name = req.Name;
            category.Description = req.Description;
            category.CreatedDate = req.CreatedDate;
            category.Note = req.Note;
            //Tạo giá trị và trả về
            return _rep.Create(category);
        }
        public object UpdateCategory(String id, CategoryReq req)
        {
            return _rep.Update(id, req);
        }
        public object SearchCategory(int size, int page, String keyWord)
        {
            //Khởi tạo các đối tượng
            //Lấy tất cả giá trị
            var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Có dữ liệu
                allValues = _rep.All.Where(value => value.CategoryId.Contains(keyWord) //Kiểm tra theo mã
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
        public object DeleteCategory(String id)
        {
            return _rep.Delete(id);
        }
    }
}
