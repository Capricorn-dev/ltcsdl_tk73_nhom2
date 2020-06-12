using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class OrderDetailSvc
    {
        //Khởi tạo đối tượng
        private readonly OrderDetailRep _rep;
        //Phương thức khởi tạo
        public OrderDetailSvc()
        {
            _rep = new OrderDetailRep();
        }
        //Tạo
        public object CreateOrderDetail(OrderDetailReq req)
        {
            //Khởi tạo đối tượng
            OrderDetails orderDetails = new OrderDetails();
            //Gán giá trị
            orderDetails.OrderId = req.OrderId;
            orderDetails.ProductId = req.ProductId;
            orderDetails.Amounts = req.Amounts;
            orderDetails.Note = req.Note;
            //Tạo giá trị vào bảng
            //Trả về giá trị
            return _rep.Create(orderDetails);
        }
    }
}
