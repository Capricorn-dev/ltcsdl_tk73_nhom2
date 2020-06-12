using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class OrderDetailRep
    {
        //Khởi tạo đối tượng context
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public OrderDetailRep()
        {
            _context = new CosmeticContext(); //Sử dụng thay cho using var context
        }
        //Tạo
        public object Create(OrderDetails orderDetails)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.OrderDetails.Add(orderDetails);
                    _context.SaveChanges();
                    tran.Commit();
                    return orderDetails;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        //Sửa
        //public object Update(int orderId, String productId, OrderDetailReq req)

        //{
        //    using (var tran = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Khởi tạo đối tượng tìm id trong bảng
        //            //Tìm id
        //            //Đây là row dữ liệu trả về theo ID
        //            var searchResultList = _context.OrderDetails.Where(value => value.OrderId == orderId).ToList();
        //            //Tìm thấy
        //            if (searchResultList != null)
        //            {
        //                foreach(OrderDetails od in searchResultList)
        //                {
        //                    //
        //                }
        //                //Gán giá trị qua search result
        //                //Không gán mã
                       
        //                //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
        //                _context.Orders.Update(searchResult);
        //                _context.SaveChanges();
        //                tran.Commit();
        //                return searchResultList;
        //            }
        //            //Không tìm thấy
        //            else
        //            {
        //                return "Unable to update: not found ID.";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            tran.Rollback();
        //            return ex.StackTrace; //Xuất ra lỗi
        //        }
        //    }
        //}
    }
}
