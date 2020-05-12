import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DatePipe } from '@angular/common';

declare var $: any;

@Component({
  selector: 'app-category-data',
  templateUrl: './category.component.html',
  providers: [DatePipe],
})

export class CategoryComponent {
  //Các biến phân trang
  //Mặc định
  size: number = 5;
  page: number = 1;
  keyWord: String = "";
  //
  isEdit: Boolean = false; //Kiểm tra thêm hay sửa
  checkLoading = false;
  dateDisplay: String;
  nowDate = new Date();
  private datePipe: DatePipe;
  categories: any = {
    data: [],
    totalRecords: 0,
    page: 0,
    size: this.size,
    totalPages: 0,
  };
  category: any = {
    categoryId: "",
    name: "",
    description: "",
    createdDate: this.nowDate.toJSON(), //Biến này dùng để post
    note: ""
  };

  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.searchCategories();
  }

  //Các hàm liên qua đến category
  //Tìm
  searchCategories() {
    //Các value truyền vào phải giống tên với các tham số phía back-end
    //get
    this.checkLoading = false;
    this.http.get<any>('https://localhost:44394/api/Category/searchCategory/' +
      this.size + ',' + this.page + '?keyWord=' + this.keyWord).subscribe(
        result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res != null) {
            this.categories = res;
            this.checkLoading = true;
          }
          //Không thu được dữ liệu
          else {
            alert(res.message);
          }

          //Sử dụng SingleRsp
          //Thu được dữ liệu
          // if(res.success)
          // {
          //     this.customers = res.data;
          // }
          // //Không thu được dữ liệu
          // else
          // {
          //     alert(res.message);
          // }
        },
        error => {
          alert("Server error!!")
        });
  }
  //Tạo
  createCategory() {
    //post
    this.http.post('https://localhost:44394/api/Category/createCategory', this.category).subscribe(
      result => {
        var res: any = result;
        //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
        //Thu được dữ liệu
        if (res != null) {
          this.categories = res;
          alert("Đã tạo danh mục mới !!");
          this.toggleCreateUpdateModal();
          this.searchCategories(); //Quay về trang 1
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
  //Sửa
  updateCategory() {
    //put
    this.http.put('https://localhost:44394/api/Category/updateCategoryPut/' + this.category.categoryId, this.category).subscribe(
      result => {
        var res: any = result;
        //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
        //Thu được dữ liệu
        if (res != null) {
          this.categories = res;
          alert("Đã sửa danh mục hiện tại !!");
          this.searchCategories(); //Quay về trang 1
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
  id: String = "";
  //Xóa
  deleteCategory(categoryId) {
    this.id = categoryId;
    var check = confirm("Bạn có chắc chắn xóa danh mục này ?"); //Tạo thông báo xác nhận xóa
    if (check == true) {
      //delete
      this.http.delete('https://localhost:44394/api/Category/deleteCategory/' + this.id).subscribe(
        result => {
          var res: any = result;
          //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
          //Thu được dữ liệu
          if (res != null) {
            this.categories = res;
            alert("Đã xóa danh mục hiện tại !!");
            this.searchCategories(); //Quay về trang 1
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
  //Xem cụ thế
  specificInformation(index) {
    this.category = this.categories.data[index];
    this.openSpecificInformationModal();
  }
  //Các hàm liên quan đến phân trang
  goNext() {
    if (this.categories.page < this.categories.totalPages) {
      this.page = this.page + 1;
      this.searchCategories();
    }
    else {
      alert("Bạn đang ở trang cuối !!!")
    }
  }
  goPrevious() {
    if (this.categories.page > 1) {
      this.page = this.page - 1;
      this.searchCategories();
    }
    else {
      alert("Bạn đang ở trang đầu !!!")
    }
  }
  //Các hàm liên quan tới modal
  openCreateUpdateModal(isEdit, index) //Kiểm tra là thêm hay sửa
  {
    this.isEdit = isEdit;
    $('#openCreateUpdateModal').modal('show');
    this.checkEdit(isEdit, index);
    this.parseJsonToDate();
  }
  openSpecificInformationModal() {
    $('#specificInformationModal').modal('show');
  }
  toggleCreateUpdateModal() {
    $('#openCreateUpdateModal').modal('toggle');
  }
  //Các hàm khác
  checkEdit(isEdit, index) {
    if (isEdit) {
      this.category = this.categories.data[index];
    }
    else {
      //thêm mới
      this.category = {
        categoryId: "",
        name: "",
        description: "",
        createdDate: this.nowDate.toJSON(), //Biến này dùng để post
        note: ""
      }
    }
  }
  parseJsonToDate() {
    var json = "\"" + this.category.createdDate + "\"";
    var dateStr = JSON.parse(json);
    var date = new Date(dateStr);
    //Biến này dùng để show
    //Đã get current month lại phải + 1 mới đúng ??:D??
    this.dateDisplay = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
  }
}

