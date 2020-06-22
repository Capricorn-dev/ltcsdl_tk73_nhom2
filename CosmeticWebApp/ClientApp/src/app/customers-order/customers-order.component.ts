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
        note: "",
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
    deleleCartList()
    {
        this.http.delete<any>('https://localhost:44394/api/Cart/deleteCartList/' + this.userLogin).subscribe(
            result => {
                var res: any = result;
                //Thu được dữ liệu
                if (res != null) {
                    console.log(res); //Chỉ kiểm tra dưới console log
                }
                //Không thu được dữ liệu
                else {
                    alert("Lỗi dữ liệu");
                }
            },
            error => {
                alert("Không thể xóa. Server Error !!")
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
    customerOrder()
    {
        var order: any = {
            orderId: 0, //Dùng để hứng respone, không phải để truyền
            name: this.user.lastName + " " + this.user.firstName,
            createdDate: this.nowDate.toJSON(),
            phoneNumbOfOrder: this.user.phoneNumber,
            address: this.user.address,
            ward: this.ward,
            district: this.district,
            city: this.city,
            orderStatus: "Chưa duyệt", //Mặc định
            note: this.user.note,
            cusId: this.user.account,
            empId: "EMP1"
        }
        
        this.http.post('https://localhost:44394/api/Order/createOrder', order).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        order = res;
                        this.createOrderDetail(order); //Tạo chi tiết đơn hàng
                        this.deleleCartList(); //Xóa giỏ hàng hiện tại
                        alert("Chúc mừng bạn đã đặt hàng thành công");
                        window.location.href = "http://localhost:4200/";
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
    createOrderDetail(order: any)
    {
        var data = [];
        var index: number = 0;
        this.result.cartList.forEach(value => {
            var orderDetails: any = {
                orderId: order.orderId, //Lấy từ order vừa tạo
                productId: value.productId, //Lấy từ cart
                amounts: this.cartItemAmount[index],//Không get từ API, lấy từ Navigate Extra
                note: ""
            };
            data.push(orderDetails);
        });
        this.http.post('https://localhost:44394/api/OrderDetails/createOrderDetails', data).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                    console.log(res); //Test console
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