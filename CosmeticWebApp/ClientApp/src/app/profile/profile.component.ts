import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-profile-data',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
    userLogin: String = document.getElementById("btnUserName").textContent;
     //user
     ward: String = "";
     district: String = "";
     city: String = "";
     address: String = "";

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
        accountTypeID: "",
        createdDate: "",
        accountStatus: "",
        note: "",
    }
    constructor(private http?: HttpClient, @Inject('BASE_URL') baseUrl?: string,
    private router?: Router, private route?: ActivatedRoute) {
        this.getUserByAccount();     
    }
    getUserByAccount() {
        this.http.get<any>('https://localhost:44394/api/Personal_Information/getCustomerByAccount/' + this.userLogin).subscribe(
            result => {
                var res: any = result;
                //Thu được dữ liệu
                if (res != null) {
                    this.user = res;
                    this.plitAndSetAddress(); //Chia địa chỉ
                    console.log(this.address);
                }
                //Không thu được dữ liệu
                else {
                    alert("Lỗi dữ liệu");
                }
            },
            error => {
                alert("Server error!!");
            });
    }
    updateUserInfo() {
        this.user.address = this.address + "," + this.ward + "," + this.district + "," + this.city;
        this.http.put<any>('https://localhost:44394/api/Personal_Information/updatePersonal_Information/'
            + this.userLogin, this.user).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        alert("Sửa thông tin thành công");
                    }
                    //Không thu được dữ liệu
                    else {
                        alert("Lỗi dữ liệu");
                    }
                },
                error => {
                    alert("Server error!!")
                });
    }
    //Các hàm khác
    plitAndSetAddress() {
        var addressList = this.user.address.split(",");
        if (addressList.length == 4) {
            this.address = addressList[0];
            this.ward = addressList[1];
            this.district = addressList[2];
            this.city = addressList[3];
        }
        else {
            this.address = this.user.address;
        }
    }
}