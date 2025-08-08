# Development Setup Guide

This guide will help you set up the Translation Provider project for development.

## Prerequisites

### Required Software

1. **[.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)**
   - Required for building and running the application
   - Verify installation: `dotnet --version`

2. **SQL Server**
   - [SQL Server Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (free)
   - Or [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (lightweight option)
   - Or use Docker with the provided `docker-compose.yml`

3. **IDE (Choose one)**
   - [Visual Studio 2022](https://visualstudio.microsoft.com/) (Community edition is free)
   - [JetBrains Rider](https://www.jetbrains.com/rider/)
   - [Visual Studio Code](https://code.visualstudio.com/) with C# extension

### Optional Tools

- **[Git](https://git-scm.com/)** for version control
- **[Docker Desktop](https://www.docker.com/products/docker-desktop)** for containerized development
- **[Postman](https://www.postman.com/)** for API testing
- **[SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/)** for database management

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/AmirhosseinTayyar/translation-provider.git
cd translation-provider
```

### 2. Database Setup

#### Option A: Using SQL Server LocalDB (Recommended for Development)

LocalDB is included with Visual Studio or can be installed separately. The default connection string in `appsettings.json` is configured for LocalDB.

```bash
# Navigate to the API project
cd src/3.Endpoints/API

# Install Entity Framework tools (if not already installed)
dotnet tool install --global dotnet-ef

# Create the database and apply migrations
dotnet ef database update
```

#### Option B: Using Docker SQL Server

```bash
# Start SQL Server using Docker Compose
docker-compose up sqlserver -d

# Wait for SQL Server to start, then apply migrations
cd src/3.Endpoints/API
dotnet ef database update
```

#### Option C: Using Full SQL Server

1. Install SQL Server Developer Edition
2. Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TranslationProviderDb;Integrated Security=true;TrustServerCertificate=true;"
  }
}
```

3. Apply migrations:

```bash
cd src/3.Endpoints/API
dotnet ef database update
```

### 3. Restore Dependencies

```bash
# From the solution root directory
dotnet restore
```

### 4. Build the Solution

```bash
# Build all projects
dotnet build

# Or build specific configuration
dotnet build --configuration Debug
```

### 5. Run the Application

#### Option A: Using .NET CLI

```bash
cd src/3.Endpoints/API
dotnet run
```

#### Option B: Using Visual Studio

1. Open `TranslationProvider.sln` in Visual Studio
2. Set `TranslationProvider.Endpoints.API` as the startup project
3. Press F5 or click "Start Debugging"

#### Option C: Using Docker

```bash
# Build and run the entire application stack
docker-compose up --build
```

### 6. Verify Setup

Once the application is running, you can access:

- **Swagger UI**: https://localhost:7000/swagger
- **Scalar UI**: https://localhost:7000/scalar/v1
- **API Base URL**: https://localhost:7000/api

Test the health endpoint:
```bash
curl https://localhost:7000/api/health
```

## Development Workflow

### Adding Database Migrations

When you modify entities or add new ones:

```bash
cd src/3.Endpoints/API

# Add a new migration
dotnet ef migrations add YourMigrationName

# Apply the migration to the database
dotnet ef database update
```

### Running in Development Mode

The application is configured to run in Development mode by default, which enables:
- Detailed error pages
- Swagger UI
- Hot reload (when using `dotnet watch`)

```bash
# Run with hot reload
cd src/3.Endpoints/API
dotnet watch run
```

### Environment Variables

For development, you can set environment variables in:
- `appsettings.Development.json`
- `launchSettings.json`
- System environment variables

## Project Structure

```
src/
├── 1.Core/
│   ├── Domain/                  # Domain entities, value objects, events
│   │   ├── Common/             # Shared domain components
│   │   ├── Cultures/           # Culture-related domain objects
│   │   └── Translations/       # Translation-related domain objects
│   ├── Contracts/              # Application contracts and DTOs
│   │   ├── Common/             # Shared contracts
│   │   ├── Cultures/           # Culture-related contracts
│   │   └── Translations/       # Translation-related contracts
│   └── ApplicationService/     # Application service handlers
│       ├── Cultures/           # Culture command/query handlers
│       └── Translations/       # Translation command/query handlers
├── 2.Infra/
│   └── Data/
│       ├── Sql.Commands/       # Write-side data access
│       └── Sql.Queries/        # Read-side data access
└── 3.Endpoints/
    └── API/                    # Web API controllers and configuration
        ├── Features/           # Feature-organized controllers
        ├── Extentions/         # Extension methods and configuration
        └── Properties/         # Assembly properties
```

## Debugging

### Using Visual Studio

1. Set breakpoints in your code
2. Press F5 to start debugging
3. The application will pause at breakpoints

### Using VS Code

1. Install the C# extension
2. Open the project folder
3. Use F5 to start debugging or Ctrl+Shift+P → ".NET: Generate Assets for Build and Debug"

### Using Logs

The application uses Serilog for structured logging. Logs are written to:
- Console (in development)
- Files (configured in production)

Log levels can be configured in `appsettings.json`:

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft": "Warning",
        "System": "Warning"
      }
    }
  }
}
```

## Testing

### Running Tests

```bash
# Run all tests (when test projects are added)
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

### Manual API Testing

Use the Swagger UI at `https://localhost:7000/swagger` or test with curl:

```bash
# Create a new translation
curl -X POST "https://localhost:7000/api/Translation/Create" \
  -H "Content-Type: application/json" \
  -d '{
    "key": "hello_world",
    "value": "Hello, World!",
    "culture": "en-US"
  }'

# Get translations with paging
curl "https://localhost:7000/api/Translation/GetFilterablePaged?pageIndex=1&pageSize=10"
```

## Common Issues and Solutions

### Issue: "Unable to connect to SQL Server"

**Solution**: 
- Ensure SQL Server is running
- Check the connection string in `appsettings.json`
- Verify firewall settings

### Issue: "Package restore failed"

**Solution**:
- Clear NuGet cache: `dotnet nuget locals all --clear`
- Restore packages: `dotnet restore`
- Check internet connectivity

### Issue: "Migration failed"

**Solution**:
- Drop the database and recreate: `dotnet ef database drop` then `dotnet ef database update`
- Check for conflicting migrations
- Ensure proper permissions on the database

### Issue: "Port already in use"

**Solution**:
- Change the port in `launchSettings.json`
- Kill the process using the port: `netstat -ano | findstr :7000`

## Contributing

1. Create a feature branch from `main`
2. Make your changes following the coding standards
3. Add tests for new functionality
4. Update documentation if needed
5. Submit a pull request

### Coding Standards

- Follow C# naming conventions
- Use nullable reference types
- Add XML documentation for public APIs
- Keep methods small and focused
- Follow SOLID principles
- Use async/await for I/O operations

## Next Steps

After setting up the development environment:

1. Explore the codebase starting with the domain entities
2. Review the API endpoints in the Swagger UI
3. Check out the Clean Architecture implementation
4. Read about the Zamin framework: https://github.com/oroumand/Zamin

Happy coding! 🚀