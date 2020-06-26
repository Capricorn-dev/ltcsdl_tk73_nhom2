using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CosmeticWebApp.BLL.Svc;
using CosmeticWebApp.Common.Req;
using CosmeticWebApp.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CosmeticWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personal_InformationController : ControllerBase
    {
        //Khởi tạo đối tượng service
        private readonly Personal_InformationSvc _svc;
        //Phương thức khởi tạo
        //public Personal_InformationController()
        //{
        //    _svc = new Personal_InformationSvc();
        //}
        //JSON Web Tooken
        //Configruation
        private IConfiguration _config;
       
        public Personal_InformationController(IConfiguration configuration)
        {
            _config = configuration;
            _svc = new Personal_InformationSvc();
        }
        [HttpPost("Login")]
        public IActionResult Login(AccountReq req)
        {
            IActionResult response = Unauthorized(); //Không được phép

            var user = _svc.AuthenticateUser(req); //Truyền tài khoản

            if(user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new
                {
                    token = tokenStr,
                    account = user.Account
                }); //Response token
                CreateAccessTokenCookie(tokenStr); //Create Cookie
                HttpContext.Session.SetString("AccountSession", user.Account); //Create account session
                HttpContext.Session.SetString("TookenSession", tokenStr); //Create tooken session
            }
            return response;
        }
        [Authorize]
        [HttpGet("getAccountByTooken")]
        public IActionResult GetAccountByTooken()
        {
            var indentity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = indentity.Claims.ToList();
            var user = new
            {
                account = claim[0].Value, //Account
                password = claim[1].Value //Password
            };
            return Ok(user);
        }
        //Khởi tạo GenerateJSONWebToken
        private string GenerateJSONWebToken(Personal_Information userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])); //Khai báo appsetting.Json
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // ?

            //Yêu cầu
            var claims = new[] //?
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Account),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Pass),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken //?
            (
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120), //Hạn sử dụng
                signingCredentials: credentials
            );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token); //Tạo token
            return encodetoken;
        }
        //Session
        [HttpGet("getTokenSession")]
        public IActionResult GetTokenSession()
        {
            var result = JsonConvert.SerializeObject(HttpContext.Session.GetString("TookenSession"));
            return Ok(result);
        }
        [HttpGet("getAccountSession")]
        public IActionResult GetAccountSession()
        {
            var result = JsonConvert.SerializeObject(HttpContext.Session.GetString("AccountSession"));
            return Ok(result);
        }
        [HttpPost("deleteAccountSession")]
        public IActionResult DeleteAccountSession()
        {
            HttpContext.Session.Clear();
            return Ok("Clear session");
        }
        //Cookie
        //Create when have access token
        [HttpPost("createAccessTokenCookie")]
        public void CreateAccessTokenCookie(string accessToken)
        {
            string key = "AccessToken"; //Đây là key cookie dùng để truy xuất
            try
            {
                CookieOptions cookieOptions = new CookieOptions(); //Khởi tạo cookie options
                cookieOptions.Expires = DateTime.Now.AddMinutes(120); //Hạn sử dụng trong 120 phút
                Response.Cookies.Append(key, accessToken, cookieOptions); //Khởi tạo cookie
            }
            catch(Exception ex)
            {
                
            }
        }
        //Reading
        [HttpGet("getTokenCookie")]
        public IActionResult GetTokenCookie()
        {
            string key = "AccessToken"; //Đây là key cookie dùng để truy xuất
            String AccessTokenCookie = "";
            if(Request.Cookies[key] != null)
            {
                AccessTokenCookie = JsonConvert.SerializeObject(Request.Cookies[key].ToString()); //Phải parse sang JSON nếu không sang Angular sẽ lỗi
            }
            else
            {
                return Ok(null); //Nếu không có Cookie
            }
            return Ok(AccessTokenCookie);

        }
        //Remove cookie
        [HttpPost("removeTokenCookie")]
        public IActionResult RemoveTookenCookie()
        {
            string key = "AccessToken"; //Đây là key cookie dùng để truy xuất
            string value = ""; //Trả về giá trị rỗng khi xóa
            CookieOptions cookieOptions = new CookieOptions(); //Khởi tạo cookie options
            cookieOptions.Expires = DateTime.Now.AddDays(-1); //Không có hạn sử dụng
            Response.Cookies.Append(key, value, cookieOptions); //Khởi tạo cookie
            return Ok("Remove Cookie Success");
        }

        //Tạo
        [HttpPost("createPersonal_Information")]
        public IActionResult CreatePersonal_Information(Personal_InformationReq req)
        {
            var result = _svc.CreatePersonal_Information(req);
            return Ok(result);
        }
        //Sửa
        [HttpPut("updatePersonal_Information/{account}")]
        public IActionResult UpdatePersonal_InformationPatch(String account, Personal_InformationReq req)
        {
            var result = _svc.UpdatePersonal_Information(account, req);
            return Ok(result);
        }
        //Kiểm tra đăng nhập
        [HttpPost("checkUserLogin")]
        public IActionResult CheckLogin(AccountReq req)
        {
            var result = _svc.CheckLogin(req);
            return Ok(result);
        }
        [HttpGet("getCustomerByAccount/{account}")]
        public object GetCustomerByAccount(String account)
        {
            return Ok(_svc.GetCustomerByAccount(account));
        }

        //ADO
        [HttpPost("loginByADO")]
        public object LoginByADO(AccountReq req)
        {
            return _svc.LoginByADO(req);
        }
    }
}