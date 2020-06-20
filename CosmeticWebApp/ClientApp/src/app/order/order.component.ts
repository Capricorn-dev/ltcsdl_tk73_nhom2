import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;

@Component({
    selector: 'app-order-data',
    templateUrl: './order.component.html'
})
export class OrderComponent {
     //Mặc định
     ///Các biến tìm kiếm
     //Phân trang
     size: number = 5;
     page: number = 1;
     keyWord: String = "Chưa duyệt" //Mặc định;
     //Biến response
     orders: any = {
        data: [],
        totalRecords: 0,
        page: 0,
        size: this.size,
        totalPages: 0,
    }
    ///
    ///Select Option Order Status
    selectOrderStatus: any = [
        {statusName: "Chưa duyệt"},
        {statusName: "Đã duyệt"},
        {statusName: "Đang giao"},
    ];
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.searchOrder();
    }
    //Search
    searchOrder()
    {
    this.http.get<any>('https://localhost:44394/api/Order/searchOrder/'
            + this.size + ',' + this.page + '?keyWord=' + this.keyWord).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.orders = res;
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
    //Các hàm liên quan đến phân trang
  goNext() {
    if (this.orders.page < this.orders.totalPages) {
      this.page = this.page + 1;
      this.searchOrder();
    }
    else {
      alert("Bạn đang ở trang cuối !!!")
    }
  }
  goPrevious() {
    if (this.orders.page > 1) {
      this.page = this.page - 1;
      this.searchOrder();
    }
    else {
      alert("Bạn đang ở trang đầu !!!")
    }
  }
    //Options Handle
}