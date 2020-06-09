using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class OrderRep
    {
        //Khởi tạo đối tượng context
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public OrderRep()
        {
            _context = new CosmeticContext(); //Sử dụng thay cho using var context
        }
        //Tạo
        public object Create(Orders orders)
        {
            using(var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Orders.Add(orders);
                    _context.SaveChanges();
                    tran.Commit();
                    return orders;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        //Sửa
        public object Update(int id, OrderReq req)

        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    //Khởi tạo đối tượng tìm id trong bảng
                    //Tìm id
                    //Đây là row dữ liệu trả về theo ID
                    var searchResult = _context.Orders.FirstOrDefault(value => value.OrderId == id);
                    //Tìm thấy
                    if (searchResult != null)
                    {
                        //Gán giá trị qua search result
                        //Không gán mã
                        searchResult.Name = req.Name;
                        searchResult.CreatedDate = req.CreatedDate;
                        searchResult.PhoneNumbOfOrder = req.PhoneNumbOfOrder;
                        searchResult.Address = req.Address;
                        searchResult.Ward = req.Ward;
                        searchResult.District = req.District;
                        searchResult.City = req.City;
                        searchResult.OrderStatus = req.OrderStatus;
                        searchResult.Note = req.Note;
                        searchResult.CusId = req.CusId;
                        searchResult.EmpId = req.EmpId;
                        //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
                        _context.Orders.Update(searchResult);
                        _context.SaveChanges();
                        tran.Commit();
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
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        public object Delete(int id)
        {
            using (var tran = _context.Database.BeginTransaction()) //Sử dụng tran để có thể xử lí khi dữ liệu lỗi
            {
                //Tìm dữ liệu theo id
                var searchResult = _context.Orders.FirstOrDefault(value => value.OrderId == id);
                try
                {
                    if (searchResult != null)
                    {
                        _context.Remove(searchResult);
                        _context.SaveChanges();
                        tran.Commit();
                        return searchResult;
                    }
                    else
                    {
                        return "Unable to delete: not found ID.";
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        //Lấy tất cả dữ liệu
        public IQueryable<Orders> All
        {
            get
            {
                IQueryable<Orders> result = _context.Orders;
                //2 dòng này giống nhau về ý nghĩa nhưng cách viết khác nhau. Đều trả về tất cả giá trị của 1 bảng
                return result;
                //return context.Brand;
            }
        }
    }
}
