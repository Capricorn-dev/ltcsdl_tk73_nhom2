using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using CosmeticWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticWebApp.BLL
{
    public class AccountTypeSvc
    {
        //Khởi tạo đối tượng rep
        private readonly AccountTypeRep _rep;
        //Phương thức khởi tạo
        public AccountTypeSvc()
        {
            _rep = new AccountTypeRep();
        }
        public object CreateAccountType(AccountTypeReq req)
        {
            //Khởi tạo đối tượng
            AccountType accountType = new AccountType();
            //Gán giá trị
            accountType.AccountTypeID = req.AccountTypeID;
            accountType.Name = req.Name;
            accountType.Note = req.Note;
            //Tạo giá trị vào bảng
            //Trả về giá trị
            return _rep.Create(accountType);
        }
        public object UpdateAccountType(AccountTypeReq req)
        {
            //Khởi tạo đối tượng
            AccountType accountType = new AccountType();
            //Gán giá trị
            accountType.AccountTypeID = req.AccountTypeID;
            accountType.Name = req.Name;
            accountType.Note = req.Note;
            //Tạo giá trị vào bảng       
            //Trả về giá trị
            return _rep.Update(accountType);
        }
    }
}
