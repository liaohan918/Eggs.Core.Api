git pull;
rm -rf .PublishFiles;
dotnet build;
dotnet publish -o /home/Eggs.Core.Api/Eggs.Core.Api.Api/bin/Debug/netcoreapp3.1;
cp -r /home/Eggs.Core.Api/Eggs.Core.Api.Api/bin/Debug/netcoreapp3.1 .PublishFiles;
echo "Successfully!!!! ^ please see the file .PublishFiles";