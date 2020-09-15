### Một trang web đơn giản
#### công nghệ sử dụng: ASP.NET Core
#### trình biên dịch: Visual studio 2019

###### để cài đặt thư viện gọi lệnh: make install

### Một số lưu ý khi chạy chương trình
- chắc chắn máy tính đã cài make
- Enable secret storage chạy lệnh: dotnet user-secrets init --project ./VegeFood
- thêm client-id của google console API vào secret store: dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
- thêm client-secret của google console API vào secret store: dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>"
###### thông tin chi tiết tại [đây](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1)

### tài liệu tham khảo
- https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/attributes
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1
- https://www.yogihosting.com/aspnet-core-identity-login-with-google/#communicate
- https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1
- xem trang admin template tại [đây](https://github.com/ColorlibHQ/AdminLTE)
