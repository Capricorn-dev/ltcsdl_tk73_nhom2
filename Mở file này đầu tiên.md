--Cài đặt môi trường
Cài SQL Server 2014 trở lên
Cài Visual Studio phiên bản 2017 trở lên
Cài .Net core 3.1
Cài Visual Code
Cài NodeJs
Cài Angular trong Visual Code vào project
--Chạy ứng dụng
--Visual Studio
Bước 1: Mở project trong Visual Studio. Sau đó set default project CosmeticWebApp.DAL
Bước 2: Tools -> Nuget Package Manager -> Package Manager Console. Set default project CosmeticWebApp.DAL trong Package Manage Console
Bước 3: Chỉnh đường dẫn SQL đúng với trong máy trong OnConfiguring. Có 2 options 1 là Windows Authencation và SQL Server Authencation. Tạo data base với tên CosmeticAppDB
Bước 4: Chạy câu lệnh add-migration CosmeticAppDBEng trong Package Manager Console. Sau đó chạy update-database –verbose.
Bước 5: Mở file TaoCSDL.sql ở project trong SQL Server 2014, chọn đúng database CosmeticAppDB rồi excute để khởi tạo dữ liệu
--Visual Code
Bước 1: Chọn đường dẫn ..\LTCSDL\CosmeticWebApp, sau đó select folder ClientApp
Bước 2: Terminal -> New terminal. Gõ vào ng s -o để khởi động localhost:4200
--Lưu ý: Khi chạy project nhớ set default project CosmeticWebApp 