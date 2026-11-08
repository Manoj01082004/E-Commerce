FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["UserServices/UserServices.csproj", "UserServices/"]

RUN dotnet restore "UserServices/UserServices.csproj"

COPY . .

WORKDIR "/src/UserServices"

RUN dotnet publish "UserServices.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "UserServices.dll"]