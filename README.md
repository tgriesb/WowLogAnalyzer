# WowLogAnalyzer

RESTful API for analyzing World of Warcraft combat logs. Upload and parse WoW combat log files to track player performance, encounter statistics, damage/healing metrics, and more.

## Features

- **Combat Log Parsing**: Upload and parse WoW combat log files with support for all major event types
- **Encounter Tracking**: Automatically detect and track boss encounters with success/failure status
- **Player Statistics**: Track damage, healing, and absorb metrics per player
- **Character Management**: Automatically create character profiles from log data
- **User Authentication**: JWT-based authentication with secure user management
- **RESTful API**: Clean API endpoints for log upload, retrieval, and analysis


## Getting Started

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd WowLogAnalyzer/backend/src
   ```

2. **Configure the database**
   
   Update `appsettings.json` with your PostgreSQL connection string:
   ```json
   {
     "Database": {
       "DefaultConnection": "Host=localhost;Database=wowloganalyzer;Username=postgres;Password=yourpassword"
     },
     "Jwt": {
       "Key": "your-super-secret-jwt-key-at-least-32-characters-long"
     }
   }
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
   