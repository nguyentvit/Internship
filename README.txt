Ngày 2/7/2024:
Video 1:
Kiến thức về Clean architecture: 
Clean architecture bao gồm:
Presentation Layer, Infrastructure Layer, Application Layer, Domain Layer

* Presentation Layer bao gồm 2 thư mục contracts và api
+ api: chứa các end points, controllers, tương tác với client => thư mục api tham chiếu tới các thư mục: infrastructure, application, contracts
+ contracts: chứa DTO

* Infrastructure Layer: dùng để truy cập dữ liệu, hoặc các service bên ngoài, tham chiếu tới các thư mục contracts, application

* Application Layer bao gồm thư mục application 
+ application: chứa các logic nghiệp vụ như services, tham chiếu tới thư mục domain

* Domain Layer bao gồm thư mục domain
+ domain: chứa các mô hình dữ liệu cốt lõi và logic nghiệp vụ cốt lõi như entities, aggregates

* code khởi tạo project dựa theo Clean architecture
dotnet new sln -o BuberDinner
cd .\BuberDinner\
dotnet new webapi -o BuberDinner.Api
dotnet new classlib -o BuberDinner.Contracts
dotnet new classlib -o BuberDinner.Infrastructure
dotnet new classlib -o BuberDinner.Application
dotnet new classlib -o BuberDinner.Domain
dotnet build
dotnet sln add (ls -r **\*.csproj)
dotnet build
dotnet add .\BuberDinner.Api\ reference .\BuberDinner.Contracts\ .\BuberDinner.Application\
dotnet add .\BuberDinner.Infrastructure\ reference .\BuberDinner.Application\
dotnet add .\BuberDinner.Application\ reference .\BuberDinner.Domain\
dotnet add .\BuberDinner.Api\ reference .\BuberDinner.Infrastructure\
code .

* Lưu ý: mỗi thư mục nên có 1 dependency injection để có thể đơn giản hóa việc tham chiếu giữa các layer

Video 2:
Jwt
JWT bao gồm 3 phần: Header, Payload và Signature
* Header chứa thông tin về loại token và thuật toán mã hóa, ở đây sử dụng HmacSha256

* Payload là nơi chứa các claim về người dùng như:
+ issuer: người phát hành token
+ audience: đối tượng
+ expires: thời gian token hết hạn
+ claims: các claims như id người dùng, role của người dùng, ...

* Signature: mã hóa phần Header và Payload dựa trên 1 secret key

Chúng ta sẽ cấu hình JwtSettings trong appsettings như giá trị của Secret, Issuer, Audience, ExpiryMinutes, ...

* chú ý
Sử dụng Configure<JwtSettings> và IOptions<JwtSettings> để tự động tiêm vào JwtSettings khi JwtSettings được gọi


Video 3:
Sử dụng repository pattern for the command side with cqrs
* CQRS là gì?
- CQRS là command query responsibility segregation, nhằm tách biệt các thao tác thay đổi trạng thái của hệ thống (như thêm, thay đổi, xóa) khỏi các thao tác truy vấn
- Command:
+ Chịu trách nhiệm thay đổi trạng thái hệ thống 
+ Các thao tác như tạo, cập nhật, xóa dữ liệu đều được xử lý thông qua command
+ Command không trả về dữ liệu ngoài kết quả thành công hay thất bại
- Query:
+ Chịu trách nhiệm truy vấn và lấy dữ liệu
+ Các thao tác chỉ đọc và không thay đổi trạng thái của hệ thống
+ Trả về dữ liệu cần thiết cho client
* Lợi ích của CQRS?
- Tách biệt trách nhiệm 
- Tối ưu hóa hiệu năng, có thể sử dụng NoSql để truy vấn dữ liệu nhanh hơn
- Dẽ bảo trì
* Cách triển khai
- Chúng ta sẽ khởi tạo một interface, sau đó sẽ khởi tạo 2 class kế thừa lại interface đó, 1 class có tác dụng đọc, 1 class có tác dụng ghi

Video 4:
- Xử lý Error có 3 cách:
+ Sử dụng Filter => Khởi tạo FilterAttribute kế thừa lớp ExceptionFilterAttribute sau đó override lại hàm OnException 
+ Sử dụng Middleware
+ Khởi tạo ErrosController với route là /error
- Lưu ý: cảm thấy dùng ErrosController dễ dàng hơn
- RFC for Problem Details là gì?
+ Là 1 tiêu chuẩn về đối tượng Json trả về
