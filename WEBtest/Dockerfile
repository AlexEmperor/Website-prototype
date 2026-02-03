FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# копируем ВСЁ решение
COPY . .

# восстанавливаем зависимости
RUN dotnet restore

# публикуем основной проект
RUN dotnet publish WEBTest/WEBtest.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WEBtest.dll"]
