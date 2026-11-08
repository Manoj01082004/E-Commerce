FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["ProductServices/ProductServices.csproj", "ProductServices/"]

RUN dotnet restore "ProductServices/ProductServices.csproj"

COPY . .

WORKDIR "/src/ProductServices"

RUN dotnet publish "ProductServices.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ProductServices.dll"]