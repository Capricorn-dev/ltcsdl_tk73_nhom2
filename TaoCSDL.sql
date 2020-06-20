	-- THÊM DỮ LIỆU VÀO BẢNG LOẠI TÀI KHOẢN (AccountType)
INSERT INTO AccountType (
	AccountTypeID,
	Name,
	Note
)
VALUES 
	(
		N'ADMIN',
		N'Người quản trị',
		N'Quyền truy cập cao nhất'
	),
	(
		N'EMP',
		N'Nhân viên',
		N'Quản lý website'
	),
	(
		N'CUS',
		N'khách hàng',
		N'Sử dụng website'
	);

	-- THÊM DỮ LIỆU VÀO BẢNG THƯƠNG HIỆU(Brand)
INSERT INTO Brand (
	BrandId,
	Name,
	PhoneNumber,
	Email,
	Description,
	StartedDate,
	Note
)
VALUES 
	(
		N'AD',
		N'A-DERMA',
		N'1900636900',
		N'example@mail.com',
		N'Mỹ phẩm',
		'2010-01-01',
		N'Thương hiệu'
	),
	(
		N'Acnes',
		N'Acnes',
		N'1900636900',
		N'example@mail.com',
		N'Sản phẩm trị mụn',
		'2012-02-02',
		N'Thương hiệu'
	),
	(
		N'BOM',
		N'B.O.M',
		N'1900636900',
		N'example@mail.com',
		N'Mỹ phẩm',
		'2013-03-03',
		N'Thương hiệu'
	), 
	(
		N'BAF',
		N'BALANCE ACTIVE FORMULA',
		N'1900636900',
		N'example@mail.com',
		N'Mỹ phẩm',
		'2014-04-04',
		N'Thương hiệu'
	), 
	(
		N'CETAPHIL',
		N'CETAPHIL',
		N'1900636900',
		N'example@mail.com',
		N'Mỹ phẩm',
		'2015-05-05',
		N'Thương hiệu'
	),
	(
		N'CARENEL',
		N'CARENEL',
		N'1900636900',
		N'example@mail.com',
		N'Son',
		'2016-06-06',
		N'Thương hiệu'
	);

	-- THÊM DỮ LIỆU VÀO BẢNG DANH MỤC(Category)
INSERT INTO Category (
	CategoryId,
	Name,
	Description,
	CreatedDate,
	Note
)
VALUES 
	(
		N'S',
		N'Son',
		N'Son',
		'2012-02-02',
		N'Danh mục'
	), 
	(
		N'CST',
		N'Chăm sóc tóc',
		N'Gel',
		'2012-02-02',
		N'Danh mục'
	), 
	(
		N'CSDM',
		N'Chăm Sóc Da Mặt',
		N'Gel',
		'2012-02-02',
		N'Danh mục'
	), 
	(
		N'CSCT',
		N'Chăm Sóc Cơ Thể',
		N'Gel',
		'2012-02-02',
		N'Danh mục'
	);

	-- THÊM DỮ LIỆU VÀO BẢNG THÔNG TIN CÁ NHÂN(Personal_Information)
INSERT INTO [Personal_Information] (
	Account,
	Pass,
	LastName,
	FirstName,
	DateOfBirth,
	Gender,
	Address,
	PhoneNumber,
	Email,
	AccountType,
	CreatedDate,
	AccountStatus,
	Note
)
VALUES
	(
		N'KH1',
		N'1',
		N'KHACH',
		N'HANG 1',
		'2000-01-01',
		N'Nam',
		N'1 NK',
		N'0917530879',
		N'example1@mail.com',
		N'CUS',
		'2011-01-01',
		N'Hoạt động',
		N'Khách hàng'
	),
	(
		N'KH2',
		N'1',
		N'KHACH',
		N'HANG 2',
		'1998-01-01',
		N'Nữ',
		N'1 NK',
		N'0917530890',
		N'example2@mail.com',
		N'CUS',
		'2011-01-02',
		N'Hoạt động',
		N'Khách hàng'
	),
	(
		N'EMP1',
		N'1',
		N'NHAN',
		N'VIEN 1',
		'1999-01-01',
		N'Nữ',
		N'3 NK',
		N'0917530811',
		N'example3@mail.com',
		N'EMP',
		'2011-01-02',
		N'Hoạt động',
		N'Nhân viên'
	),
	(
		N'EMP2',
		N'1',
		N'NHAN',
		N'VIEN 2',
		'1999-02-02',
		N'Nam',
		N'3 NK',
		N'0917533311',
		N'example4@mail.com',
		N'EMP',
		'2011-01-12',
		N'Hoạt động',
		N'Nhân viên'
	),
	(
		N'ADMIN',
		N'1',
		N'AD',
		N'MIN',
		'1996-01-01',
		N'Nam',
		N'371 NK',
		N'0917531311',
		N'example3@mail.com',
		N'ADMIN',
		'2011-01-02',
		N'Hoạt động',
		N'Quản trị viên'
	);

	-- THÊM DỮ LIỆU VÀO BẢNG ĐƠN HÀNG(Orders)
INSERT INTO Orders (
	Name,
	CreatedDate,
	PhoneNumbOfOrder,
	Address,
	Ward,
	District,
	City,
	OrderStatus,
	Note,
	CusId,
	EmpId
)
VALUES 
	(
		N'DH1',
		'2019-01-01',
		'0917530811',
		N'1 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đang giao',
		N'Vui lòng gọi vào số này 0917530811',
		NULL,
		NULL
	),
	(
		N'DH2',
		'2019-03-02',
		'0917530123',
		N'132 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đang giao',
		N'Vui lòng gọi vào số này 0917530123',
		NULL,
		NULL
	),
	(
		N'DH3',
		'2019-04-03',
		'0917123459',
		N'321 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đang giao',
		N'Vui lòng gọi vào số này 0917123459',
		NULL,
		NULL
	),
	(
		N'DH4',
		'2019-04-05',
		'0917123450',
		N'32/1 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đang giao',
		N'Vui lòng gọi vào số này 0917123450',
		NULL,
		NULL
	),
	(
		N'DH5',
		'2019-04-06',
		'0917123300',
		N'32/1 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đang giao',
		N'Vui lòng gọi vào số này 0917123300',
		NULL,
		NULL
	),
	(
		N'DH6',
		'2019-12-12',
		'0917123301',
		N'32/12 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Chưa duyệt',
		N'Vui lòng gọi vào số này 0917123301',
		NULL,
		NULL
	),
	(
		N'DH7',
		'2019-12-12',
		'0917133301',
		N'31/2 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Chưa duyệt',
		N'Vui lòng gọi vào số này 0917133301',
		NULL,
		NULL
	),
	(
		N'DH8',
		'2019-12-12',
		'0912133301',
		N'31/23 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Chưa duyệt',
		N'Vui lòng gọi vào số này 0912133301',
		NULL,
		NULL
	),
	(
		N'DH9',
		'2019-01-12',
		'0932133301',
		N'11/23 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Chưa duyệt',
		N'Vui lòng gọi vào số này 0932133301',
		NULL,
		NULL
	),
	(
		N'DH10',
		'2019-01-10',
		'0923133301',
		N'23/23 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Chưa duyệt',
		N'Vui lòng gọi vào số này 0923133301',
		NULL,
		NULL
	),
	(
		N'DH11',
		'2019-03-10',
		'0923103301',
		N'231/23 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đã duyệt',
		N'Vui lòng gọi vào số này 0923103301',
		NULL,
		NULL
	),
	(
		N'DH12',
		'2019-03-13',
		'0923103001',
		N'123/123 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đã duyệt',
		N'Vui lòng gọi vào số này 0923103001',
		NULL,
		NULL
	),
	(
		N'DH13',
		'2019-12-13',
		'0923103002',
		N'123/12 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đã duyệt',
		N'Vui lòng gọi vào số này 0923103002',
		NULL,
		NULL
	),
	(
		N'DH14',
		'2019-12-14',
		'0923103003',
		N'3/12 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đã duyệt',
		N'Vui lòng gọi vào số này 0923103003',
		NULL,
		NULL
	),
	(
		N'DH15',
		'2019-05-15',
		'0923103005',
		N'3/123 Hồ Hảo Hớn',
		N'13',
		N'3',
		N'TP.HCM',
		N'Đã duyệt',
		N'Vui lòng gọi vào số này 0923103005',
		NULL,
		NULL
	);

	-- THÊM DỮ LIỆU VÀO BẢNG SẢN PHẨM(Product)
