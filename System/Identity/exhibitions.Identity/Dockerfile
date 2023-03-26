#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["System/Identity/exhibitions.Identity/exhibitions.Identity.csproj", "System/Identity/exhibitions.Identity/"]
COPY ["Data/exhibitions.Context.Entities/exhibitions.Context.Entities.csproj", "Data/exhibitions.Context.Entities/"]
COPY ["Data/exhibitions.Context/exhibitions.Context.csproj", "Data/exhibitions.Context/"]
COPY ["Shared/exhibition.Settings/exhibition.Settings.csproj", "Shared/exhibition.Settings/"]
COPY ["Shared/exhibition.Common/exhibition.Common.csproj", "Shared/exhibition.Common/"]
RUN dotnet restore "System/Identity/exhibitions.Identity/exhibitions.Identity.csproj"
COPY . .
WORKDIR "/src/System/Identity/exhibitions.Identity"
RUN dotnet build "exhibitions.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "exhibitions.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "exhibitions.Identity.dll"]