
# MyFunctionApp

## Overview

MyFunctionApp is an Azure Function App project created with .NET Core that includes Swagger support for API documentation. This project demonstrates how to set up an Azure Function with HTTP triggers, configure Swagger for API documentation, and deploy the function to Azure.

## Project Structure

```
MyFunctionApp/
├── host.json
├── local.settings.json
├── MyFunction.cs
├── MyFunctionApp.csproj
├── Startup.cs
└── README.md
```

### Files

- `host.json`: Contains configuration settings for the function app, including logging and OpenAPI (Swagger) settings.
- `local.settings.json`: Local configuration settings, including storage connection strings and runtime settings.
- `MyFunction.cs`: The main function file containing the HTTP trigger and Swagger annotations.
- `MyFunctionApp.csproj`: The project file that includes references to the necessary NuGet packages.
- `Startup.cs`: Contains the startup configuration for the function app, including Swagger setup.
- `README.md`: This file, providing an overview and instructions for the project.

## Prerequisites

- .NET Core SDK
- Azure Functions Core Tools
- Node.js (for installing Azure Functions Core Tools)
- Azure CLI

## Setup Instructions

### 1. Clone the Repository

```sh
git clone <repository-url>
cd MyFunctionApp
```

### 2. Install Azure Functions Core Tools

```sh
npm install -g azure-functions-core-tools@4 --unsafe-perm true
```

### 3. Restore NuGet Packages

```sh
dotnet restore
```

### 4. Run the Function App Locally

```sh
func start
```

### 5. Access Swagger UI

Open your browser and navigate to `http://localhost:7071/api/swagger/ui` to view the Swagger UI for your API.

## Configuration

### host.json

Contains OpenAPI settings for Swagger documentation:

```json
{
  "version": "2.0",
  "logging": {
    "applicationInsights": {
      "samplingSettings": {
        "isEnabled": true,
        "excludedTypes": "Request"
      },
      "enableLiveMetricsFilters": true
    }
  },
  "extensions": {
    "openapi": {
      "info": {
        "title": "My API",
        "version": "1.0.0"
      },
      "servers": [
        {
          "url": "http://localhost:7071",
          "description": "Local server"
        }
      ]
    }
  }
}
```

### local.settings.json

Contains local configuration settings:

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
    }
}
```

## Deployment

Deploy the function to Azure using the Azure CLI or Visual Studio. Refer to the [official documentation](https://learn.microsoft.com/en-us/cli/azure/functionapp/deployment?view=azure-cli-latest) for more details.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss any changes.

## License

This project is licensed under the MIT License.
