install:
	dotnet add ./VegeFood package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 3.1.8
	dotnet add ./VegeFood package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.7
	dotnet add ./VegeFood package Microsoft.AspNetCore.Authentication.Google --version 3.1.8
	dotnet add ./VegeFood package Microsoft.AspNetCore.Authentication.Facebook --version 3.1.8
	dotnet add ./VegeFood package Microsoft.AspNetCore.Identity.UI --version 3.1.8

initsecret:
	dotnet user-secrets init --project ./VegeFood

googlesecret:
	dotnet user-secrets set "Authentication:Google:ClientId" "-client-id-"
	dotnet user-secrets set "Authentication:Google:ClientSecret" "-client-secret-"

run:
	dotnet run --launch-profile VegeFood --project ./VegeFood
