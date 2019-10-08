FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish ./TestReportAPi/TestReportAPi.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /TestReportAPi
COPY --from=build-env /app/TestReportAPi/out .
ENTRYPOINT ["dotnet", "TestReportAPi.dll"]
