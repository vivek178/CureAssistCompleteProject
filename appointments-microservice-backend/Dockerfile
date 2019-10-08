From mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app

copy . ./
RUN dotnet restore

RUN dotnet publish ./AppointmentsWebAPI/AppointmentsWebAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /AppointmentsWebAPI
COPY --from=build-env /app/AppointmentsWebAPI/out .
ENTRYPOINT ["dotnet", "AppointmentsWebAPI.dll"]