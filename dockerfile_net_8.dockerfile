# Dockerfile для ASP.NET Core MVC (.NET 8)

# Базовый образ для выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Базовый образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем все файлы проекта в контейнер
COPY . .

# Сборка проекта и публикация в папку /app/publish
RUN dotnet publish "WEBtest.csproj" -c Release -o /app/publish

# Финальный образ
FROM base AS final
WORKDIR /app

# Копируем из стадии сборки только папку publish
COPY --from=build /app/publish .

# Запуск приложения
ENTRYPOINT ["dotnet", "WEBtest.dll"]
