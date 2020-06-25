import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';


declare var $: any;

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
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
    document.getElementById("main").style.marginLeft= "0";
  }
  openLoginModal() {
    this.user = {
      data: {
        resultAccount: Boolean,
        resultPassword: Boolean,
        account: "",
        phoneNumber: "",
        email: "",
      },
      success: Boolean
    }
    $('#LoginModal').modal('show');
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,private router:Router)
  {
    this.getAccoutInCookie();
  }
  //Handle Login
  user : any = {
    data: {
      resultAccount: Boolean,
      resultPassword: Boolean,
      account: "",
      phoneNumber: "",
      email: "",
    },
    success: Boolean
  }
  getAccoutInCookie()
  {
    //get
    this.http.get<any>('https://localhost:44394/api/Personal_Information/getAccountCookie')
    .subscribe(
      result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res != null) {
              //Parse JSON
              res = JSON.parse(res);
              console.log(res);
             //Đã tạo tạo cookie
              this.data.account = res.account;
              this.data.password = res.password;
              console.log(this.data.account);
          }
          //Chưa hề tạo cookie
          else {
              console.log("You don't have a cookie login.")
          }
          
      },
      error => {
          alert("Get Cookie API Error !!")
      });
  }
  createCookie(Account: String, Password: String)
  {
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
  checkLogin()
  {
    //post
    this.http.post('https://localhost:44394/api/Personal_Information/checkUserLogin', this.data)
    .subscribe(
      result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res != null) {
              this.user = res;
              if(this.user.data.resultAccount==true && this.user.data.resultPassword==true)
              {
                //Chỉ hiện thị giỏ hàng khi đã đăng nhập
                document.getElementById("btnShopingCast").style.visibility = "visible";
                document.getElementById("btnlogin").style.display = "none";
                //Nếu check nhớ mật khẩu thì mới tạo cookie
                if((document.getElementById("rememberLoginCheckBox") as HTMLInputElement).checked)
                {
                  //Tạo cookie
                  this.createCookie(this.data.account, this.data.password);
                }
                console.log((document.getElementById("rememberLoginCheckBox") as HTMLInputElement).checked)
                //Set text khi đăng nhập
                this.userLogin = this.user.data.account;
                this.toggleLoginModal();
               
              }
          }
          //Không thu được dữ liệu
          else {
              alert(res.message);
              document.getElementById("btnlogin").style.visibility = "visible";
          }
          
      },
      error => {
          alert("Server error!!")
      });
  }
  toggleLoginModal() {
    $('#LoginModal').modal('hide');
  }
}


