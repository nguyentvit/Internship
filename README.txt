Ngày 4/7/2024:
Video 8:
Cách sử dụng FluentValidation vào pipelineBehavior của MediatR
* Khi MediatR hoạt động nó sẽ tạo ra 1 request sau đó sẽ chuyển tới hàm handle để xử ý
hàm handle sẽ có phần xử lý nằm giữa pipelineBehavior nên chúng ta có thể thêm hàm xử lý trước và sau khi đưa 1 request vào handle
* Ở đây chúng ta tích hợp fluentValidation ở hàm tiền xử lý
nếu validate fail thì sẽ return về error và không đưa handle để xử lý
còn nếu valid thì sẽ return next để đưa vào handle để xử lý

Video 9:
* Cách cấu hình authentication và authorization xác thực bằng jwt

Video 10:
Kiến trúc DDD (Domain Driven Design):
Mô hình hóa các vấn đề nghiệp vụ
Các khái niệm chính:
Entities: là các đối tượng chính của domain có thể hiểu là 1 bảng trong db
Value object: là một đối tượng nhỏ hơn, có thể hiểu là 1 cột trong 1 bảng trong db
Aggregates: là một tổng hợp các Entities và Value object 
Domain Event: là biểu diễn các sự kiện quan trọng xảy ra trong domain, chỉ chứa dữ liệu của sự kiện và không nên chứa logic nghiệp vụ phức tạp


Video 11:
Cách phân tích một bài toán 
B1: Cần phân tích xem có những thực thể nào xuất hiện trong bài toán, mỗi thực thể sẽ tương ứng với 1 box
B2: Dưới mỗi box, ta sẽ phân tích xem thực thể đó sẽ chịu ảnh hưởng từ những thực thể nào khác
B3: Trường hợp 1 box sẽ tác động lên nhiều box khác nhau thì box đó sẽ thành 1 aggregate root, còn dưới các box bị ảnh hưởng sẽ là boxId
Lưu ý: 
TH1: Nếu 1 box chỉ tác động lên 1 thực thể duy nhất, thì box đó sẽ kh được coi là aggregate root, mà chuyển toàn bộ nó xuống dưới chân của thực thể
TH2: Nếu có trường hợp 2 box tách riêng ra sẽ gây ra kết quả không mong muốn, thì chuyển box child xuống box parent
Có ghi rõ số lượng như 1 box sẽ có nhiều box thì chỉ là 1 box chịu ảnh hưởng bởi 1 box

Sau khi phân tích xong bài toán, ta sẽ tạo ra một file md để mô tả chi tiết 1 api cần trả về những gì cho thực thể đó (lưu ý sẽ có thêm các trường chi tiết cho mỗi thực thể)

Video 12:
Cách triển khai 1 aggregate:

# Domain Models

## Menu

```csharp
```

```json
{
    "id": {"values": "0000000-0000000-0000000-000000000"},
    "name": "yummy yummy",
    "description": "A menu with yummy food",
    "averageRating": 4.5,
    "sections": [
        {
            "id": {"values": "0000000-0000000-0000000-000000000"},
            "name": "sodro",
            "description": "stater",
            "items": [
                {
                    "id": {"values": "0000000-0000000-0000000-000000000"},
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles",
                    "price": 5.99
                }
            ]
        }
    ],
    "hostId": {"values": "0000000-0000000-0000000-000000000"},
    "dinnerIds": [
        {"values": "0000000-0000000-0000000-000000000"},
        {"values": "0000000-0000000-0000000-000000000"},
    ],
    "menuReviewIds": [
        {"values": "0000000-0000000-0000000-000000000"},
        {"values": "0000000-0000000-0000000-000000000"},
    ],
    "createdDateTime": "2021-01-01",
    "updatedDateTime": "2021-01-01"
}
```

Phân tích json trả về của thực thể Menu ở trên
- Aggregate này có aggregate root <MenuId> => MenuId là 1 ValueObject
- Name, Description là các thông tin bổ sung => không cần tạo ValueObject
- AverageRating chịu tác động từ MenuReivew nhưng không tách riêng ra 1 thực thực nên tạo ValueObject trong common
- List Sections => section không phải là 1 thực thể, là 1 thông tin chính => tạo entity
- HostId là 1 value object của aggregate Host
- List DinnerIds là 1 list value object DinnerId của aggregate Dinner
- MenuReviewIds là 1 list value object MenuReviewId của aggregate MenuReview
- createdDatetime, updatedDatetime là các thông tin bổ sung => không cần tạo ValueObject

Video 13 :












