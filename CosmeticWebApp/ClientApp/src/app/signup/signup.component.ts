import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';
declare var $: any;
@Component({
    selector: 'app-signup-data',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.css']
})
export class SignupComponent {
    nowDate = new Date();
    birthDay: Date
    name: String;
    user: any = {
        account: "",
        pass: "",
        lastName: "",
        firstName: "",
        dateOfBirth: "",
        gender: "",
        address: "",
        phoneNumber: "",
        email: "",
        accountTypeID: "CUS",
        createdDate: this.nowDate.toJSON(),
        accountStatus: "Bình thường", //Mặc định
        note: "",

    }
   
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
     private router: Router) {
       
    }
    //Tạo
    createUser() {
        var date: Date = new Date(this.user.dateOfBirth);
        this.user.dateOfBirth = date.toJSON();
        //post
        this.http.post('https://localhost:44394/api/Personal_Information/createPersonal_Information', this.user).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                alert("Chúc mừng bạn tạo tài khoản thành công !!");
                this.router.navigate(['/']); //Chuyển về trang chủ
                }
                //Không thu được dữ liệu
                else {
                    alert(res);
                }
            },
            error => {
                alert("Server error!!")
            });
    }
}