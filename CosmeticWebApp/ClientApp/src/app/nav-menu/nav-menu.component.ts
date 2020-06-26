import { Component, Inject, AfterViewInit, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';


declare var $: any;

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent{
  // ngOnInit()
  // {
  //   try{
  //     this.getAccountSession();
  //   }
  //   catch
  //   {
  //     console.log("Error Token Cookie")
  //   }
  // }
  tokenCookie: String = "";
  isLogin: Boolean;
  userLogin: String = "Người dùng"; //Mặc định
  isExpanded = false;
  //Kiểm tra xem Login có đúng hay ko 

  data: any = {
    account: "",
    password: ""
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  openNav() {
    document.getElementById("mySidenav").style.width = "195px";
    document.getElementById("main").style.marginLeft = "195px";
  }

  closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
  }
  openLoginModal() {
    // this.user = {
    //   data: {
    //     resultAccount: Boolean,
    //     resultPassword: Boolean,
    //     account: "",
    //     phoneNumber: "",
    //     email: "",
    //   },
    //   success: Boolean
    // }
    try
    {
      this.getTokenCookie();
      
    }
    catch
    {

    }
    console.log(this.tokenCookie);
    $('#LoginModal').modal('show');
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    try{
      this.getAccountSession();
    }
    catch
    {
      console.log("Error Account Session")
    }
    console.log(this.isLogin);
    
  }
  //Handle Login
  user: any = {
    data: {
      resultAccount: Boolean,
      resultPassword: Boolean,
      account: "",
      phoneNumber: "",
      email: "",
    },
    success: Boolean
  }
  //Cookie
  removeTokenCookie() {
    //post
    this.http.post('https://localhost:44394/api/Personal_Information/removeTokenCookie', true)
      .subscribe(
        result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res != null) {
            console.log(res);
          }
          //Chưa hề tạo cookie
          else {
            console.log("You don't have a cookie login.");
          }

        },
        error => {
          //alert("Get Cookie API Error !!");
        });
  }
  getTokenCookie() {
    //get
    this.http.get<any>('https://localhost:44394/api/Personal_Information/getTokenCookie')
      .subscribe(
        result => {
          var res: String = result;
          //Thu được dữ liệu
          if (res != null) {
            this.tokenCookie = res;
            console.log(this.tokenCookie);
            //Sau khi có token thì get account
            try
            {
              this.getAccountByTooken(this.tokenCookie);
              console.log("Got token");
            }
            catch
            {
              this.data.account = "";
              this.data.password = "";
              console.log("No token");
            }
          }
          //Chưa hề tạo cookie
          else {
            console.log("You don't have a token cookie")
          }

        },
        error => {
          var err: any = error;
          console.log(err);
          alert("Get Cookie API Error !!");
        });
  }
  createCookie(Account: String, Password: String) {
    //Covert to JSON
    var post = {
      account: Account,
      password: Password
    }
    //post
    this.http.post('https://localhost:44394/api/Personal_Information/createAccountCookie', post)
      .subscribe(
        result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res.success) {
            console.log("Create Cookie Login Success !!")
          }
          //Không thu được dữ liệu
          else {
            console.log(res.error)
          }
        },
        error => {
          alert("Create Cookie Server Error !!")
        });
  }
  //Session
  getAccountSession() {
    //get
    this.http.get<any>('https://localhost:44394/api/Personal_Information/getAccountSession')
      .subscribe(
        result => {
          var res: any = result;
          //Thu được dữ liệu
          if (res != null) {
            this.userLogin = res //Session lưu tài khoản
            console.log(this.userLogin)
            this.isLogin = true;
            document.getElementById("btnShopingCast").style.visibility = "visible";
            document.getElementById("btnlogin").style.display = "none";
          }
          //Không thu được dữ liệu
          else {
            alert(res.message);
          }
        },
        error => {
          alert("Create Cookie Server Error !!")
        });

  }
  deleteAccountSession() {
    //post
    this.http.post('https://localhost:44394/api/Personal_Information/deleteAccountSession', true)
      .subscribe(
        result => {
          var res: any = result;
          //Thu được dữ liệu
          if (res != null) {
            console.log("Clear session")
            this.isLogin = false;
          }
          //Không thu được dữ liệu
          else {
            alert(res.message);
          }
        },
        error => {
          //alert("Delete Cookie Server Error !!")
        });
  }
  //Tooken
  getAccountByTooken(token: String)
  {
     //Tooken
     var bearerTooken = token;
     //Chuyển sang header
     var headers_object = new HttpHeaders().set("Authorization", "Bearer " + bearerTooken);
     //Chọn option
     const httpOptions = {
         headers: headers_object
       };
       
    //get
    this.http.get<any>('https://localhost:44394/api/Personal_Information/getAccountByTooken', httpOptions)
    .subscribe(
      result => {
        var res: any = result;
        //Thu được dữ liệu
        if (res != null) {
          this.data.account = res.account;
          this.data.password = res.password;
        }
        //Không thu được dữ liệu
        else {
          alert(res.message);
        }
      },
      error => {
        alert("Create Cookie Server Error !!")
      });
  }

  //Login
  checkLogin() {
    //post
    this.http.post('https://localhost:44394/api/Personal_Information/Login', this.data)
      .subscribe(
        result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res != null) {
            //this.user = res;
            //Đã đăng nhập
            this.isLogin = true
            //Chỉ hiện thị giỏ hàng khi đã đăng nhập
            document.getElementById("btnShopingCast").style.visibility = "visible";
            document.getElementById("btnlogin").style.display = "none";
            //Nếu check nhớ mật khẩu thì mới tạo cookie
            if ((document.getElementById("rememberLoginCheckBox") as HTMLInputElement).checked == false) {
              //Xóa cookie đã tạo trước đó
              this.removeTokenCookie();
            }
            this.getAccountSession(); //Get session
            this.toggleLoginModal();

          }
          //Không thu được dữ liệu
          else {
            alert(res.message);
            document.getElementById("btnlogin").style.visibility = "visible";
          }

        },
        error => {
          alert("Server error!!")
        })
  }
  toggleLoginModal() {
    $('#LoginModal').modal('hide');
  }

}


