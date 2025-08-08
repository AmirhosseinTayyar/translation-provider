# Translation Provider API Documentation

This document provides detailed information about the Translation Provider REST API endpoints.

## Base URL

- **Development**: `https://localhost:7000/api`
- **Production**: `https://your-domain.com/api`

## Authentication

> **Note**: Currently, the API endpoints are configured without authentication except for the `GetLocalizationRecords` endpoint which allows anonymous access. In production, implement proper authentication using JWT tokens or API keys.

## Content Type

All requests should use `application/json` content type for POST and PUT operations.

## Response Format

All responses follow a consistent format:

### Success Response
```json
{
  "data": { ... },
  "isSuccess": true,
  "messages": []
}
```

### Error Response
```json
{
  "data": null,
  "isSuccess": false,
  "messages": [
    {
      "message": "Error description",
      "code": "ERROR_CODE"
    }
  ]
}
```

## Translation Management

### Create Translation

Creates a new translation entry.

**Endpoint**: `POST /api/Translation/Create`

**Request Body**:
```json
{
  "key": "string",
  "value": "string",
  "culture": "string"
}
```

**Parameters**:
- `key` (string, required): Unique identifier for the translation
- `value` (string, required): The translated text
- `culture` (string, required): Culture code (e.g., "en-US", "fr-FR")

**Response**: Returns the created translation's GUID identifier.

**Example**:
```bash
curl -X POST "https://localhost:7000/api/Translation/Create" \
  -H "Content-Type: application/json" \
  -d '{
    "key": "welcome_message",
    "value": "Welcome to our application!",
    "culture": "en-US"
  }'
```

**Response**:
```json
{
  "data": "123e4567-e89b-12d3-a456-426614174000",
  "isSuccess": true,
  "messages": []
}
```

### Update Translation

Updates an existing translation entry.

**Endpoint**: `PUT /api/Translation/Update`

**Request Body**:
```json
{
  "businessId": "string",
  "key": "string",
  "value": "string",
  "culture": "string"
}
```

**Parameters**:
- `businessId` (string, required): GUID identifier of the translation to update
- `key` (string, required): Updated translation key
- `value` (string, required): Updated translated text
- `culture` (string, required): Updated culture code

**Response**: Returns 204 No Content on success.

### Delete Translation

Deletes a translation entry.

**Endpoint**: `DELETE /api/Translation/Delete`

**Query Parameters**:
- `businessId` (string, required): GUID identifier of the translation to delete

**Example**:
```bash
curl -X DELETE "https://localhost:7000/api/Translation/Delete?businessId=123e4567-e89b-12d3-a456-426614174000"
```

**Response**: Returns 204 No Content on success.

### Get Translation by ID

Retrieves a specific translation by its identifier.

**Endpoint**: `GET /api/Translation/GetById`

**Query Parameters**:
- `businessId` (string, required): GUID identifier of the translation

**Example**:
```bash
curl "https://localhost:7000/api/Translation/GetById?businessId=123e4567-e89b-12d3-a456-426614174000"
```

**Response**:
```json
{
  "data": {
    "businessId": "123e4567-e89b-12d3-a456-426614174000",
    "key": "welcome_message",
    "value": "Welcome to our application!",
    "culture": "en-US",
    "createdDate": "2024-01-15T10:30:00Z",
    "modifiedDate": "2024-01-15T10:30:00Z"
  },
  "isSuccess": true,
  "messages": []
}
```

### Get Filtered and Paged Translations

Retrieves a paginated list of translations with optional filtering.

**Endpoint**: `GET /api/Translation/GetFilterablePaged`

**Query Parameters**:
- `pageIndex` (integer, required): Page number (1-based)
- `pageSize` (integer, required): Number of items per page (max 100)
- `key` (string, optional): Filter by translation key (partial match)
- `culture` (string, optional): Filter by culture code
- `value` (string, optional): Filter by translation value (partial match)

