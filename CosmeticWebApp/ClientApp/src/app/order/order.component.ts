import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  order: any = {
    orderId: 0,
    name: "",
    createdDate: "",
    phoneNumbOfOrder: "",
    address: "",
    ward: "",
    district: "",
    city: "",
    orderStatus: "",
    note: "",
    cusId: "",
    empId: ""
  }
  ///
  ///Select Option Order Status
  selectOrderStatus: any = [
    { statusName: "Chưa duyệt" },
    { statusName: "Đã duyệt" },
    { statusName: "Đang giao" },
    { statusName: "Đã hủy" }
  ];

  tokenSession: String = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.searchOrder();
    this.getTokenSession();
  }
  //Search
  searchOrder() {
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

  //Update
  updateOrder(index, status) {
     //Tooken
     var bearerTooken = this.tokenSession;
     //Chuyển sang header
     var headers_object = new HttpHeaders().set("Authorization", "Bearer " + bearerTooken);
     //Chọn option
     const httpOptions = {
         headers: headers_object
     };
    this.order = this.orders.data[index];
    this.order.orderStatus = status;
    if (status == "Đã duyệt") //Duyệt đơn
    {
      this.http.put<any>('https://localhost:44394/api/Order/updateOrderPut/' + this.order.orderId, this.order, httpOptions).subscribe(
        result => {
          var res: any = result;
          //Thu được dữ liệu
          if (res != null) {
            alert(status + " thành công đơn hàng.");
            this.searchOrder(); //Quay về trang đầu
          }
          //Không thu được dữ liệu
          else {
            alert("Lỗi dữ liệu");
          }
        },
        error => {
          var err: any = error;
          if (err.status == "401") {
              alert("Bạn vui lòng xác thực tài khoản.");
          }
          else {
              alert("Server error!!");
          }
        });
    }
    else //Hủy đơn
    {
      var check = confirm("Bạn có chắc chắn muốn hủy đơn hàng này ?"); //Tạo thông báo xác nhận xóa
      if (check == true) {
        this.http.put<any>('https://localhost:44394/api/Order/updateOrderPut/' + this.order.orderId, this.order, httpOptions).subscribe(
          result => {
            var res: any = result;
            //Thu được dữ liệu
            if (res != null) {
              alert(status + " thành công đơn hàng.");
              this.searchOrder(); //Quay về trang đầu
            }
            //Không thu được dữ liệu
            else {
              alert("Lỗi dữ liệu");
            }
          },
          error => {
            var err: any = error;
            if (err.status == "401") {
                alert("Bạn vui lòng xác thực tài khoản.");
            }
            else {
                alert("Server error!!");
            }
          });
      }
    }

  }
  getTokenSession() {
    //get
    this.http.get<any>('https://localhost:44394/api/Personal_Information/getTokenSession')
        .subscribe(
            result => {
                var res: String = result;
                //Thu được dữ liệu
                if (res != null) {
                    this.tokenSession = res
                    console.log(this.tokenSession)
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
  //Modal
  openSpecificInformationModal(index) {
    this.order = this.orders.data[index];
    $('#specificInformationModal').modal('show');
}
  //Options Handle
}