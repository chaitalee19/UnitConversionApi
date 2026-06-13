# Unit Conversion API

## Overview

This project is an ASP.NET Core Web API that converts numerical values between different units of measurement.

The API supports multiple conversion categories including:

* Length
* Weight/Mass
* Temperature
* Area
* Volume
* Time

The solution is designed with a service-based architecture and can be easily extended to support additional units and conversion categories in the future.

---

## Technologies Used

* ASP.NET Core 8
* C#
* Swagger/OpenAPI

---

## Project Structure

```text
UnitConversionApi
│
├── Controllers
├── DTOs
├── Services
├── Constants
├── Middleware
├── Program.cs
└── README.md
```

---

## API Endpoint

### Convert Units

**POST**

```http
/api/Conversion/convert
```

### Sample Request

```json
{
  "category": "Length",
  "fromUnit": "Meter",
  "toUnit": "Foot",
  "value": 10
}
```

### Sample Response

```json
{
  "originalValue": 10,
  "fromUnit": "Meter",
  "toUnit": "Foot",
  "convertedValue": 32.8084
}
```

---

## Supported Categories

### Length

* Meter
* Kilometer
* Centimeter
* Millimeter
* Foot
* Inch
* Yard

### Weight

* Kilogram
* Gram
* Milligram
* Pound

### Temperature

* Celsius
* Fahrenheit
* Kelvin

### Area

* SquareMeter
* SquareKilometer
* SquareFoot
* SquareInch
* Acre

### Volume

* Liter
* Milliliter
* CubicMeter
* Gallon

### Time

* Second
* Minute
* Hour
* Day

---

## Validation

The API validates:

* Required fields
* Invalid categories
* Invalid units
* Same source and target units
* Values less than or equal to zero

---

## Error Handling

Global exception handling middleware is implemented to provide consistent API error responses.

---

## Running the Application

### Clone Repository

```bash
git clone <repository-url>
```

### Navigate to Project

```bash
cd UnitConversionApi
```

### Restore Packages

```bash
dotnet restore
```

### Run Application

```bash
dotnet run
```

### Open Swagger

Navigate to:

```text
https://localhost:<port>/swagger
```

---

## Design Decisions

* Service layer used to separate business logic from controllers.
* Dependency Injection used for loose coupling and maintainability.
* Conversion factors are stored in dictionaries for simplicity.
* Solution is structured to allow easy addition of new units and categories.
* Case-insensitive unit handling improves usability.

---

## Future Improvements

* Store units and conversion factors in a database.
* Add authentication and authorization.
* Add caching for frequently used conversions.
* Add automated unit and integration tests.
* Support dynamic configuration of conversion categories.

```
```
