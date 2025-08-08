# Translation Provider

A robust translation and localization management system built with .NET 9 using Clean Architecture principles and the Zamin framework.

## 🚀 Features

- **Translation Management**: Complete CRUD operations for managing translations
- **Culture Management**: Support for multiple cultures with enable/disable functionality
- **Localization API**: RESTful endpoints for retrieving localization data
- **Clean Architecture**: Separation of concerns with Domain, Application, Infrastructure, and API layers
- **CQRS Pattern**: Command Query Responsibility Segregation for optimal performance
- **Domain Events**: Event-driven architecture for loose coupling
- **Validation**: Comprehensive input validation using FluentValidation
- **OpenAPI Documentation**: Interactive API documentation with Scalar UI
- **Structured Logging**: Advanced logging with Serilog

## 🏗️ Architecture

This project follows Clean Architecture principles with the following layer structure:

```
src/
├── 1.Core/
│   ├── Domain/               # Business entities, value objects, and domain events
│   ├── Contracts/            # Application contracts, DTOs, and validators
│   └── ApplicationService/   # Command and query handlers (CQRS)
├── 2.Infra/
│   └── Data/
│       ├── Sql.Commands/     # Write operations and data persistence
│       └── Sql.Queries/      # Read operations and data retrieval
└── 3.Endpoints/
    └── API/                  # RESTful API controllers and configuration
```

### Domain Model

#### Translation Entity
- **TranslationKey**: Unique identifier for translation entries
- **TranslationValue**: The actual translated text
- **CultureKey**: Associated culture/language identifier

#### Culture Entity
- **Culture Management**: Enable/disable cultures
- **Culture Selection**: Dropdown lists for UI components

## 🛠️ Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (for data persistence)
- Visual Studio 2022 or JetBrains Rider (recommended)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/AmirhosseinTayyar/translation-provider.git
cd translation-provider
```

### 2. Configure Database Connection

Update the connection string in `src/3.Endpoints/API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TranslationProviderDb;Trusted_Connection=true;MultipleActiveResultSets=true;"
  },
  "ApplicationName": "Translation Provider",
  "ServiceId": "translation-provider",
  "ServiceName": "Translation Provider Service",
  "ServiceVersion": "1.0.0"
}
```

### 3. Run Database Migrations

```bash
cd src/3.Endpoints/API
dotnet ef database update
```

### 4. Restore Dependencies

```bash
dotnet restore
```

### 5. Run the Application

```bash
cd src/3.Endpoints/API
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:7000`
- HTTP: `http://localhost:5000`
- Swagger UI: `https://localhost:7000/swagger`
- Scalar UI: `https://localhost:7000/scalar/v1`

## 📡 API Endpoints

### Translation Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Translation/Create` | Create a new translation |
| PUT | `/api/Translation/Update` | Update an existing translation |
| DELETE | `/api/Translation/Delete` | Delete a translation |
| GET | `/api/Translation/GetById` | Get translation by ID |
| GET | `/api/Translation/GetFilterablePaged` | Get paginated translations with filtering |
| GET | `/api/Translation/GetLocalizationRecords` | Get localization data (public endpoint) |

### Culture Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Culture/Create` | Create a new culture |
| PUT | `/api/Culture/Update` | Update an existing culture |
| DELETE | `/api/Culture/Delete` | Delete a culture |
| PUT | `/api/Culture/Enable` | Enable a culture |
| PUT | `/api/Culture/Disable` | Disable a culture |
| GET | `/api/Culture/GetById` | Get culture by ID |
| GET | `/api/Culture/GetFilterablePaged` | Get paginated cultures with filtering |
| GET | `/api/Culture/GetSelectList` | Get cultures for dropdown lists |

## 🧪 Testing

### Running Unit Tests

```bash
# Note: Test projects need to be added
dotnet test
```

### API Testing

Use the interactive API documentation at `/swagger` or `/scalar/v1` to test endpoints, or use tools like:
- Postman
- curl
- HTTPie

Example: Create a new translation

```bash
curl -X POST "https://localhost:7000/api/Translation/Create" \
  -H "Content-Type: application/json" \
  -d '{
    "key": "welcome_message",
    "value": "Welcome to our application!",
    "culture": "en-US"
  }'
```

## 🐳 Docker Support

### Using Docker Compose (Recommended)

Create a `docker-compose.yml` file:

```yaml
version: '3.8'

services:
  translation-provider-api:
    build: .
    ports:
      - "5000:8080"
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Server=sqlserver;Database=TranslationProviderDb;User=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=true;
    depends_on:
      - sqlserver

  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourStrong@Passw0rd
    ports:
      - "1433:1433"
    volumes:
      - sqlserver_data:/var/opt/mssql

volumes:
  sqlserver_data:
```

### Build and Run

```bash
docker-compose up --build
```

## 🧱 Framework Dependencies

This project uses the **Zamin Framework** version 9.0.0, which provides:

- Domain-Driven Design building blocks
- CQRS and Event Sourcing infrastructure
- Cross-cutting concerns (logging, caching, validation)
- Message bus and event handling
- User management extensions

For more information about Zamin Framework, visit: [Zamin Documentation](https://github.com/oroumand/Zamin)

## 📦 Key Dependencies

- **Zamin.EndPoints.Web**: Web API infrastructure
- **Microsoft.EntityFrameworkCore**: ORM for data access
- **Scalar.AspNetCore**: Modern API documentation
- **Serilog**: Structured logging
- **FluentValidation**: Input validation
- **AutoMapper**: Object mapping

## 🔧 Development

### Project Structure Guidelines

- **Domain Layer**: Contains business logic, entities, value objects, and domain events
- **Application Layer**: Contains use cases, DTOs, and validation rules
- **Infrastructure Layer**: Contains data access, external service integrations
- **API Layer**: Contains controllers, middleware, and configuration

### Adding New Features

1. **Domain First**: Start with domain entities and business rules
2. **Contracts**: Define DTOs, commands, queries, and validators
3. **Handlers**: Implement command and query handlers
4. **Controllers**: Add API endpoints
5. **Tests**: Write comprehensive tests

### Code Style

- Follow C# naming conventions
- Use nullable reference types
- Implement async/await patterns
- Add XML documentation for public APIs
- Follow SOLID principles

## 🚀 Deployment

### Production Considerations

1. **Configuration**: Use environment variables or Azure Key Vault for sensitive data
2. **Database**: Use connection pooling and read replicas for scaling
3. **Logging**: Configure structured logging with appropriate log levels
4. **Monitoring**: Implement health checks and metrics
5. **Security**: Enable HTTPS, authentication, and authorization
6. **Caching**: Configure distributed caching for performance

### Environment Variables

```bash
export ASPNETCORE_ENVIRONMENT=Production
export ConnectionStrings__DefaultConnection="your-production-connection-string"
export ApplicationName="Translation Provider"
export ServiceId="translation-provider"
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Amirhossein Tayyar**

## 🙏 Acknowledgments

- [Zamin Framework](https://github.com/oroumand/Zamin) for providing the foundation infrastructure
- Clean Architecture principles by Robert C. Martin
- Domain-Driven Design concepts by Eric Evans

---

For questions or support, please open an issue in this repository.