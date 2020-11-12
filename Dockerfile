FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY *.sln .

# Copy csproj and restore as distinct layers
COPY Api/*.csproj Api/
# COPY Tests/*.csproj Tests/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Api.dll