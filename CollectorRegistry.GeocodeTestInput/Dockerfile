#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CollectorRegistry.GeocodeTestInput/CollectorRegistry.GeocodeTestInput.csproj", "CollectorRegistry.GeocodeTestInput/"]
COPY ["CollectorRegistry/Shared/CollectorRegistry.Shared.csproj", "CollectorRegistry/Shared/"]
RUN dotnet restore "CollectorRegistry.GeocodeTestInput/CollectorRegistry.GeocodeTestInput.csproj"
COPY . .
WORKDIR "/src/CollectorRegistry.GeocodeTestInput"
RUN dotnet build "CollectorRegistry.GeocodeTestInput.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectorRegistry.GeocodeTestInput.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectorRegistry.GeocodeTestInput.dll"]