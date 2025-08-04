# AutomationTests
This repository contains an end-to-end test automation framework for the **Library Management System** covering both **UI** and **API** testing using C#, Selenium, RestSharp, and NUnit.

---
# Tech Stack

| Layer      | Technology                 |
|------------|----------------------------|
| UI Testing | Selenium WebDriver + NUnit |
| API Testing| RestSharp + Newtonsoft.Json|
| Test Data  | Bogus (Faker)              |
| Assertions | NUnit                      |
| Build Tool | .NET 8 SDK                 |

---
# Project Structure
```
ukg-library-automation/
├── AutomationTests/
│ ├── Pages/ # Page Object Model classes for UI
│ ├── Services/ # API service connectors
│ ├── Models/ # DTOs and response models
│ ├── Tests/
│ │ ├── UI/ # UI test cases
│ │ └── API/ # API test cases
│ ├── Utilities/ # Helpers
│ ├── appsettings.json # Config file for URLs and credentials
│ └── AutomationTests.csproj
```
---
# Configuration

Edit `appsettings.json` with the appropriate values:

json
{
  "BaseUrl": "http://localhost:5000",
  "Username": "admin",
  "Password": "123456"
}

🚀 Running the Tests
✅ Run All Tests
dotnet test

✅ Run Specific Category
dotnet test --filter TestCategory=UI
Or from Visual Studio Test Explorer.

 Features Covered
 - UI Tests
    Login
    Users Page
    Books Page

 - API Tests
    CRUD operations on /api/Users, /api/Books, /api/GetBook

Validations for responses and status codes

Test data created using Faker

# Requirements
.NET 8 SDK
