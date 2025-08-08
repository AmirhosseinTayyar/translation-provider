# Troubleshooting Guide

This guide helps resolve common issues when working with the Translation Provider project.

## Prerequisites Issues

### .NET 9.0 SDK Not Found

**Error**: `The current .NET SDK does not support targeting .NET 9.0`

**Solution**:
1. Download and install [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
2. Verify installation: `dotnet --version`
3. Restart your IDE/terminal

### Zamin Framework Compatibility

**Error**: `Package Zamin.Core.Domain 9.0.0 is not compatible with net8.0`

**Solution**:
- This project requires .NET 9.0 due to Zamin Framework dependencies
- The framework is specifically designed for .NET 9.0
- Use .NET 9.0 SDK as specified in prerequisites

## Database Issues

### Connection String Problems

**Error**: `Cannot connect to SQL Server`

**Solutions**:

1. **Check SQL Server is running**:
   ```bash
   # For Docker
   docker ps | grep sql
   
   # For Windows Service
   net start mssqlserver
   ```

2. **Verify connection string format**:
   ```json
   {
     "ConnectionStrings": {
       "CommandDb_ConnectionString": "Server=(localdb)\\mssqllocaldb;Database=TranslationProviderDb;Trusted_Connection=true;MultipleActiveResultSets=true;",
       "QueryDb_ConnectionString": "Server=(localdb)\\mssqllocaldb;Database=TranslationProviderDb;Trusted_Connection=true;MultipleActiveResultSets=true;"
     }
   }
   ```

3. **For LocalDB issues**:
   ```bash
   # Create LocalDB instance
   sqllocaldb create MSSQLLocalDB
   sqllocaldb start MSSQLLocalDB
   ```

### Migration Issues

**Error**: `Unable to create migrations` or `Database update failed`

**Solutions**:

1. **Install EF Core tools**:
   ```bash
   dotnet tool install --global dotnet-ef
   dotnet tool update --global dotnet-ef
   ```

2. **Navigate to correct directory**:
   ```bash
   cd src/3.Endpoints/API
   ```

3. **Check DbContext configuration**:
   - Ensure connection strings are correct
   - Verify DbContext registrations in `HostingExtensions.cs`

4. **Create migrations**:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Reset database if needed**:
   ```bash
   dotnet ef database drop
   dotnet ef database update
   ```

### Permission Issues

**Error**: `Cannot open database` or `Login failed`

**Solutions**:

1. **For LocalDB**:
   - Run Visual Studio or command prompt as Administrator
   - Ensure Windows user has access to LocalDB

2. **For SQL Server**:
   ```sql
   -- Create login and user
   CREATE LOGIN [YourUser] FROM WINDOWS;
   USE TranslationProviderDb;
   CREATE USER [YourUser] FOR LOGIN [YourUser];
   ALTER ROLE db_owner ADD MEMBER [YourUser];
   ```

## Build Issues

### Package Restore Failures

**Error**: `NU1101: Unable to find package` or `Package restore failed`

**Solutions**:

1. **Clear NuGet cache**:
   ```bash
   dotnet nuget locals all --clear
   ```

2. **Restore packages**:
   ```bash
   dotnet restore --force
   ```

3. **Check NuGet sources**:
   ```bash
   dotnet nuget list source
   ```

4. **Reset to default sources if needed**:
   ```bash
   nuget sources Add -Name "nuget.org" -Source "https://api.nuget.org/v3/index.json"
   ```

### Build Compilation Errors

**Error**: Various compilation errors

**Solutions**:

1. **Clean solution**:
   ```bash
   dotnet clean
   dotnet build
   ```

2. **Check target framework**:
   - Ensure all projects target `net9.0`
   - Verify package versions are compatible

3. **Rebuild solution**:
   ```bash
   dotnet clean
   dotnet restore
   dotnet build
   ```

## Runtime Issues

### Application Startup Failures

**Error**: Application fails to start or throws exceptions during startup

**Solutions**:

1. **Check configuration**:
   - Verify `appsettings.json` format
   - Ensure all required configuration sections exist
   - Check connection strings

2. **Review logs**:
   ```bash
   # Check console output for detailed error messages
   dotnet run --verbosity diagnostic
   ```

3. **Validate database**:
   ```bash
   # Test database connection
   dotnet ef database update --verbose
   ```

### Port Already in Use

**Error**: `Failed to bind to address`

**Solutions**:

1. **Check what's using the port**:
   ```bash
   # Windows
   netstat -ano | findstr :7000
   
   # macOS/Linux
   lsof -i :7000
   ```

2. **Kill the process**:
   ```bash
   # Windows
   taskkill /PID <PID> /F
   
   # macOS/Linux
   kill -9 <PID>
   ```

3. **Change port in `launchSettings.json`**:
   ```json
   {
     "profiles": {
       "https": {
         "applicationUrl": "https://localhost:7001;http://localhost:5001"
       }
     }
   }
   ```

### Missing Health Check Endpoint

**Error**: `/health` endpoint returns 404

**Solution**:
- Ensure health checks are properly configured in `HostingExtensions.cs`
- Verify the middleware pipeline includes `app.MapHealthChecks("/health")`

## Docker Issues

### Docker Build Failures

**Error**: Docker build fails

**Solutions**:

1. **Check Docker is running**:
   ```bash
   docker --version
   docker info
   ```

2. **Build with verbose output**:
   ```bash
   docker build --progress=plain .
   ```

3. **Check .dockerignore**:
   - Ensure necessary files aren't ignored
   - Verify project structure

### Docker Compose Issues

**Error**: Services fail to start or connect

**Solutions**:

1. **Check service logs**:
   ```bash
   docker-compose logs translation-provider-api
   docker-compose logs sqlserver
   ```

2. **Verify network connectivity**:
   ```bash
   docker-compose exec translation-provider-api ping sqlserver
   ```

3. **Reset Docker environment**:
   ```bash
   docker-compose down -v
   docker-compose up --build
   ```

### SQL Server Container Issues

**Error**: SQL Server container fails to start

**Solutions**:

1. **Check memory requirements** (SQL Server needs at least 2GB):
   ```bash
   docker run --memory=2g mcr.microsoft.com/mssql/server:2022-latest
   ```

2. **Verify environment variables**:
   - `ACCEPT_EULA=Y`
   - `SA_PASSWORD` meets complexity requirements

3. **Check container logs**:
   ```bash
   docker logs translation-provider-sqlserver
   ```

## Development Environment Issues

### IDE Configuration

**Visual Studio Issues**:
1. Update to latest version (2022 17.8+)
2. Install .NET 9.0 workload
3. Clear Visual Studio cache:
   - Delete `bin` and `obj` folders
   - Close VS, delete `.vs` folder, reopen

**VS Code Issues**:
1. Install/update C# extension
2. Reload window (Ctrl+Shift+P → "Developer: Reload Window")
3. Check .NET SDK in integrated terminal

**JetBrains Rider Issues**:
1. Update to latest version
2. Invalidate caches (File → Invalidate Caches and Restart)
3. Check .NET SDK configuration

### Performance Issues

**Slow startup or response times**:

1. **Check database performance**:
   - Ensure database server has adequate resources
   - Check for blocking queries or locks

2. **Review logging configuration**:
   - Reduce log verbosity in production
   - Use structured logging efficiently

3. **Monitor resource usage**:
   ```bash
   # Check memory and CPU usage
   dotnet-counters monitor --process-id <pid>
   ```

## API Issues

### Swagger/OpenAPI Not Loading

**Error**: Swagger UI returns 404 or fails to load

**Solutions**:

1. **Check environment**:
   - Swagger is only enabled in Development by default
   - Verify `app.Environment.IsDevelopment()` condition

2. **Access correct URLs**:
   - Swagger UI: `https://localhost:7000/swagger`
   - Scalar UI: `https://localhost:7000/scalar/v1`
   - OpenAPI JSON: `https://localhost:7000/swagger/v1/swagger.json`

### CORS Issues

**Error**: `CORS policy blocked` in browser

**Solutions**:

1. **Check CORS configuration**:
   ```csharp
   app.UseCors(builder =>
   {
       builder.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
   });
   ```

2. **Update allowed origins for production**:
   ```json
   {
     "Cors": {
       "AllowedOrigins": [
         "https://yourdomain.com",
         "https://app.yourdomain.com"
       ]
     }
   }
   ```

### Authentication Issues

**Error**: `401 Unauthorized` responses

**Solutions**:

1. **Check authentication configuration**:
   - Most endpoints don't require authentication by default
   - `GetLocalizationRecords` allows anonymous access

2. **Verify controller attributes**:
   - Check for `[Authorize]` attributes
   - Ensure `[AllowAnonymous]` where needed

## Logging and Debugging

### Enable Detailed Logging

Add to `appsettings.Development.json`:

```json
{
  "Serilog": {
    "MinimumLevel": {
      "Default": "Debug",
      "Override": {
        "Microsoft": "Information",
        "System": "Information",
        "TranslationProvider": "Debug"
      }
    }
  }
}
```

### Debug Database Queries

Enable EF Core query logging:

```json
{
  "Logging": {
    "LogLevel": {
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  }
}
```

### Application Insights (Production)

Configure application monitoring:

```json
{
  "ApplicationInsights": {
    "InstrumentationKey": "your-key-here"
  }
}
```

## Getting Help

### Internal Troubleshooting

1. **Check logs** in `logs/` directory
2. **Review configuration** files
3. **Verify database** state and migrations
4. **Test connectivity** between components

### External Resources

1. **Documentation**:
   - [Project README](../README.md)
   - [API Documentation](API.md)
   - [Development Guide](DEVELOPMENT.md)

2. **Framework Documentation**:
   - [Zamin Framework](https://github.com/oroumand/Zamin)
   - [.NET 9.0 Documentation](https://docs.microsoft.com/en-us/dotnet/)
   - [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

3. **Community Support**:
   - Create an issue in the GitHub repository
   - Include error messages, logs, and environment details
   - Follow the issue template for faster resolution

### Diagnostic Commands

```bash
# Check .NET installation
dotnet --info

# List installed SDKs
dotnet --list-sdks

# Check project dependencies
dotnet list package

# Verify project configuration
dotnet build --verbosity diagnostic

# Check EF Core tools
dotnet ef --version

# Test database connectivity
dotnet ef database update --verbose
```

Remember to always include relevant error messages, environment details, and steps to reproduce when seeking help!