FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish ./doctor-dc-backend/doctor-dc-backend.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /doctor-dc-backend
COPY --from=build-env /app/doctor-dc-backend/out .
ENTRYPOINT ["dotnet", "doctor-dc-backend.dll"]