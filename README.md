# 📚 UKG Library Platform - Automation Testing Project

This repository contains the complete solution for the **UKG Automation Task** focused on testing a Book Library web platform.
The project covers test planning, manual testing, API and UI automation, integration tests, and defect reporting.

---

## 🔗 Live URL & Credentials

- **Platform URL**: [https://qa-task.immedis.com/](https://qa-task.immedis.com/)
- **Username**: `admin`
- **Password**: `123456`
- **API Documentation**: [Postman Collection](https://documenter.getpostman.com/view/8102633/SWTHZukf)

---

## 📁 Project Structure

```bash
ukg-library-automation/
├── TestPlan/                  # Test strategy & planning (Excel or PDF)
├── ManualTests/               # Manual test cases (Excel, PDF, or Markdown)
├── BugReports/                # Top 5 issues with reproduction steps
├── PostmanTests/              # Postman collection with scripts and tests
├── ui-automation/             # UI automation project (e.g., with Selenium or Cypress)
├── integration-tests/         # API/Integration test automation (e.g., using REST Assured or similar)
└── README.md                  # This file


automation-tests/
├── Pages/
│   └── LoginPage.cs
├── Tests/
│   ├── UI/
│   │   └── LoginTests.cs
│   └── API/
│       └── LoginApiTests.cs
├── Utilities/
│   └── DriverFactory.cs
├── appsettings.json