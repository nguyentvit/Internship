Ngày 3/7/2024:
Video 5:
Những thêm các cách xử lý lỗi
- Sử dụng OneOf
- Sử dụng FluentResult
- Sử dụng ErrorOr (nên dùng cái này )
Khi triển khai xử lý lỗi bằng ErrorOr chúng ta khởi tạo các lỗi xuất hiện trong Domain với kiểu dữ liệu là Error của ErrorOr
Sau đó khi xử lý logic tại application, khi phát hiện lỗi sẽ return lại 1 error và controller sẽ nhận biết được để trả về client 1 kq thích hợp

Khởi tạo 1 ApiController kế thừa ControllerBase sau đó overload lại Problem với tham số truyền vào là 1 list errors

Video 6:
- CQRS và MediatR
+ CQRS là một mẫu thiết kế chia cơ sở dữ liệu ra thành 2 db, 1 db dùng để đọc và 1 db dùng để viết và sử dụng 1 principle để cập nhật dữ liệu giữa 2 db 
+ MediatR là một công cụ giúp để triển khai mẫu thiết kế cqrs 
=> MediatR được chia thành 2 phần: request và handlerequest
Khi controller nhận được một yêu cầu http, thì sẽ tạo ra 1 request sau đó chuyển tới handlerequest thích hợp


Video 7:
Object Mapping sử dụng Mapster, có 2 trường hợp
- TH1: Các trường của cả 2 obj đều giống nhau thì có thể sử dụng trực tiếp phương thức Map
- TH2: Có sự khác sau giữa các trường của 2 obj thì có thể tạo 1 class implement lại IRegister để override lại Register mô tả sự khác nhau đó

Video 8:
