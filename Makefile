install:
	dotnet add ./VegeFood package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 3.1.8
	dotnet add ./VegeFood package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.7
	dotnet add ./VegeFood package Microsoft.AspNetCore.Authentication.Google --version 3.1.8
	dotnet add ./VegeFood package Microsoft.AspNetCore.Authentication.Facebook --version 3.1.8
	dotnet add ./VegeFood package Microsoft.AspNetCore.Identity.UI --version 3.1.8

initsecret:
	dotnet user-secrets init --project ./VegeFood

googlesecret clientId = "-client-id" clientSecret = "-client-secret-":
	dotnet user-secrets set "Authentication:Google:ClientId" $(clientId) --project ./VegeFood
	dotnet user-secrets set "Authentication:Google:ClientSecret" $(clientSecret) --project ./VegeFood

run:
	dotnet run --launch-profile VegeFood --project ./VegeFood