**Example**:
```bash
curl "https://localhost:7000/api/Translation/GetFilterablePaged?pageIndex=1&pageSize=10&culture=en-US"
```

**Response**:
```json
{
  "data": {
    "items": [
      {
        "businessId": "123e4567-e89b-12d3-a456-426614174000",
        "key": "welcome_message",
        "value": "Welcome to our application!",
        "culture": "en-US"
      }
    ],
    "totalCount": 1,
    "pageIndex": 1,
    "pageSize": 10,
    "totalPages": 1
  },
  "isSuccess": true,
  "messages": []
}
```

### Get Localization Records

Retrieves localization data for frontend applications. This endpoint allows anonymous access.

**Endpoint**: `GET /api/Translation/GetLocalizationRecords`

**Query Parameters**:
- `culture` (string, optional): Filter by culture code
- `keyPrefix` (string, optional): Filter by key prefix

**Example**:
```bash
curl "https://localhost:7000/api/Translation/GetLocalizationRecords?culture=en-US"
```

**Response**:
```json
{
  "data": [
    {
      "key": "welcome_message",
      "value": "Welcome to our application!",
      "culture": "en-US"
    },
    {
      "key": "goodbye_message",
      "value": "Thank you for using our application!",
      "culture": "en-US"
    }
  ],
  "isSuccess": true,
  "messages": []
}
```

## Culture Management

### Create Culture

Creates a new culture configuration.

**Endpoint**: `POST /api/Culture/Create`

**Request Body**:
```json
{
  "name": "string",
  "displayName": "string",
  "isDefault": false,
  "isActive": true
}
```

**Parameters**:
- `name` (string, required): Culture code (e.g., "en-US", "fr-FR")
- `displayName` (string, required): Human-readable culture name
- `isDefault` (boolean, optional): Whether this is the default culture
- `isActive` (boolean, optional): Whether the culture is active

**Example**:
```bash
curl -X POST "https://localhost:7000/api/Culture/Create" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "en-US",
    "displayName": "English (United States)",
    "isDefault": true,
    "isActive": true
  }'
```

### Update Culture

Updates an existing culture configuration.

**Endpoint**: `PUT /api/Culture/Update`

**Request Body**:
```json
{
  "businessId": "string",
  "name": "string",
  "displayName": "string",
  "isDefault": false,
  "isActive": true
}
```

### Delete Culture

Deletes a culture configuration.

**Endpoint**: `DELETE /api/Culture/Delete`

**Query Parameters**:
- `businessId` (string, required): GUID identifier of the culture to delete

### Enable Culture

Enables a culture for use.

**Endpoint**: `PUT /api/Culture/Enable`

**Request Body**:
```json
{
  "businessId": "string"
}
```

### Disable Culture

Disables a culture.

**Endpoint**: `PUT /api/Culture/Disable`

**Request Body**:
```json
{
  "businessId": "string"
}
```

### Get Culture by ID

Retrieves a specific culture by its identifier.

**Endpoint**: `GET /api/Culture/GetById`

**Query Parameters**:
- `businessId` (string, required): GUID identifier of the culture

### Get Filtered and Paged Cultures

Retrieves a paginated list of cultures with optional filtering.

**Endpoint**: `GET /api/Culture/GetFilterablePaged`

**Query Parameters**:
- `pageIndex` (integer, required): Page number (1-based)
- `pageSize` (integer, required): Number of items per page
- `name` (string, optional): Filter by culture name
- `isActive` (boolean, optional): Filter by active status

### Get Culture Select List

Retrieves a list of cultures for dropdown/select components.

**Endpoint**: `GET /api/Culture/GetSelectList`

**Query Parameters**:
- `activeOnly` (boolean, optional): Return only active cultures (default: true)

**Example**:
```bash
curl "https://localhost:7000/api/Culture/GetSelectList?activeOnly=true"
```

**Response**:
```json
{
  "data": [
    {
      "value": "en-US",
      "text": "English (United States)",
      "selected": true
    },
    {
      "value": "fr-FR",
      "text": "French (France)",
      "selected": false
    }
  ],
  "isSuccess": true,
  "messages": []
}
```

