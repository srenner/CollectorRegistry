#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CollectorRegistry/Server/CollectorRegistry.Server.csproj", "CollectorRegistry/Server/"]
COPY ["CollectorRegistry/Client/CollectorRegistry.Client.csproj", "CollectorRegistry/Client/"]
COPY ["CollectorRegistry/Shared/CollectorRegistry.Shared.csproj", "CollectorRegistry/Shared/"]


RUN dotnet restore "CollectorRegistry/Server/CollectorRegistry.Server.csproj"
COPY . .
WORKDIR "/src/CollectorRegistry/Server"
RUN dotnet build "CollectorRegistry.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectorRegistry.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectorRegistry.Server.dll"]