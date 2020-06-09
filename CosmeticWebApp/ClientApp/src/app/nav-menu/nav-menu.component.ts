import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
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
    $('#LoginModal').modal('show');
  }
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    //this.checkLogin();
  }
  //Handle Login
  user : any = {
    data: {},
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
          }
          //Không thu được dữ liệu
          else {
              alert(res.message);
          }
      },
      error => {
          alert("Server error!!")
      });
  }
  
}
