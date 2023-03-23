#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VehiclePing.SimulatorWorkerService/VehiclePing.SimulatorWorkerService.csproj", "VehiclePing.SimulatorWorkerService/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "VehiclePing.SimulatorWorkerService/VehiclePing.SimulatorWorkerService.csproj"
COPY . .
WORKDIR "/src/VehiclePing.SimulatorWorkerService"
RUN dotnet build "VehiclePing.SimulatorWorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehiclePing.SimulatorWorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehiclePing.SimulatorWorkerService.dll"]