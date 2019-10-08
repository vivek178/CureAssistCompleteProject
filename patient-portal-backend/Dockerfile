FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish ./Patient-Portal/Patient-Portal.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /Patient-Portal
COPY --from=build-env /app/Patient-Portal/out .
ENTRYPOINT ["dotnet","Patient-Portal.dll"]