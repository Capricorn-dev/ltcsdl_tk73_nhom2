import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Variable } from '@angular/compiler/src/render3/r3_ast';
declare var $: any;

@Component({
    selector: 'app-brand-data',
    templateUrl: './brand.component.html'
})
export class BrandComponent {
    //Các biến phân trang
    //Mặc định
    size: number = 5;
    page: number = 1;
    keyWord: String = "";
    //
    checkLoading: boolean = false;
    modalCreate: Boolean;
    isEdit: Boolean = false; //Kiểm tra thêm hay sửa
    dateDisplay: String;
    brands: any = {
        data: [],
        totalRecords: 0,
        page: 0,
        size: this.size,
        totalPages: 0,
    }
    nowDate = new Date();
    //Biến này dùng để show
    //Đã get current month lại phải + 1 mới đúng ??:D??
    brand: any = {
        brandId: "",
        name: "",
        description: "",
        email: "",
        phoneNumber: "",
        startedDate: this.nowDate.toJSON(), //Biến này dùng để post
        note: ""
    };
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.searchBrands();
    }
    //Các hàm liên qua đến category
    //Tìm
    searchBrands() {

        //Các value truyền vào phải giống tên với các tham số phía back-end
        //get
        this.http.get<any>('https://localhost:44394/api/Brand/searchBrand/' +
            this.size + ',' + this.page + '?keyWord=' + this.keyWord).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        //Kiểm tra trang có tồn tại sau khi đã loading
                        if (this.checkLoading == true && (this.page > res.totalPages || this.page < 1)) {
                            //Ưu tiên từ số trang rồi tới số cột
                            if (res.totalRecords > 0) //Khi có dữ liêu nhưng không nằm ở trang cần tìm 
                            {

                                alert("Không có trang này !!");
                            }
                            else //Khi từ khóa không tìm ra được dữ liệu
                            {
                                this.brands = res;
                            }

                        }

                        else {
                            this.brands = res;
                        }
                        this.checkLoading = true;
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
    //Tạo
    createBrand() {
        //post
        this.http.post('https://localhost:44394/api/Brand/createBrand', this.brand).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                    this.brands = res;
                    alert("Đã tạo danh mục mới !!");
                    this.toggleCreateUpdateModal();
                    this.searchBrands(); //Quay về trang 1
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
    updateBrand() {
        //put
        this.http.put('https://localhost:44394/api/Brand/updateBrandPut/'
            + this.brand.brandId, this.brand).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.brands = res;
                        alert("Đã sửa danh mục hiện tại !!");
                        this.searchBrands(); //Quay về trang 1
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
    deleteCategory(brandId) {
        this.id = brandId;
        var check = confirm("Bạn có chắc chắn xóa danh mục này ?"); //Tạo thông báo xác nhận xóa
        if (check == true) {
            //post
            this.http.delete('https://localhost:44394/api/Brand/deleteBrand' + this.id).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.brands = res;
                        alert("Đã xóa danh mục hiện tại !!");
                        this.searchBrands(); //Quay về trang 1
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
        this.brand = this.brands.data[index];
        this.openSpecificInformationModal();
    }
    //Các hàm liên quan đến phân trang
    goNext() {
        if (this.brands.page < this.brands.totalPages) {
            this.page = this.page + 1;
            this.searchBrands();
        }
        else {
            alert("Bạn đang ở trang cuối !!!")
        }
    }
    goPrevious() {
        if (this.brands.page > 1) {
            this.page = this.page - 1;
            this.searchBrands();
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
        this.modalCreate = true;
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
            this.brand = this.brands.data[index];
        }
        else {
            //thêm mới
            this.brand = {
                brandId: "",
                name: "",
                description: "",
                email: "",
                phoneNumber: "",
                startedDate: this.nowDate.toJSON(), //Biến này dùng để post
                note: ""
            }
        }
    }
    parseJsonToDate() {
        var json = "\"" + this.brand.startedDate + "\"";
        var dateStr = JSON.parse(json);
        var date = new Date(dateStr);
        this.dateDisplay = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
    }
}
//Progress