import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
    selector: 'app-shoppingcart-data',
    templateUrl: './shoppingcart.component.html',
    styleUrls: ['./shoppingcart.component.css']
})

export class ShoppingcartComponent {
    userLogin: String = document.getElementById("btnUserName").textContent;
    result: any = {
        cartList: []
    }
    constructor(private http?: HttpClient, @Inject('BASE_URL') baseUrl?: string,
    private router?: Router) {
        this.getCartByAccount(this.userLogin);
    }
    productId: String = document.getElementById("btnlogin").textContent;
    getCartByAccount(account: String)
    {
        this.http.get<any>('https://localhost:44394/api/Cart/getCustomerCart/'+ account).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.result = res;
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
}