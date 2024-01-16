#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API_les_bon_comptes_les_bons_amis/API_les_bon_comptes_les_bons_amis.csproj", "API_les_bon_comptes_les_bons_amis/"]
RUN dotnet restore "./API_les_bon_comptes_les_bons_amis/./API_les_bon_comptes_les_bons_amis.csproj"
COPY . .
WORKDIR "/src/API_les_bon_comptes_les_bons_amis"
RUN dotnet build "./API_les_bon_comptes_les_bons_amis.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API_les_bon_comptes_les_bons_amis.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_les_bon_comptes_les_bons_amis.dll"]