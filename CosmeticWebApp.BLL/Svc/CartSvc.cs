﻿using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class CartSvc
    {
        //Khởi tạo đối tượng
        private readonly CastRep _rep;
        //Phương thức khởi tạo
        public CartSvc()
        {
            _rep = new CastRep();
        }
        //Tạo
        public object CreateCart(CartReq req)
        {
            //Khởi tạo đối tượng
            Cart cart = new Cart();
            //Gán giá trị
            cart.Account = req.Account;
            cart.ProductId = req.ProductId;
            cart.Amounts = req.Amounts;
            cart.Note = req.Note;
            //Tạo giá trị vào bảng
            //Trả về giá trị
            return _rep.Create(cart);
        }
        //Sửa
        public object UpdateCartAmount(String account, String productId, int amount)
        {
            //Gán giá trị vào bảng
            //Trả về giá trị
            return _rep.UpdateAmount(account, productId, amount);
        }
        //Tìm
        public object GetCustomerCart(String account)
        {
            return _rep.GetCustomerCart(account);
        }
        //Xóa
        public object DeleteCart(String account, String productId)
        {
            return _rep.Delete(account, productId);
        }
    }
}
