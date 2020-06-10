using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class OrderSvc
    {
        //Khởi tạo đối tượng Rep
        private readonly OrderRep _rep;
        //Phương thức khởi tạo
        public OrderSvc()
        {
            _rep = new OrderRep(); //Truyền vào giá trị
        }
        public object CreateOrder(OrderReq req)
        {
            //Tạo đối tượng
            Orders orders = new Orders();
            //Gán giá trị
            orders.Name = req.Name;
            orders.CreatedDate = req.CreatedDate;
            orders.PhoneNumbOfOrder = req.PhoneNumbOfOrder;
            orders.Address = req.Address;
            orders.Ward = req.Ward;
            orders.District = req.District;
            orders.City = req.City;
            orders.OrderStatus = req.OrderStatus;
            orders.Note = req.Note;
            orders.CusId = req.CusId;
            orders.EmpId = req.EmpId;
            //Trả về kết quả
            return _rep.Create(orders);
        }
        public object UpdateOrder(int id, OrderReq req)
        {
            return _rep.Update(id, req);
        }
        //Tìm đơn tài khoản theo tình trạng hoặc mã đơn hàng
        public object SearchOrder(int size, int page, String keyWord)
        {
            //Khởi tạo các đối tượng
            //Lấy tất cả giá trị
            var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Có dữ liệu
                int orderId;
                try
                {
                    orderId = int.Parse(keyWord);
                }
                catch(Exception ex)
                {
                    orderId = 0; //Nếu nhập vào không phải là số thì trả mã về 0
                }
                allValues = _rep.All.Where(value => value.OrderId == orderId //Kiểm tra theo mã
                || value.OrderStatus.Contains(keyWord)); //Kiểm tra theo tên
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
        public object DeleteOrder(int id)
        {
            return _rep.Delete(id);
        }
    }
}
