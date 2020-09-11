install:
	dotnet add ./VegeFood package Microsoft.EntityFrameworkCore --version 3.1.7
	dotnet add ./VegeFood package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.7
	dotnet add ./VegeFood package Microsoft.AspNetCore.Authentication.Google --version 3.1.8

run:
	dotnet run --launch-profile VegeFood --project ./VegeFood
