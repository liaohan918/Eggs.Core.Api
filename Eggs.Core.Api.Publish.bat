color B

del  .PublishFiles\*.*   /s /q

dotnet restore

dotnet build

cd Eggs.Core.Api.Api

dotnet publish -o ..\Eggs.Core.Api.Api\bin\Debug\netcoreapp3.1\

md ..\.PublishFiles

xcopy ..\Eggs.Core.Api.Api\bin\Debug\netcoreapp3.1\*.* ..\.PublishFiles\ /s /e 

echo "Successfully!!!! ^ please see the file .PublishFiles"

cmd