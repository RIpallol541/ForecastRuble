# Forecast Ruble Exchange Rate

## Overview

The **Ruble Exchange Rate Forecast** Project is an application designed to predict the exchange rate of the Russian ruble using historical data. This application is built on the principles of a clean architecture that provides separation of tasks, ease of maintenance and testing
## Features

- **Dynamic Forecasting**: Utilizes historical exchange rate data to predict future rates.
- **SQLite Database**: Lightweight and easy-to-use database for storing currency rates and predictions.
- **RESTful API**: Provides endpoints for accessing and managing currency rates and predictions.
- **Entity Framework Core**: Handles database operations and entity management.
- **Swagger Documentation**: Interactive API documentation for easy exploration and testing of endpoints.

## Architecture

This project follows the Clean Architecture approach, which separates the application into distinct layers:

- **Domain Layer**: Contains business logic and entities.
- **Application Layer**: Manages application services and interfaces.
- **Infrastructure Layer**: Handles data access and external services.
- **API Layer**: Provides a web API for client interaction.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQLite](https://www.sqlite.org/download.html)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ForecastRuble.git
   cd ForecastRuble