INSERT INTO Product (
	ProductId,
	Name,
	Price,
	Brand,
	Category,
	CreatedDate,
	Unit,
	UnitsInStock,
	Discount,
	Description,
	Picture,
	Note
)
VALUES 
		--  THƯƠNG HIỆU A-DERMA  --
	(
		N'GRM_TGDN',
		N'Gel Rửa Mặt,Tắm Gội Dịu Nhẹ',
		N'307000',
		N'AD',
		N'CSDM',
		'2010-10-10',
		N'200ml',
		20,
		0.05,
		N'Phù hợp cho cả trẻ em và người lớn',
		N'https://bizweb.dktcdn.net/thumb/grande/100/194/749/products/467a10f838cbdb9582da.jpg?v=1589599695553',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KD_HTNLS',
		N'Kem Hỗ Trợ Nhanh Liền Sẹo',
		N'379000 ',
		N'AD',
		N'CSDM',
		'2010-11-11',
		N'40ml',
		15,
		0.15,
		N'Tác dụng có thể khác nhau tuỳ cơ địa của người dùng',
		N'https://cf.shopee.vn/file/d96313a5079e6875273585d0cd124319',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KDADKT',
		N'Kem Dưỡng Ẩm Da Kích Ứng',
		N'329000',
		N'AD',
		N'CSCT',
		'2010-12-13',
		N'50ml',
		15,
		0.15,
		N'Tác dụng có thể khác nhau tuỳ cơ địa của người dùng',
		N'https://vn-test-11.slatic.net/p/b829106ca7ff6c905fd83cf0d9150378.png_720x720q80.jpg_.webp',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KDLDPHD',
		N'Kem Dưỡng Làm Dịu Phục Hồi Da',
		N'329000',
		N'AD',
		N'CSCT',
		'2015-12-13',
		N'50ml',
		25,
		0.05,
		N'Tác dụng có thể khác nhau tuỳ cơ địa của người dùng',
		N'https://media.hasaki.vn/wysiwyg/quynhtrang/Trang/kem-duong-lam-diu-ho-tro-phuc-hoi-da-a-derma-dermalibour-repairing-cream-50ml.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'DGLSDNC_1',
		N'Dầu Giúp Làm Sạch Da Nhạy Cảm',
		N'382000',
		N'AD',
		N'CSCT',
		'2012-12-11',
		N'200ml',
		20,
		0.1,
		N'Tác dụng có thể khác nhau tuỳ cơ địa của người dùng',
		N'https://media.hasaki.vn/wysiwyg/quynhtrang/Trang/dau-giup-lam-sach-danh-cho-da-nhay-cam-va-kich-ung-a-derma-200ml.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),

	--  THƯƠNG HIỆU Acnes  --
	(
		N'DGLSDNC',
		N'Dầu Giúp Làm Sạch Da Nhạy Cảm',
		N'57000',
		N'Acnes',
		N'CSDM',
		'2010-09-11',
		N'24 miếng',
		20,
		0.05,
		N'Tác dụng có thể khác nhau tuỳ cơ địa của người dùng',
		N'https://cf.shopee.vn/file/a92dfaf5c8849bc1b4ddeb1c168b415b',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'CACSD',
		N'Combo Acnes Chăm Sóc Da 3 Món',
		N'129000',
		N'Acnes',
		N'CSDM',
		'2010-09-20',
		N'3 MÓN',
		10,
		0.03,
		N'Creamy Wash 100g + Sealing Jell 18g + Smoothing Lotion 90ml',
		N'https://media.hasaki.vn/catalog/product/g/o/google-shopping-combo-acnes-kem-rua-mat-ngua-mun-100g-gel-ngua-mun-18g-dung-dich-lam-diu-da-90ml.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'STGNNM',
		N'Sữa Tắm Giúp Ngăn Ngừa Mụn',
		N'78000',
		N'Acnes',
		N'CSCT',
		'2015-09-20',
		N'180g',
		12,
		0.05,
		N'Giúp làm sạch mụn và hỗ trợ kiểm soát bã nhờn',
		N'https://media.hasaki.vn/wysiwyg/quynhtrang/Trang/sua-tam-giup-ngan-ngua-mun-acnes-180g.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'GSTMS',
		N'Gel Sáng Thâm Mờ Sẹo',
		N'64000',
		N'Acnes',
		N'CSDM',
		'2012-10-20',
		N'180g',
		12,
		0.05,
		N'Giúp làm sạch mụn và hỗ trợ kiểm soát bã nhờn',
		N'https://media.hasaki.vn/wysiwyg/quynhtrang/Trang/sua-tam-giup-ngan-ngua-mun-acnes-180g.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'DDGGST',
		N'Dung Dịch Giúp Giảm Sẹo Thâm',
		N'333000',
		N'Acnes',
		N'CSCT',
		'2013-09-20',
		N'15ml',
		12,
		0.05,
		N'Giúp làm mờ vết thâm, hỗ trợ làm sáng vùng da xỉn màu',
		N'https://media.hasaki.vn/catalog/product/d/u/dung-dich-acnes-giup-lam-giam-seo-tham-15ml-002.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),

	--  THƯƠNG HIỆU BALANCE ACTIVE FORMULA  --
	(
		N'TCVC',
		N'Tinh Chất Vitamin C',
		N'139000',
		N'BAF',
		N'CSDM',
		'2010-01-20',
		N'30ml',
		11,
		0.1,
		N'Dưỡng sáng da, cải thiện tông màu da.',
		N'https://media.hasaki.vn/catalog/product/d/u/dung-dich-acnes-giup-lam-giam-seo-tham-15ml-002.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'TCVNLH',
		N'Tinh Chất Vàng Ngừa Lão Hóa',
		N'139000',
		N'BAF',
		N'CSDM',
		'2010-03-20',
		N'30ml',
		20,
		0.15,
		N'Cung cấp độ ẩm, dưỡng da căng mượt mịn màng hơn',
		N'https://cf.shopee.vn/file/9448dafd667a7360ab089b3170f4bbd1',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'TCHA',
		N'Tinh Chất Hyaluronic Acid',
		N'139000',
		N'BAF',
		N'CSDM',
		'2010-02-20',
		N'30ml',
		30,
		0.1,
		N'Cấp Nước, Dưỡng Ẩm Da',
		N'https://media.hasaki.vn/wysiwyg/HaNguyen/serum-cap-nuoc-duong-am-balance-active-formula-30ml-2.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KDMNR',
		N'Kem Dưỡng Mắt Nọc Rắn',
		N'90000',
		N'BAF',
		N'CSDM',
		'2010-04-22',
		N'15ml',
		15,
		0.15,
		N'Làm Giảm Quầng Thâm, Bọng Mắt',
		N'https://media.hasaki.vn/wysiwyg/HaNguyen/kem-duong-mat-noc-ran-balance-active-formula-lam-giam-quang-tham-bong-mat-15ml-1.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KDMMR',
		N'Kem Dưỡng Mắt Máu Rồng',
		N'90000',
		N'BAF',
		N'CSDM',
		'2010-04-22',
		N'15ml',
		15,
		0.15,
		N'Hỗ Trợ Nâng Cơ, Săn Chắc Da',
		N'https://media.hasaki.vn/wysiwyg/HaNguyen/kem-duong-mat-mau-rong-balance-active-formula-nang-co-san-chac-da-mat-15ml-1.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	--  THƯƠNG HIỆU B.O.M  --
	(
		N'NTTB',
		N'Nước Tẩy Trang B.O.M',
		N'209000',
		N'BOM',
		N'CSDM',
		'2015-10-22',
		N'500ml',
		20,
		0.05,
		N'Từ 8 Loại Trà',
		N'https://media.hasaki.vn/wysiwyg/UYEN/nuoc-tay-trang-bom-8-loai-tra-500ml_11__2.png',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SDMDTN',
		N'Son Dưỡng Màu Đỏ Tự Nhiên',
		N'230000',
		N'BOM',
		N'S',
		'2016-12-10',
		N'4.5g',
		24,
		0.01,
		N'Dewy Lip Balm',
		N'https://media.hasaki.vn//catalog/product/s/o/son-duong-co-mau-b-o-m-4-5g_price_230x288_51c7d8_img_800x800_eb97c5_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KCN',
		N'Kem Chống Nắng B.O.M SPF50+',
		N'392000',
		N'BOM',
		N'CSDM',
		'2016-12-01',
		N'50ml',
		29,
		0.1,
		N'Green UV Sun Off',
		N'https://media.hasaki.vn/catalog/product/k/e/kem-chong-nang-bom-spf50-pa.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KCND',
		N'Kem Nâng Tông Da B.O.M',
		N'374000',
		N'BOM',
		N'CSDM',
		'2015-12-03',
		N'40ml',
		30,
		0.15,
		N'Light On Tone-Up Cream',
		N'https://media.hasaki.vn/wysiwyg/UYEN/kem-nang-tong-da-bom_12_.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SRM',
		N'Sữa Rửa Mặt B.O.M',
		N'270000',
		N'BOM',
		N'CSDM',
		'2014-11-03',
		N'150ml',
		20,
		0.1,
		N'Từ 8 Loại Trà ',
		N'https://media.hasaki.vn/catalog/product/s/u/sua-rua-mat-b-o-m-tu-8-loai-tra-150ml.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	--  THƯƠNG HIỆU CARENEL --
	(
		N'SRM2',
		N'Son Kem Lì CARENEL 02',
		N'155000',
		N'CARENEL',
		N'S',
		'2013-12-11',
		N'4.5g',
		25,
		0.15,
		N'Ruby Airfit Velvet Tint',
		N'https://media.hasaki.vn/catalog/product/s/o/son-kem-li-carenel-02-orange-fire-4.5g_img_358x358_843626_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SRM1',
		N'Son Kem Lì CARENEL 01',
		N'155000',
		N'CARENEL',
		N'S',
		'2013-12-11',
		N'4.5g',
		20,
		0.25,
		N'Ruby Airfit Velvet Tint',
		N'https://media.hasaki.vn/catalog/product/s/o/son-kem-li-carenel-01-orange-red-4.5g-2_img_358x358_843626_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SRM4P',
		N'Son Kem Lì CARENEL 04 Plum',
		N'139000',
		N'CARENEL',
		N'S',
		'2013-10-11',
		N'4.5g',
		24,
		0.2,
		N'Ruby Airfit Velvet Tint',
		N'https://media.hasaki.vn/catalog/product/s/o/son-kem-li-carenel-04-plum-burgundy-4.5g_img_358x358_843626_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SRM5M',
		N'Son Kem Lì CARENEL 05 Mapel',
		N'155000',
		N'CARENEL',
		N'S',
		'2010-10-10',
		N'4.5g',
		24,
		0.2,
		N'Ruby Airfit Velvet Tint',
		N'https://media.hasaki.vn/catalog/product/s/o/son-kem-li-carenel-05-mapel-choco-4-5g_img_358x358_843626_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'MNNMC',
		N'Mặt Nạ Ngủ Môi CARE:NEL',
		N'190000',
		N'CARENEL',
		N'CSDM',
		'2010-11-10',
		N'23g',
		23,
		0.1,
		N'Berry Lip Night Mask',
		N'https://media.hasaki.vn/wysiwyg/AnhThu/Mat-Na-Ngu-Moi-CARENEL-Lip-Night-Mask3.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	--  THƯƠNG HIỆU CETAPHIL --
	(
		N'SRMCDN',
		N'Sữa Rửa Mặt Cetaphil Dịu Nhẹ',
		N'243000',
		N'CETAPHIL',
		N'CSDM',
		'2010-12-12',
		N'500ml',
		10,
		0.1,
		N'Gentle Skin Cleanser',
		N'https://images.depxinh.net/products/item.1_2018/11/detail/cetaphil-500ml-1-dep-xinh.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SRMCDN125',
		N'Sữa Rửa Mặt Cetaphil Dịu Nhẹ',
		N'99000',
		N'CETAPHIL',
		N'CSDM',
		'2012-12-12',
		N'125ml',
		10,
		0.1,
		N'Gentle Skin Cleanser',
		N'https://media.hasaki.vn/catalog/product/s/u/sua-rua-mat-cetaphil-diu-nhe-125ml-01_1.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'SDADTT',
		N'Sữa Dưỡng Ẩm Da Toàn Thân',
		N'219000 ',
		N'CETAPHIL',
		N'CSDM',
		'2012-12-12',
		N'200ml',
		12,
		0.12,
		N'Moisturizing Lotion Body & Face',
		N'https://media.hasaki.vn//catalog/product/s/u/sua-duong-am-cetaphil-cho-da-mat-va-toan-than-200ml-01_price_219x300_56963d_img_800x800_eb97c5_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KĐAMCM',
		N'Kem Dưỡng Ẩm Mềm Da Cho Mặt',
		N'174000',
		N'CETAPHIL',
		N'CSDM',
		'2010-10-21',
		N'50g',
		15,
		0.01,
		N'Face & Body Moisturizing Cream',
		N'https://media.hasaki.vn/wysiwyg/Dai/kem-duong-am-lam-mem-da-cetaphil-moisturizing-cream-50g.jpeg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	),
	(
		N'KCNCDM',
		N'Kem Chống Nắng Cho Da Mặt',
		N'547000',
		N'CETAPHIL',
		N'CSDM',
		'2010-10-21',
		N'50ml',
		30,
		0.25,
		N'UVA/UVB Defense SPF50 Face & Body',
		N'https://media.hasaki.vn/catalog/product/k/e/kem-chong-nang-cetaphil-cho-da-mat-toan-than-spf50-50ml-01_img_358x358_843626_fit_center.jpg',
		N'Bảo quản nơi khô ráo, thoáng mát'
	);