#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MessageBrokerTestWorker/MessageBrokerTestWorker.csproj", "MessageBrokerTestWorker/"]
RUN dotnet restore "MessageBrokerTestWorker/MessageBrokerTestWorker.csproj"
COPY . .
WORKDIR "/src/MessageBrokerTestWorker"
RUN dotnet build "MessageBrokerTestWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessageBrokerTestWorker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessageBrokerTestWorker.dll"]