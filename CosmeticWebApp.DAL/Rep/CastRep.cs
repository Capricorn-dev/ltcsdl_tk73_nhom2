using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class CastRep
    {
        //Khởi tạo đối tượng context
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public CastRep()
        {
            _context = new CosmeticContext(); //Sử dụng thay cho using var context
        }
        //Tạo
        public object Create(Cart cart)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Cart.Add(cart);
                    _context.SaveChanges();
                    tran.Commit();
                    return cart;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        //Sửa
        public object UpdateAmount(String account, String productId, int amount)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                var result = _context.Cart.FirstOrDefault(c => c.Account == account && c.ProductId == productId);
                result.Amounts = amount;
                try
                {
                    _context.Cart.Update(result);
                    _context.SaveChanges();
                    tran.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }

        //Xóa
        public object Delete(String account, String productId)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                var result = _context.Cart.FirstOrDefault(c => c.Account == account && c.ProductId == productId);
                try
                {
                    _context.Cart.Remove(result);
                    _context.SaveChanges();
                    tran.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return ex.StackTrace; //Xuất ra lỗi
                }
            }
        }
        public IQueryable<Cart> All
        {
            get
            {
                IQueryable<Cart> result = _context.Cart;
                //2 dòng này giống nhau về ý nghĩa nhưng cách viết khác nhau. Đều trả về tất cả giá trị của 1 bảng
                return result;
                //return context.Brand;
            }
        }
        public object GetCustomerCart(String account)
        {
             var result = _context.Cart
            .Where(c => c.Account == account)
            .Join(_context.Product, c => c.ProductId, p => p.ProductId, (c, p) => new
            {
                p.Name,
                p.Unit,
                p.Price,
                p.Picture,
                c.Account
            }).ToArray();
            var data = new
            {
                CartList = result
            };
            return data;
        }
    }
}
