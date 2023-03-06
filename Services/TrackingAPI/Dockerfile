#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/TrackingAPI/TrackingAPI.csproj", "Services/TrackingAPI/"]
COPY ["Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "Common/EventBusRabbitMQ/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "Services/TrackingAPI/TrackingAPI.csproj"
COPY . .
WORKDIR "/src/Services/TrackingAPI"
RUN dotnet build "TrackingAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrackingAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrackingAPI.dll"]