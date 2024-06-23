#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src"
COPY ["FinServ.Infra/FinServ.Infra.csproj", "/FinServ.Infra/"]
COPY ["FinServ.Api/FinServ.Api.csproj", "/FinServ.Api/"]
COPY ["FinServ.Application/FinServ.Application.csproj", "/FinServ.Application/"]
COPY ["FinServ.Domain/FinServ.Domain.csproj", "/FinServ.Domain/"]

RUN dotnet restore "/FinServ.Api/FinServ.Api.csproj"
COPY . .
WORKDIR "/src/FinServ.Api"
RUN dotnet build "./FinServ.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FinServ.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinServ.Api.dll"]