FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish ./onboarding-portal-backend/onboarding-portal-backend.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /onboarding-portal-backend
COPY --from=build-env /app/onboarding-portal-backend/out .
ENTRYPOINT ["dotnet","onboarding-portal-backend.dll"]