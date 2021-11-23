FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["catalog-api.csproj", "./"]
RUN dotnet restore "catalog-api.csproj"
COPY . .
RUN dotnet publish "catalog-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY .env /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "catalog-api.dll"]
