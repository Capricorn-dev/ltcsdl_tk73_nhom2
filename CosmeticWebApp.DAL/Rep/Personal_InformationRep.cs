using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmeticWebApp.DAL.Rep
{
    public class Personal_InformationRep
    {
        //Khởi tạo đối tượng context
        private CosmeticContext _context;
        //Phương thức khởi tạo
        public Personal_InformationRep()
        {
            _context = new CosmeticContext(); //Sử dụng thay cho using var context
        }
        //Tạo
        public object Create(Personal_Information personalInformation)
        {
            try
            {
                _context.Personal_Information.Add(personalInformation);
                _context.SaveChanges();
                return personalInformation;
            }
            catch(Exception ex)
            {
                return ex.StackTrace; //Xuất ra lỗi
            }
        }
        //Sửa
        public object Update(String account, Personal_InformationReq req)
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    //Khởi tạo đối tượng tìm id trong bảng
                    //Tìm id
                    //Đây là row dữ liệu trả về theo ID
                    var searchResult = _context.Personal_Information.FirstOrDefault(value => value.Account == account);
                    //Tìm thấy
                    if (searchResult != null)
                    {
                        //Gán giá trị qua search result
                        //Không gán mã
                        searchResult.Pass = req.Pass;
                        searchResult.LastName = req.LastName;
                        searchResult.FirstName = req.FirstName;
                        searchResult.DateOfBirth = req.DateOfBirth;
                        searchResult.Gender = req.Gender;
                        searchResult.Address = req.Address;
                        searchResult.PhoneNumber = req.PhoneNumber;
                        searchResult.Email = req.Email;
                        searchResult.AccountTypeID = req.AccountTypeID;
                        searchResult.AccountStatus = req.AccountStatus;
                        searchResult.Note = req.Note;
                        //Thay đổi theo search result. Không thay đổi theo tham số truyền vào vì sẽ bị duplicate
                        _context.Personal_Information.Update(searchResult);
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
        public object GetCustomerByAccount(String account)
        {
            var search = _context.Personal_Information.FirstOrDefault(value => value.Account == account);
            return search;
        }
        public object CheckLogin(AccountReq req)
        { 
            //Tìm theo account
            var search = _context.Personal_Information.FirstOrDefault(value => value.Account == req.Account);
            //Khởi tạo giá trị trả về
            Boolean resultAccount = false;
            Boolean resultPassword = false;
            String account = null;
            String phoneNumber = null;
            String email = null;
            if (search != null)
            {
                resultAccount = true;
                //Tìm thấy
                if (search.Pass.Equals(req.Password)) //Kiểm tra mật khẩu
                {
                    resultPassword = true;
                    account = search.Account;
                    phoneNumber = search.PhoneNumber;
                    email = search.Email;
                }
            }
            //Giá trị
            var data = new
            {
                ResultAccount = resultAccount,
                ResultPassword = resultPassword,
                Account = account,
                PhoneNumber = phoneNumber,
                Email = email
            };
            //Kết quả
            var result = new
            {
                Data = data,
                Success = true
            };
            //Trả về kết quả
            return result;
        }
    }
}