## Error Codes

### Common Error Codes

- `VALIDATION_ERROR`: Input validation failed
- `NOT_FOUND`: Requested resource not found
- `DUPLICATE_KEY`: Attempting to create a duplicate resource
- `BUSINESS_RULE_VIOLATION`: Business logic constraint violated
- `UNAUTHORIZED`: Authentication required
- `FORBIDDEN`: Insufficient permissions
- `INTERNAL_ERROR`: Server error occurred

### Validation Error Example

```json
{
  "data": null,
  "isSuccess": false,
  "messages": [
    {
      "message": "Translation key is required",
      "code": "VALIDATION_ERROR",
      "field": "key"
    },
    {
      "message": "Culture code must be valid",
      "code": "VALIDATION_ERROR", 
      "field": "culture"
    }
  ]
}
```

## Rate Limiting

> **Note**: Implement rate limiting in production environments to prevent abuse.

Recommended limits:
- 1000 requests per hour per IP for read operations
- 100 requests per hour per IP for write operations

## Caching

The API implements caching for frequently accessed data:
- Culture lists are cached for 1 hour
- Translation lookups are cached for 30 minutes
- Localization records are cached for 1 hour

Cache headers are included in responses:
```
Cache-Control: public, max-age=3600
ETag: "abc123def456"
```

## Pagination

All paginated endpoints support the following parameters:
- `pageIndex`: 1-based page number (minimum: 1)
- `pageSize`: Items per page (minimum: 1, maximum: 100, default: 20)

Pagination responses include:
```json
{
  "items": [...],
  "totalCount": 100,
  "pageIndex": 1,
  "pageSize": 20,
  "totalPages": 5,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

## CORS

The API supports CORS for cross-origin requests. Configure allowed origins in production:

```json
{
  "AllowedOrigins": [
    "https://yourdomain.com",
    "https://app.yourdomain.com"
  ]
}
```

## Health Checks

**Endpoint**: `GET /health`

Returns the health status of the application and its dependencies.

**Response**:
```json
{
  "status": "Healthy",
  "totalDuration": "00:00:00.123",
  "entries": {
    "database": {
      "status": "Healthy",
      "duration": "00:00:00.045"
    }
  }
}
```

## OpenAPI/Swagger Documentation

Interactive API documentation is available at:
- **Swagger UI**: `/swagger`
- **Scalar UI**: `/scalar/v1`
- **OpenAPI JSON**: `/swagger/v1/swagger.json`

## SDK and Client Libraries

### JavaScript/TypeScript

```javascript
// Example using fetch
const createTranslation = async (translation) => {
  const response = await fetch('/api/Translation/Create', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(translation),
  });
  
  return await response.json();
};
```

### C#

```csharp
// Example using HttpClient
var client = new HttpClient { BaseAddress = new Uri("https://localhost:7000") };

var translation = new { 
  key = "hello", 
  value = "Hello!", 
  culture = "en-US" 
};

var response = await client.PostAsJsonAsync("/api/Translation/Create", translation);
var result = await response.Content.ReadFromJsonAsync<ApiResponse<Guid>>();
```

## Best Practices

1. **Use appropriate HTTP methods**: GET for reading, POST for creating, PUT for updating, DELETE for removing
2. **Handle errors gracefully**: Always check the `isSuccess` field in responses
3. **Implement retry logic**: For transient failures, implement exponential backoff
4. **Cache responses**: Use ETags and cache headers for better performance
5. **Validate input**: Always validate data on the client side before sending requests
6. **Use pagination**: Don't request all data at once, use pagination for large datasets
7. **Monitor usage**: Implement logging and monitoring for production environments

## Support

For API support and questions:
- Create an issue in the GitHub repository
- Check the interactive documentation at `/swagger`
- Review the development setup guide

---

*This documentation is automatically generated from the OpenAPI specification and updated with each release.*