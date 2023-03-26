#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["System/Api/exhibitions.Api/exhibitions.Api.csproj", "System/Api/exhibitions.Api/"]
COPY ["Data/exhibitions.Context/exhibitions.Context.csproj", "Data/exhibitions.Context/"]
COPY ["Shared/exhibition.Settings/exhibition.Settings.csproj", "Shared/exhibition.Settings/"]
COPY ["Data/exhibitions.Context.Entities/exhibitions.Context.Entities.csproj", "Data/exhibitions.Context.Entities/"]
COPY ["Data/Migrations/exhibitions.Context.MigrationsMSSQL/exhibitions.Context.MigrationsMSSQL.csproj", "Data/Migrations/exhibitions.Context.MigrationsMSSQL/"]
COPY ["Data/Migrations/exhibitions.Context.MigrationsPostgreSQL/exhibitions.Context.MigrationsPostgreSQL.csproj", "Data/Migrations/exhibitions.Context.MigrationsPostgreSQL/"]
COPY ["Services/exhibition.Services.exhibitions/exhibition.Services.exhibitions.csproj", "Services/exhibition.Services.exhibitions/"]
COPY ["Shared/exhibition.Common/exhibition.Common.csproj", "Shared/exhibition.Common/"]
COPY ["Services/exhibition.Services.Settings/exhibition.Services.Settings.csproj", "Services/exhibition.Services.Settings/"]
RUN dotnet restore "System/Api/exhibitions.Api/exhibitions.Api.csproj"
COPY . .
WORKDIR "/src/System/Api/exhibitions.Api"
RUN dotnet build "exhibitions.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "exhibitions.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "exhibitions.Api.dll"]