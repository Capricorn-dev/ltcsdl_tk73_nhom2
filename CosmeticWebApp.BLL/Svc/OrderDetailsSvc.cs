using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class OrderDetailsSvc
    {
        //Khởi tạo đối tượng
        private readonly OrderDetailsRep _rep;
        //Phương thức khởi tạo
        public OrderDetailsSvc()
        {
            _rep = new OrderDetailsRep();
        }
        //Tạo
        public object CreateOrderDetail(OrderDetailsReq[] reqList)
        {
            //Khởi tạo đối tượng
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            //Gán giá trị
            foreach(OrderDetailsReq req in reqList)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderId = req.OrderId;
                orderDetails.ProductId = req.ProductId;
                orderDetails.Amounts = req.Amounts;
                orderDetails.Note = req.Note;
                orderDetailsList.Add(orderDetails);
            }
            //Tạo giá trị vào bảng
            //Trả về giá trị
            return _rep.Create(orderDetailsList);
        }
    }
}
