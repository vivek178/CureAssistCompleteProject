FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish ./RatingWebApi/RatingWebApi.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /RatingWebApi
COPY --from=build-env /app/RatingWebApi/out .
ENTRYPOINT ["dotnet","RatingWebApi.dll"]