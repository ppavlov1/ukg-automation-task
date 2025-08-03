# TEST PLAN – UKG LIBRARY AUTOMATION PROJECT

# 1. Overview
This test plan outlines the approach, strategy, scope, and deliverables for testing the **Library Management System**. Testing will be performed using a combination of **automated UI/API scripts** and **manual test cases** to ensure system reliability and functional correctness.

# 2. Objectives
- Verify that all major user flows (Login, User Management, Book Management, Book Borrowing) work as intended.
- Ensure that API endpoints respond correctly with expected status codes and payloads.
- Establish regression coverage through automated tests to support continuous delivery.
- Identify and report defects found during exploratory and structured testing.

# 3. Scope

# In Scope
- Functional testing of:
  - Login
  - Users module
  - Books module
  - GetBook module
- API endpoint validation (`/api/Users`, `/api/Books`, `/api/GetBook`)
- UI testing with Selenium (validations, flows, UI state)
- Test automation using C# with NUnit
- Manual testing and bug reporting
- Use of mocked data for test coverage via Faker

# Out of Scope
- Load/performance testing
- Security testing (XSS, auth bypass, etc.)
- Internationalization (i18n) or localization (L10n) validation
- Browser compatibility beyond Chromium-based browsers

# 4. Tools & Technology

| Purpose              | Tool                     |
|----------------------|--------------------------|
| UI Testing           | Selenium WebDriver (C#)  |
| API Testing          | RestSharp                |
| Test Framework       | NUnit                    |
| Test Data Generation | Bogus / Faker (C#)       |
| HTTP Manual Testing  | Postman                  |
| Assertions           | NUnit Assertions         |
| Dev Environment      | Visual Studio 2022, .NET 8 |
| Version Control      | Git (GitHub)             |

# 5. Repository Structure

```
ukg-automation-task/
├── AutomationTests/      # UI + API test automation (C#, NUnit)
├── PostmanTests/         # Postman collection and environment
├── TestPlan/             # This file and related docs
├── TestCases/            # Manual test cases (Excel / Markdown)
├── BugReports/           # Top 5 defects with repro steps
└── README.md             # Project overview
```

# 6. Test Artifacts

| Artifact           | Description                             |
|--------------------|------------------------------------------|
| Test Plan          | This document (full & summarized)        |
| Test Cases         | Scenario-based test cases (positive, negative) |
| Automation Suite   | Covers critical flows for UI and API     |
| Bug Reports        | Reproducible issues with screenshots/logs |
| Postman Collection | REST tests + environments for `/api`     |

# 7. Types of Testing

| Type            | Scope                                      |
|------------------|--------------------------------------------|
| Functional       | CRUD operations, navigation flows          |
| UI Testing       | Login, Users, Books, Borrow Book           |
| API Testing      | Status codes, schema, response validation  |
| Negative Testing | Invalid inputs, missing required fields    |

# 8. Entry & Exit Criteria

# Entry Criteria
- The environment is stable and accessible.
- API and UI endpoints are deployed and available.
- Required credentials are known/configured.

# Exit Criteria
- All critical and high-priority test cases are executed and passed.
- No P1 or P2 severity bugs remain open.
- All automation runs are green or failures are investigated/documented.

# 9. Test Schedule

| Phase                  | Estimated Time     |
|------------------------|--------------------|
| Environment Setup      | 1 day              |
| Automation Framework Setup | 1 day          |
| Manual Test Case Design| 1 day              |
| Automation Development | 2–3 days           |
| Manual Execution       | 1 day              |
| Bug Reporting & Retest | As needed          |
| Final Verification     | 1 day              |

# 10. Roles & Responsibilities

| Role           | Name / Responsibility         |
|----------------|-------------------------------|
| QA Engineer    | Pavel Pavlov                  |
| Automation Dev | Pavel Pavlov                  |

# 11. Test Data

- All test data is dynamically generated using `Bogus` (Faker).
- User names, book titles, authors, genres, and quantities are randomized.
- Sensitive data is not stored; test users and books are isolated per test.

# 12. Defect Management

- Bugs are documented with:
  - Unique title
  - Priority/severity
  - Steps to reproduce
  - Expected vs actual result
  - Screenshot/log if applicable
- Located in `/BugReports/` directory.

# 13. Reporting & Review

- Manual test case execution will be marked pass/fail in the Excel files.
- Automated test results are visible via `dotnet test` output.
- Postman results are validated manually via collection runner or Newman.