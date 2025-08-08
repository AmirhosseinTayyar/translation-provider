# Contributing to Translation Provider

Thank you for your interest in contributing to the Translation Provider project! This document provides guidelines and instructions for contributing.

## Table of Contents

- [Getting Started](#getting-started)
- [Development Setup](#development-setup)
- [Code Style and Standards](#code-style-and-standards)
- [Architecture Guidelines](#architecture-guidelines)
- [Testing Guidelines](#testing-guidelines)
- [Pull Request Process](#pull-request-process)
- [Issue Reporting](#issue-reporting)
- [Documentation](#documentation)

## Getting Started

### Prerequisites

Before contributing, ensure you have:
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed
- Basic understanding of Clean Architecture principles
- Familiarity with Domain-Driven Design (DDD)
- Knowledge of C# and ASP.NET Core

### Setting Up Development Environment

1. Fork the repository on GitHub
2. Clone your fork locally:
   ```bash
   git clone https://github.com/YOUR_USERNAME/translation-provider.git
   cd translation-provider
   ```
3. Follow the [Development Setup Guide](docs/DEVELOPMENT.md)
4. Create a new branch for your feature:
   ```bash
   git checkout -b feature/your-feature-name
   ```

## Development Setup

Refer to the detailed [Development Setup Guide](docs/DEVELOPMENT.md) for complete setup instructions.

Quick setup:
```bash
# Restore packages
dotnet restore

# Build the solution
dotnet build

# Run the application
cd src/3.Endpoints/API
dotnet run
```

## Code Style and Standards

### C# Coding Standards

#### Naming Conventions
- **Classes**: PascalCase (`TranslationService`)
- **Methods**: PascalCase (`CreateTranslation`)
- **Properties**: PascalCase (`TranslationKey`)
- **Fields**: camelCase with underscore prefix (`_translationRepository`)
- **Parameters**: camelCase (`translationId`)
- **Local variables**: camelCase (`newTranslation`)
- **Constants**: PascalCase (`MAX_TRANSLATION_LENGTH`)

#### Code Organization
```csharp
namespace TranslationProvider.Core.Domain.Translations.Entities;

public sealed class Translation : AggregateRoot<int>
{
    #region Constants
    public const string TRANSLATION = nameof(TRANSLATION);
    #endregion

    #region Properties
    public TranslationKey Key { get; private set; } = default!;
    public TranslationValue Value { get; private set; } = default!;
    #endregion

    #region Constructors
    private Translation() { }
    #endregion

    #region Commands
    public static Translation Create(TranslationCreateParameter parameter) => new(parameter);
    #endregion
}
```

#### Best Practices

1. **Use nullable reference types**:
   ```csharp
   public string? OptionalProperty { get; set; }
   public string RequiredProperty { get; set; } = default!;
   ```

2. **Prefer immutability**:
   ```csharp
   public sealed record TranslationKey
   {
       public string Value { get; init; }
       
       private TranslationKey(string value) => Value = value;
       
       public static TranslationKey FromString(string value) => new(value);
   }
   ```

3. **Use explicit interface implementations when appropriate**:
   ```csharp
   public sealed class TranslationRepository : ITranslationRepository
   {
       public async Task<Translation?> GetByIdAsync(Guid id) { ... }
   }
   ```

4. **Follow async/await patterns**:
   ```csharp
   public async Task<IActionResult> CreateAsync(TranslationCreateCommand command)
   {
       var result = await _mediator.Send(command);
       return Ok(result);
   }
   ```

### File Organization

#### Project Structure Rules
- Place domain entities in `src/1.Core/Domain/{Aggregate}/Entities/`
- Place value objects in `src/1.Core/Domain/{Aggregate}/ValueObjects/`
- Place domain events in `src/1.Core/Domain/{Aggregate}/Events/`
- Place commands/queries in `src/1.Core/Contracts/{Aggregate}/Commands|Queries/`
- Place handlers in `src/1.Core/ApplicationService/{Aggregate}/Commands|Queries/`

#### File Naming
- One class per file
- File name matches class name exactly
- Use meaningful and descriptive names

## Architecture Guidelines

### Clean Architecture Layers

1. **Domain Layer** (`src/1.Core/Domain/`)
   - Contains business entities, value objects, domain events
   - No dependencies on other layers
   - Pure business logic only

2. **Application Layer** (`src/1.Core/`)
   - **Contracts**: DTOs, commands, queries, validators
   - **ApplicationService**: Command/query handlers
   - Depends only on Domain layer

3. **Infrastructure Layer** (`src/2.Infra/`)
   - Data access implementations
   - External service integrations
   - Depends on Application layer

4. **API Layer** (`src/3.Endpoints/`)
   - Controllers and API configuration
   - Depends on Application and Infrastructure layers

### Domain-Driven Design Patterns

#### Aggregate Roots
```csharp
public sealed class Translation : AggregateRoot<int>
{
    // Aggregate root should protect business invariants
    // All modifications should go through the aggregate root
    public void Update(TranslationUpdateParameter parameter)
    {
        // Validate business rules
        // Update properties
        // Raise domain events
    }
}
```

#### Value Objects
```csharp
public sealed record TranslationKey
{
    public string Value { get; init; }
    
    private TranslationKey(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Translation key cannot be empty");
            
        Value = value;
    }
    
    public static TranslationKey FromString(string value) => new(value);
    
    public static implicit operator string(TranslationKey key) => key.Value;
}
```

#### Domain Events
```csharp
public sealed record TranslationCreated(
    Guid BusinessId,
    string Key,
    string Value,
    string Culture) : IDomainEvent;
```

### CQRS Pattern

#### Commands (Write Operations)
```csharp
public sealed record TranslationCreateCommand(
    string Key,
    string Value,
    string Culture) : ICommand<Guid>;

public sealed class TranslationCreateHandler : ICommandHandler<TranslationCreateCommand, Guid>
{
    public async Task<Guid> Handle(TranslationCreateCommand request, CancellationToken cancellationToken)
    {
        // Handle command logic
    }
}
```

#### Queries (Read Operations)
```csharp
public sealed record TranslationGetByIdQuery(Guid BusinessId) : IQuery<TranslationQr?>;

public sealed class TranslationGetByIdHandler : IQueryHandler<TranslationGetByIdQuery, TranslationQr?>
{
    public async Task<TranslationQr?> Handle(TranslationGetByIdQuery request, CancellationToken cancellationToken)
    {
        // Handle query logic
    }
}
```

## Testing Guidelines

### Unit Tests
- Test domain logic in isolation
- Mock external dependencies
- Follow AAA pattern (Arrange, Act, Assert)

```csharp
[Test]
public void Translation_Create_ShouldCreateWithValidParameters()
{
    // Arrange
    var parameter = new TranslationCreateParameter
    {
        Key = "test_key",
        Value = "Test Value",
        Culture = "en-US"
    };

    // Act
    var translation = Translation.Create(parameter);

    // Assert
    Assert.That(translation.Key.Value, Is.EqualTo("test_key"));
    Assert.That(translation.Value.Value, Is.EqualTo("Test Value"));
    Assert.That(translation.Culture.Value, Is.EqualTo("en-US"));
}
```

### Integration Tests
- Test API endpoints end-to-end
- Use test database
- Verify complete request/response cycle

```csharp
[Test]
public async Task CreateTranslation_ShouldReturnCreatedId()
{
    // Arrange
    var command = new TranslationCreateCommand("test_key", "Test Value", "en-US");

    // Act
    var response = await _client.PostAsJsonAsync("/api/Translation/Create", command);
    var result = await response.Content.ReadFromJsonAsync<ApiResponse<Guid>>();

    // Assert
    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    Assert.That(result.IsSuccess, Is.True);
    Assert.That(result.Data, Is.Not.EqualTo(Guid.Empty));
}
```

### Test Organization
- Create test projects following the same structure as main projects
- Use meaningful test names that describe the scenario
- Group related tests in test classes
- Use test fixtures for setup/teardown

## Pull Request Process

### Before Creating a Pull Request

1. **Ensure your code follows the style guidelines**
2. **Write or update tests** for your changes
3. **Update documentation** if needed
4. **Run all tests** locally to ensure they pass
5. **Build the solution** to ensure no compilation errors

### Pull Request Checklist

- [ ] Code follows the project's coding standards
- [ ] Tests are included and passing
- [ ] Documentation is updated (if applicable)
- [ ] Commit messages are clear and descriptive
- [ ] No merge conflicts with the target branch
- [ ] PR description clearly explains the changes

### Pull Request Template

```markdown
## Description
Brief description of the changes.

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Testing
- [ ] Unit tests added/updated
- [ ] Integration tests added/updated
- [ ] Manual testing completed

## Checklist
- [ ] Code follows style guidelines
- [ ] Self-review completed
- [ ] Documentation updated
- [ ] Tests pass locally
```

### Review Process

1. **Automated checks** must pass (build, tests, linting)
2. **Code review** by at least one maintainer
3. **Address feedback** and update PR as needed
4. **Final approval** before merging

## Issue Reporting

### Bug Reports

Use the bug report template:

```markdown
**Bug Description**
A clear description of the bug.

**Steps to Reproduce**
1. Go to '...'
2. Click on '....'
3. See error

**Expected Behavior**
What you expected to happen.

**Actual Behavior**
What actually happened.

**Environment**
- OS: [e.g. Windows 11]
- .NET Version: [e.g. 9.0]
- Browser: [if applicable]

**Additional Context**
Any other context about the problem.
```

### Feature Requests

Use the feature request template:

```markdown
**Feature Description**
A clear description of the feature you'd like to see.

**Use Case**
Explain the use case and why this feature would be valuable.

**Proposed Solution**
Describe your preferred solution.

**Alternatives Considered**
Describe alternative solutions you've considered.

**Additional Context**
Any other context about the feature request.
```

## Documentation

### Code Documentation

- **XML Documentation** for public APIs:
  ```csharp
  /// <summary>
  /// Creates a new translation with the specified parameters.
  /// </summary>
  /// <param name="parameter">The parameters for creating the translation.</param>
  /// <returns>A new translation instance.</returns>
  /// <exception cref="ArgumentNullException">Thrown when parameter is null.</exception>
  public static Translation Create(TranslationCreateParameter parameter)
  ```

- **README files** for each major component
- **API documentation** using OpenAPI/Swagger annotations
- **Architecture decision records** for significant design decisions

### Documentation Standards

- Use clear, concise language
- Include code examples where appropriate
- Keep documentation up-to-date with code changes
- Use proper markdown formatting

## Development Workflow

### Git Workflow

1. **Main branch**: Always stable, ready for production
2. **Feature branches**: For new features or bug fixes
3. **Release branches**: For preparing releases (if needed)

### Branch Naming

- Feature: `feature/description` (e.g., `feature/add-batch-translation`)
- Bug fix: `bugfix/description` (e.g., `bugfix/fix-culture-validation`)
- Hotfix: `hotfix/description` (e.g., `hotfix/critical-security-fix`)

### Commit Messages

Follow conventional commit format:

```
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]
```

Types:
- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, etc.)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

Examples:
```
feat(translation): add batch translation creation endpoint

Add new endpoint for creating multiple translations at once.
Includes validation and error handling for batch operations.

Closes #123
```

## Questions and Support

- **GitHub Issues**: For bugs, feature requests, and questions
- **Discussions**: For general questions and community discussions
- **Documentation**: Check existing documentation first

## License

By contributing to this project, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to Translation Provider! 🚀