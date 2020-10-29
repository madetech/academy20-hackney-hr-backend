FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY bin/release/netcoreapp3.1/publish/ HackneyBackendApp/
WORKDIR /HackneyBackendApp
ENTRYPOINT ["dotnet", "NetCore.Docker.dll"]