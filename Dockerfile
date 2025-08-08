# Use the .NET 9 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET 9 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["src/3.Endpoints/API/TranslationProvider.Endpoints.API.csproj", "src/3.Endpoints/API/"]
COPY ["src/1.Core/ApplicationService/TranslationProvider.Core.ApplicationService.csproj", "src/1.Core/ApplicationService/"]
COPY ["src/1.Core/Contracts/TranslationProvider.Core.Contracts.csproj", "src/1.Core/Contracts/"]
COPY ["src/1.Core/Domain/TranslationProvider.Core.Domain.csproj", "src/1.Core/Domain/"]
COPY ["src/2.Infra/Data/Sql.Commands/TranslationProvider.Infra.Data.Sql.Commands.csproj", "src/2.Infra/Data/Sql.Commands/"]
COPY ["src/2.Infra/Data/Sql.Queries/TranslationProvider.Infra.Data.Sql.Queries.csproj", "src/2.Infra/Data/Sql.Queries/"]

# Restore dependencies
RUN dotnet restore "src/3.Endpoints/API/TranslationProvider.Endpoints.API.csproj"

# Copy all source code
COPY . .
WORKDIR "/src/src/3.Endpoints/API"

# Build the application
RUN dotnet build "TranslationProvider.Endpoints.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TranslationProvider.Endpoints.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Create a non-root user for security
RUN adduser --disabled-password --home /app --gecos '' appuser && chown -R appuser /app
USER appuser

ENTRYPOINT ["dotnet", "TranslationProvider.Endpoints.API.dll"]