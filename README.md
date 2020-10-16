### Xây dựng một trang web đơn giản
#### công nghệ sử dụng: ASP.NET Core 3.1
#### trình biên dịch: Visual studio 2019

###### để cài đặt thư viện gọi lệnh: make install

### Một số lưu ý khi chạy chương trình
- chắc chắn máy tính đã cài make

### Một số lệnh để chạy chương trình
#### lưu ý: chuyển đến thư mục WebCore: cd /WebCore
- Enable secret storage chạy lệnh: make initsecret
- thêm google clientId vào secret store: make googleclientid clientId="Your Client Id"
- thêm google clientSecret vào secret store: make googlesecret clientSecret="Your Client Secret"
###### thông tin chi tiết tại [đây](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1)

### tài liệu tham khảo
- https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/attributes
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1
- https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/external-authentication-services
- https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api
- https://www.yogihosting.com/aspnet-core-identity-login-with-google/#communicate
- https://www.tektutorialshub.com/asp-net-core/asp-net-core-model-binding/
- xem trang admin template tại [đây](https://github.com/ColorlibHQ/AdminLTE)
- download template trang chủ tại [đây](https://colorlib.com/wp/template/vegefoods/)
