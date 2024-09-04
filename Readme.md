# Trade Categorization System

This repository contains a C# implementation for categorizing trades based on predefined rules, along with unit tests and a T-SQL implementation using stored procedures.

## Features

- **Flexible Rule Engine:** Easily add, modify, or remove categorization rules to adapt to changing business requirements.
- **Clean Architecture:**  Uses interfaces, dependency injection, and well-defined classes for maintainability and testability.
- **ASP.NET Core Controller:** Includes an example ASP.NET Core controller for exposing the categorization logic via an API endpoint. 
- **T-SQL Implementation:**  Provides a SQL Server stored procedure solution for database-driven categorization.
- **Comprehensive Test Suite:**  Includes unit tests using MSTest to ensure code correctness and prevent regressions. 

## Getting Started

1. **Clone the Repository:** 
   ```bash
   git clone https://github.com/your-username/trade-categorization.git
Use code with caution.
Markdown
Project Structure:
TradeCategorization/: Contains the main C# project (e.g., a console app or ASP.NET Core project).
TradeCategorization.Tests/: Contains the unit test project.
Configuration:
C#: Update the TradeCategoryClassifier class and rule definitions to match your specific categorization logic.
Configure dependency injection in your application startup.
T-SQL:
Create the necessary tables (Trades, TradeCategories, CategorizedTrades) in your SQL Server database.
Adjust the categorization logic in the CategorizeTradesProc stored procedure if needed.
Running the Code:
C#: Build and run the C# project. The example controller can be used to test the API.
T-SQL: Execute the CategorizeTradesProc stored procedure in your SQL Server Management Studio (SSMS) or using your preferred method.
Running Tests:
Open the test project in Visual Studio and run the tests using the Test Explorer.
Code Example (C#)
// Example of using the TradeCategoryClassifier
var classifier = new TradeCategoryClassifier();
var trade = new Trade(1500000, "Public");
string category = classifier.CategorizeTrades(new List<ITrade> { trade })[0]; // "MEDIUMRISK"
Use code with caution.
C#
Contributing
Contributions are welcome! Please feel free to open issues or pull requests.
License
This project is licensed under the MIT License.
**Key Improvements:**

- **Clear Structure:**  Sections for features, getting started, code examples, contributions, and license.
- **Specific Steps:**  Provides step-by-step instructions for setup and running the code. 
- **Code Snippet:**  Includes a concise code example to demonstrate usage. 
- **Customization Guidance:**  Points out where to make modifications for specific needs (rules, configuration).
- **Contribution and License:**  Encourages community involvement and clarifies the licensing terms.