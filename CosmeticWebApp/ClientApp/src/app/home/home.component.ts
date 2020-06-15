import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ShoppingcartComponent } from 'src/app/shoppingcart/shoppingcart.component'
import { Router } from '@angular/router';

declare var $: any;

@Component({
    selector: 'app-home-data',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    //Cart
    cart: any = {
        account: "",
        productId: "",
        amounts: 0,
        note: ""
    }
    //Các biến phân trang
    //Mặc định
    size: number = 12;
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

    //private http: HttpClient; @Inject('BASE_URL') baseUrl: string;
    constructor();
    constructor(private http?: HttpClient, @Inject('BASE_URL') baseUrl?: string,
    private router?: Router) {
        this.searchProducts();
    }
    
    //Các hàm liên qua đến category
    //Tìm
    checkProductsStatus: boolean = true; //Check gửi giá trị chưa
    searchProducts() {
        //Kiểm tra trang có tồn tại sau khi đã loading
        if (this.checkLoading == true && (this.page > this.products.totalPages || this.page < 1)) {
            alert("Không có trang này !!")
        }
        //Các value truyền vào phải giống tên với các tham số phía back-end
        //get
        else {
            this.http.get<any>('https://localhost:44394/api/Product/searchProduct/'
                + this.size + ',' + this.page + '?keyWord=' + this.keyWord).subscribe(
                    result => {
                        var res: any = result;
                        //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                        //Thu được dữ liệu
                        if (res != null) {
                            this.products = res;
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
    }
    //Tạo
    createProduct() {
        //Do khi input vào là string nên phải chuyển qua int
        this.product.unitsInStock = parseInt(this.product.unitsInStock, 10);
        this.product.discount = parseInt(this.product.discount, 10);
        //post
        this.http.post('https://localhost:44394/api/Product/createProduct', this.product).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                    this.products = res;
                    alert("Đã sản phẩm mục mới !!");
                    this.toggleCreateUpdateModal();
                    this.searchProducts(); //Quay về trang 1
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
    updateProduct() {
        //Do khi input vào là string nên phải chuyển qua int
        this.product.unitsInStock = parseInt(this.product.unitsInStock, 10);
        this.product.discount = parseInt(this.product.discount, 10);
        //post
        this.http.put('https://localhost:44394/api/Product/updateProductPut/'
            + this.product.productId, this.product).subscribe(
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
                    alert("Server error!!")
                });
    }
    //Xóa
    id: String = "";
    deleteProduct(productId) {
        this.id = productId
        var check = confirm("Bạn có chắc chắn xóa sản phẩm này này ?"); //Tạo thông báo xác nhận xóa
        if (check == true) {
            //post
            this.http.delete('https://localhost:44394/api/Product/deleteProduct/' + this.id).subscribe(
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
                    alert("Server error!!")
                });
        }
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
    //Thêm vào giỏ hàng
    shoppingCart: ShoppingcartComponent 
    addToCart(productId: String)
    {
        try
        {
            //Nếu chưa đăng nhập thì không thể lấy được account
            this.cart.account = document.getElementById("btnUserName").textContent;
        }
        catch
        {
            this.cart.account = null
        }
        
        if(this.cart.account == null)
        {
            alert("Bạn chưa đăng nhập");
        }
        else
        {
            this.cart.productId = productId;
            this.http.post('https://localhost:44394/api/Cart/createCart',this.cart).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        alert("Thêm vào giỏ hàng thành công")
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
}
