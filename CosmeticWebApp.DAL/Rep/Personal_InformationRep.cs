using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Personal_Information AuthenticateUser(AccountReq req)
        {
            var res = _context.Personal_Information.FirstOrDefault(variable => variable.Account.Equals(req.Account) && variable.Pass.Equals(req.Password));
            return res;
        }

        //Bị SQL Injection
        //123456789' OR 1=1 --
        //123456789' DROP TABLE Test --
        public object LoginByADO(AccountReq req)
        {
            List<object> list = new List<object>();
            var connectString = (SqlConnection)_context.Database.GetDbConnection();
            if (connectString.State == System.Data.ConnectionState.Closed)
            {
                connectString.Open();
            }
            try
            {
                string strsql = "SELECT * FROM Personal_Information WHERE Account = '" + req.Account + "' AND Pass = '" + req.Password + "';";
                SqlCommand cmd = new SqlCommand(strsql, connectString);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                SqlCommand command = new SqlCommand(strsql, connectString);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var data = new
                        {
                            Account = reader[0],
                            Pass = reader[1],
                            LastName = reader[2],
                            FristName = reader[3]
                        };
                        list.Add(data);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
