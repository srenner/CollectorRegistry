#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CollectorRegistry.DataBridge/CollectorRegistry.DataBridge.csproj", "CollectorRegistry.DataBridge/"]
RUN dotnet restore "CollectorRegistry.DataBridge/CollectorRegistry.DataBridge.csproj"
COPY . .
WORKDIR "/src/CollectorRegistry.DataBridge"
RUN dotnet build "CollectorRegistry.DataBridge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectorRegistry.DataBridge.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectorRegistry.DataBridge.dll"]