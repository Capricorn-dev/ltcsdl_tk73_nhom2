using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class BrandSvc
    {
        //Khởi tạo đối tượng
        private readonly BrandRep _rep;
        //Phương thức khởi tạo
        public BrandSvc()
        {
            _rep = new BrandRep();
        }
        //Tạo
        public object CreateBrand(BrandReq req)
        {
            //Khởi tạo đối tượng
            Brand brand = new Brand();
            //Gán giá trị
            brand.BrandId = req.BrandId;
            brand.Name = req.Name;
            brand.PhoneNumber = req.PhoneNumber;
            brand.Email = req.Email;
            brand.Description = req.Description;
            brand.StartedDate = req.StartedDate;
            brand.Note = req.Note;
            //Tạo giá trị vào bảng
            //Trả về giá trị
            return _rep.Create(brand);
        }
        //Sửa
        public object UpdateBrand(String id, BrandReq req)
        {
            //Gán giá trị vào bảng
            //Trả về giá trị
            return _rep.Update(id, req);
        }
        public object SearchBrand(int size, int page, String keyWord)
        {
            //Khởi tạo các đối tượng
            //Lấy tất cả giá trị
            var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Có dữ liệu
                allValues = _rep.All.Where(value => value.BrandId.Contains(keyWord) //Kiểm tra theo mã
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
        public object DeleteBrand(String id)
        {
            return _rep.Delete(id);
        }
    }
}
