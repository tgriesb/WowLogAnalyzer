# WowLogAnalyzer

RESTful API for analyzing World of Warcraft combat logs. Upload and parse WoW combat log files to track player performance, encounter statistics, damage/healing metrics, and more.

## Features

- **Combat Log Parsing**: Upload and parse WoW combat log files with support for all major event types
- **Encounter Tracking**: Automatically detect and track boss encounters with success/failure status
- **Player Statistics**: Track damage, healing, and absorb metrics per player
- **Character Management**: Automatically create character profiles from log data
- **User Authentication**: JWT-based authentication with secure user management
- **RESTful API**: Clean API endpoints for log upload, retrieval, and analysis

## API Documentation

The backend provides a comprehensive REST API documented via Swagger UI.

### Key Endpoints

- **POST /api/log/upload**: Upload a combat log file (.txt).
- **GET /api/log**: Retrieve uploaded logs for the current user.
- **GET /api/log/encounters/{logId}**: Get all encounters detected in a log.
- **GET /api/log/encounter/{encounterId}**: Get detailed statistics for a specific encounter.
- **GET /api/log/encounter-statistics-by-interval/{encounterId}**: Get time-series data for graphs.

### Authentication

All API endpoints (except login/register) require a valid JWT token in the `Authorization` header:
`Authorization: Bearer <your-token>`


## Getting Started

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd WowLogAnalyzer/backend/src
   ```

2. **Configure environment variables**
   Create a `.env` file in `backend/src/`:
   ```env
   Database__DefaultConnection=Host=localhost;Port=5432;Database=wow_log_analyzer;Username=postgres;Password=yourpassword;Include Error Detail=true;Persist Security Info=true
   Jwt__Key=your-super-secret-jwt-key-at-least-32-characters-long-base64-encoded
   ASPNETCORE_ENVIRONMENT=Development
   ```

   **Generate a secure JWT key:**
   ```bash
   # Using PowerShell
   [Convert]::ToBase64String((1..32 | ForEach-Object { Get-Random -Maximum 256 }))
   
   # Using OpenSSL (Linux/Mac)
   openssl rand -base64 32
   
   # Using Node.js
   node -e "console.log(require('crypto').randomBytes(32).toString('base64'))"
   ```

3. **Install dependencies**
   ```bash
   dotnet restore
   ```

4. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the backend**
   ```bash
   dotnet run
   ```
   