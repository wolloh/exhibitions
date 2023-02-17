#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["System/Api/exhibition.Api/exhibition.Api.csproj", "System/Api/exhibition.Api/"]
COPY ["Services/exhibition.Services.Settings/exhibition.Services.Settings.csproj", "Services/exhibition.Services.Settings/"]
COPY ["Shared/exhibition.Settings/exhibition.Settings.csproj", "Shared/exhibition.Settings/"]
RUN dotnet restore "System/Api/exhibition.Api/exhibition.Api.csproj"
COPY . .
WORKDIR "/src/System/Api/exhibition.Api"
RUN dotnet build "exhibition.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "exhibition.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "exhibition.Api.dll"]