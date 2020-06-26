using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.BLL.Svc
{
    public class Personal_InformationSvc
    {
        //Khởi tạo đối tượng Rep
        private readonly Personal_InformationRep _rep;
        //Phương thức khởi tạo
        public Personal_InformationSvc()
        {
            _rep = new Personal_InformationRep(); //Truyền vào giá trị
        }
        public object CreatePersonal_Information(Personal_InformationReq req)
        {
            //Khởi tạo đối tượng
            Personal_Information personalInformation = new Personal_Information();
            //Gán giá trị
            personalInformation.Account = req.Account;
            personalInformation.Pass = req.Pass;
            personalInformation.LastName = req.LastName;
            personalInformation.FirstName = req.FirstName;
            personalInformation.DateOfBirth = req.DateOfBirth;
            personalInformation.Gender = req.Gender;
            personalInformation.Address = req.Address;
            personalInformation.PhoneNumber = req.PhoneNumber;
            personalInformation.Email = req.Email;
            personalInformation.AccountTypeID = req.AccountTypeID; //Chỉ chính xác là đối tượng khóa ngoại
            personalInformation.CreatedDate = req.CreatedDate;
            personalInformation.AccountStatus = req.AccountStatus;
            personalInformation.Note = req.Note;
            //Truyền giá trị
            return _rep.Create(personalInformation);
        }

        public object UpdatePersonal_Information(String account, Personal_InformationReq req)
        {
            
            return _rep.Update(account, req);
        }
        public object CheckLogin(AccountReq req)
        {
            return _rep.CheckLogin(req);
        }
        public Personal_Information AuthenticateUser(AccountReq req)
        {
            var res = _rep.AuthenticateUser(req);
            return res;
        }
        public object GetCustomerByAccount(String account)
        {
            return _rep.GetCustomerByAccount(account);
        }

        //ADO
        public object LoginByADO(AccountReq req)
        {
            return _rep.LoginByADO(req);
        }
    }
}
