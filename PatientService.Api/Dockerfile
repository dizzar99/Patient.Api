FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PatientService.Api/PatientService.Api.csproj", "PatientService.Api/"]
COPY ["PatientService.Application/PatientService.Application.csproj", "PatientService.Application/"]
COPY ["PatientService.Domain/PatientService.Domain.csproj", "PatientService.Domain/"]
COPY ["PatientService.Infrastructure/PatientService.Infrastructure.csproj", "PatientService.Infrastructure/"]
RUN dotnet restore "./PatientService.Api/PatientService.Api.csproj"
COPY . .
WORKDIR "/src/PatientService.Api"
RUN dotnet build "./PatientService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatientService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

RUN apt-get update 
RUN apt-get --yes install curl
HEALTHCHECK --interval=5s --timeout=10s --retries=3 CMD curl --silent --fail http://localhost:8080/health || exit 1
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientService.Api.dll"]