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
    this.data = {
      account: "123456789",
      password: "123456789"
    }
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
    //this.checkLogin();
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


