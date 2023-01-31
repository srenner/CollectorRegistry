#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CollectorRegistry.TestConsole/CollectorRegistry.TestConsole.csproj", "CollectorRegistry.TestConsole/"]
RUN dotnet restore "CollectorRegistry.TestConsole/CollectorRegistry.TestConsole.csproj"
COPY . .
WORKDIR "/src/CollectorRegistry.TestConsole"
RUN dotnet build "CollectorRegistry.TestConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectorRegistry.TestConsole.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectorRegistry.TestConsole.dll"]