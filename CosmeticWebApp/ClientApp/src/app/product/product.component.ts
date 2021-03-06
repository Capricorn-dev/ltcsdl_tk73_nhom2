import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
declare var $: any;

@Component({
    selector: 'app-product-data',
    templateUrl: './product.component.html'
})
export class ProductComponent {
    //Các biến phân trang
    //Mặc định
    size: number = 5;
    page: number = 1;
    keyWord: String = "";
    //Khởi tạo các đối tượng
    checkLoading: Boolean = false;
    isEdit: Boolean = false; //Kiểm tra thêm hay sửa
    dateDisplay: String;
    products: any = {
        data: [],
        totalRecords: 0,
        page: 0,
        size: this.size,
        totalPages: 0,
    }
    nowDate = new Date();
    //Biến này dùng để show
    //Đã get current month lại phải + 1 mới đúng ??:D??
    product: any = {
        productId: "",
        name: "",
        price: "",
        brandId: "1",
        categoryId: "1",
        createdDate: this.nowDate.toJSON(), //Biến này dùng để post
        unit: "",
        unitsInStock: 0,
        discount: 0,
        description: "",
        picture: "",
        note: ""
    };
    //Select
    selectCategory: any = [];
    selectBrand: any = [];

    tokenSession: String = "";
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.searchProducts();
        this.getTokenSession();
    }
    //Các hàm liên qua đến category
    //Tìm
    checkProductsStatus: boolean = true; //Check gửi giá trị chưa
    searchProducts() {
        //Các value truyền vào phải giống tên với các tham số phía back-end
        //get
        this.http.get<any>('https://localhost:44394/api/Product/searchProduct/'
            + this.size + ',' + this.page + '?keyWord=' + this.keyWord).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        // this.products = res;
                        // if (this.checkProductsStatus == true) {
                        //     this.setValuesOfCategorySelect();
                        //     this.setValuesOfBrandSelect();
                        //     this.checkProductsStatus = false; //Nếu đã gửi thì không gửi nữa
                        // }
                        // this.checkLoading = true;
                        //Kiểm tra trang có tồn tại sau khi đã loading
                        if (this.checkLoading == true && (this.page > res.totalPages || this.page < 1)) {
                            //Ưu tiên từ số trang rồi tới số cột
                            if (res.totalRecords > 0) //Khi có dữ liêu nhưng không nằm ở trang cần tìm 
                            {

                                alert("Không có trang này !!");
                            }
                            else //Khi từ khóa không tìm ra được dữ liệu
                            {
                                this.products = res;
                            }

                        }

                        else {
                            this.products = res;
                        }

                        if (this.checkProductsStatus == true) {
                            this.setValuesOfCategorySelect();
                            this.setValuesOfBrandSelect();
                            this.checkProductsStatus = false; //Nếu đã gửi thì không gửi nữa
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
    createProduct() {
        //Tooken
        var bearerTooken = this.tokenSession;
        //Chuyển sang header
        var headers_object = new HttpHeaders().set("Authorization", "Bearer " + bearerTooken);
        //Chọn option
        const httpOptions = {
            headers: headers_object
        };
        //Do khi input vào là string nên phải chuyển qua int
        this.product.unitsInStock = parseInt(this.product.unitsInStock, 10);
        this.product.discount = parseInt(this.product.discount, 10);
        //post
        this.http.post('https://localhost:44394/api/Product/createProduct', this.product, httpOptions).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                    this.products = res;
                    alert("Đã thêm sản phẩm mới !!");
                    this.toggleCreateUpdateModal();
                    this.searchProducts(); //Quay về trang 1
                }
                //Không thu được dữ liệu
                else {
                    alert(res.message);
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
    //Sửa
    updateProduct() {
        //Tooken
        var bearerTooken = this.tokenSession;
        //Chuyển sang header
        var headers_object = new HttpHeaders().set("Authorization", "Bearer " + bearerTooken);
        //Chọn option
        const httpOptions = {
            headers: headers_object
        };
        //Do khi input vào là string nên phải chuyển qua int
        this.product.unitsInStock = parseInt(this.product.unitsInStock, 10);
        this.product.discount = parseInt(this.product.discount, 10);
        //post
        this.http.put('https://localhost:44394/api/Product/updateProductPut/'
            + this.product.productId, this.product, httpOptions).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.products = res;
                        alert("Đã sửa sản phẩm hiện tại !!");
                        this.searchProducts(); //Quay về trang 1
                    }
                    //Không thu được dữ liệu
                    else {
                        alert(res.message);
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
    //Xóa
    id: String = "";
    deleteProduct(productId) {
        //Tooken
        var bearerTooken = this.tokenSession;
        //Chuyển sang header
        var headers_object = new HttpHeaders().set("Authorization", "Bearer " + bearerTooken);
        //Chọn option
        const httpOptions = {
            headers: headers_object
        };
        this.id = productId
        var check = confirm("Bạn có chắc chắn xóa sản phẩm này này ?"); //Tạo thông báo xác nhận xóa
        if (check == true) {
            //post
            this.http.delete('https://localhost:44394/api/Product/deleteProduct/' + this.id, httpOptions).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.products = res;
                        alert("Đã xóa sản phẩm hiện tại !!");
                        this.searchProducts(); //Quay về trang 1
                    }
                    //Không thu được dữ liệu
                    else {
                        alert(res.message);
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
    //Xem cụ thế
    specificInformation(index) {
        this.product = this.products.data[index];
        this.openSpecificInformationModal();
    }
    //Các hàm liên quan đến phân trang
    goNext() {
        if (this.products.page < this.products.totalPages) {
            this.page = parseInt("" + this.page) + 1; //Sau khi input thì chuyển string -> int
            this.searchProducts();
        }
        else {
            alert("Bạn đang ở trang cuối !!!")
        }
    }
    goPrevious() {
        if (this.products.page > 1) {
            this.page = parseInt("" + this.page) - 1; //Sau khi input thì chuyển string -> int
            this.searchProducts();
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
            this.product = this.products.data[index];
        }
        else {
            //thêm mới
            this.product = {
                productId: "",
                name: "",
                brandId: "",
                categoryId: "",
                createdDate: this.nowDate.toJSON(), //Biến này dùng để post
                unit: "",
                unitsInStock: 0,
                discount: 0,
                description: "",
                picture: "",
                note: ""
            }
        }
    }
    parseJsonToDate() {
        var json = "\"" + this.product.createdDate + "\"";
        var dateStr = JSON.parse(json);
        var date = new Date(dateStr);
        this.dateDisplay = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();
    }
    allSize: Number = 1000;
    allPage: Number = 1;
    //Lấy hết dữ liệu của category
    setValuesOfCategorySelect() {
        //get
        this.http.get<any>('https://localhost:44394/api/Category/searchCategory/'
            + this.allSize + ',' + this.allPage).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.selectCategory = res.data;
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
    //Lấy hết dữ liệu của brand
    setValuesOfBrandSelect() {
        var value = {
            page: 1,
            size: this.products.totalRecords, //Tổng số dữ liệu
            keyword: ""
        };
        //get
        this.http.get<any>('https://localhost:44394/api/Brand/searchBrand/'
            + this.allSize + ',' + this.allPage + '?keyWord=').subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.selectBrand = res.data;
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
