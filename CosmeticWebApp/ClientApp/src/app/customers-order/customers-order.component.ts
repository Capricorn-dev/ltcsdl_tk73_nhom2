import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';

declare var $: any;

@Component({
    selector: 'app-customers-order-data',
    templateUrl: './customers-order.component.html',
    styleUrls: ['./customers-order.component.css']
})
export class CustomersOrderComponent {

    //user
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
        note: "note",
    }
    //Chia địa chỉ ra
    addressList: String[];

    ward: String = "";
    district: String = "";
    city: String = "";
    address: String = "";
    //order
    nowDate = new Date();
    order: any = {
        name: "",
        createdDate: this.nowDate.toJSON(),
        phoneNumbOfOrder: "",
        address: "",
        ward: "",
        district: "",
        city: "",
        orderStatus: "Chưa duyệt", //Mặc định
        note: "",
        cusId: "",
        empId: ""
    }

    //Cart
    userLogin: String = document.getElementById("btnUserName").textContent;
    result: any = {
        cartList: []
    }
    //Total
    subtotal: number = 0;
    discount: number = 0;
    VATtax: number = 0;
    total: number = 0;
    cartItemAmount: number[]= [];
    
    setPrice()
    {
        //Subtotal
        for(var i = 0; i < this.cartItemAmount.length; i++)
        {
            //Giá món n * số lượng món n
            this.subtotal += parseInt(this.result.cartList[i].price) * this.cartItemAmount[i];
        }
        //Discount
        this.discount = 0;
        //VATtax
        this.VATtax = this.subtotal * 0.1;
        //Total
        this.total = this.subtotal + this.VATtax;
    }
    test: String;
    constructor(private http?: HttpClient, @Inject('BASE_URL') baseUrl?: string,
        private router?: Router, private route?: ActivatedRoute) {
            //console.log("Hello world!");
            this.getUserByAccount();
            this.getCartByAccount();
            //var test = (document.getElementById("cartItemAmount0")) as HTMLInputElement;
           
            // var test =  document.getElementById("test");
            // console.log(test);

            //Gán số lượng từ giỏ hàng qua đơn hàng
            var amountCart = this.route.snapshot.paramMap.get('amountList');
            try
            {
                var amountList = amountCart.split(',');
                amountList.forEach(value => {
                    this.cartItemAmount.push(parseInt(value));
                });
                console.log(amountList);
            }
            catch
            {
                alert("Không thể tách tổng số lượng")
            }

           
    }
    getUserByAccount() {
        this.http.get<any>('https://localhost:44394/api/Personal_Information/getCustomerByAccount/' + this.userLogin).subscribe(
            result => {
                var res: any = result;
                //Thu được dữ liệu
                if (res != null) {
                    this.user = res;
                    this.plitAndSetAddress(); //Chia địa chỉ
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
    getCartByAccount() {
        this.http.get<any>('https://localhost:44394/api/Cart/getCustomerCart/' + this.userLogin).subscribe(
            result => {
                
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                    this.result = res;
                    //Gán giá sau khi lấy được số lượng
                    this.setPrice();
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
    updateUserInfo() {
        this.user.address = this.address + "," + this.ward + "," + this.district + "," + this.city;
        this.http.patch<any>('https://localhost:44394/api/Personal_Information/updatePersonal_InformationPatch/'
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
    plitAndSetAddress() {
        this.addressList = this.user.address.split(",");
        if (this.addressList.length == 4) {
            this.address = this.addressList[0];
            this.ward = this.addressList[1];
            this.district = this.addressList[2];
            this.city = this.addressList[3];
        }
        else {
            this.address = this.user.address;
        }
    }
    //Modal
    openCreateUpdateModal() {
        $('#openUpateUserInfoModal').modal('show');
    }
}