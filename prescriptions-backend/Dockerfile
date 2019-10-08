FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
COPY . ./
RUN dotnet publish ./prescription/prescription.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /prescription
COPY --from=build-env /app/prescription/out .
ENTRYPOINT ["dotnet", "prescription.dll"]