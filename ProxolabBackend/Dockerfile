#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0.0-alpine3.16 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0.0-alpine3.16 AS build
WORKDIR /src
COPY ["ProxolabBackend/ProxolabBackend.csproj", "ProxolabBackend/"]
RUN dotnet restore "ProxolabBackend/ProxolabBackend.csproj"
COPY . .
WORKDIR "/src/ProxolabBackend"
RUN dotnet build "ProxolabBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProxolabBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProxolabBackend.dll"]