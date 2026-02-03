# ---------- build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# копируем всё
COPY . .

# восстанавливаем зависимости по solution
RUN dotnet restore "WEBtest/WEBtest.sln"

# публикуем основной веб-проект
RUN dotnet publish "WEBtest/WEBtest.csproj" -c Release -o /app/publish

# ---------- runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "WEBtest.dll"]
