# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем только solution и проекты для оптимизации кеша restore
COPY ["Webtest.sln", "./"]
COPY ["Webtest/", "Webtest/"]

# Восстанавливаем зависимости по solution
RUN dotnet restore "Webtest/Webtest.sln"

# Публикуем основной веб-проект в папку /app/publish
RUN dotnet publish "Webtest/Webtest.csproj" -c Release -o /app/publish

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Копируем готовое приложение из build stage
COPY --from=build /app/publish .

# Устанавливаем порт для Render или других облаков
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Запуск приложения
ENTRYPOINT ["dotnet", "Webtest.dll"]
