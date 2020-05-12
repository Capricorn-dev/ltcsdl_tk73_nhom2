using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class AccountTypeRep
    {
        //Khởi tạo đối tượng context
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public AccountTypeRep()
        {
            _context = new CosmeticContext(); //Sử dụng thay cho using var context
        }
        // Các class được trả về là một object để chứa các giá trị đã tạo
        //Tạo
        public object Create(AccountType accountType)
        {
            try
            {
                _context.AccountType.Add(accountType);
                _context.SaveChanges();
                return accountType;
            }
            catch(Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        //Sửa
        public object Update(AccountType accountType)
        {
            try
            {
                //Khởi tạo đối tượng tìm id trong bảng
                //Tìm id
                //Đây là row dữ liệu trả về theo ID
                var searchResult = _context.AccountType.FirstOrDefault(value => value.AccountTypeID == accountType.AccountTypeID);
                //Tìm thấy
                if (searchResult != null)
                {
                    //Gán giá trị qua search result
                    //Không gán mã
                    searchResult.Name = accountType.Name;
                    searchResult.Note = accountType.Note;
                    //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
                    _context.AccountType.Update(searchResult);
                    _context.SaveChanges();
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
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
    }
}
