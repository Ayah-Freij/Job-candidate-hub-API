# Job Candidate Hub API

## Overview

This project is a .NET 8 API designed to manage candidate information, including their contact details, LinkedIn and GitHub profiles, and comments. The project follows the **Package by Feature** design pattern, which organizes the codebase by features rather than technical layers. This structure enhances modularity and scalability, making the codebase easier to maintain and extend.

## Project Structure

The project is structured into multiple folders, each representing a distinct feature of the application. 

### Package by Feature

The **Package by Feature** design pattern organizes the project by feature rather than technical layer. Each feature (e.g., Candidates, Users) contains its own controllers, models, services, and repositories. This approach has several advantages:

- **Modularity**: Features are self-contained, making them easier to understand and modify.
- **Scalability**: Adding new features is straightforward and doesn’t affect other parts of the application.
- **Testability**: Tests are closely associated with the features they are testing, leading to more maintainable test suites.

## Database: Code-First Approach

This project uses Entity Framework Core with a **Code-First** approach to manage the database schema. In a code-first approach, the database schema is generated based on the entity classes defined in the code. This allows for a more agile development process, as the database evolves alongside the application code.

### Running Migrations

To apply migrations and update the database schema, use the following commands:

1. **Add a Migration**:

   ```bash
   dotnet ef migrations add <MigrationName>
1. **Update the Database**:
   ```bash
    dotnet ef database update


## Testing
Unit testing is a crucial part of this project. The test suite is built using xUnit, with Moq as the mocking framework. Each feature has its own test folder, and the tests are closely associated with the corresponding services and repositories.

Running Tests
To run the tests, navigate to the test project directory and execute:

bash
Copy code
dotnet test
This command will discover and run all the tests in the project, providing a detailed output of the test results.

##.NET 8 Features
**This project takes advantage of the latest features provided by .NET 8, including:

Improved Performance: Optimizations at the runtime and language level.
Modern API Design: Leveraging new .NET 8 features for building efficient and scalable APIs.
Simplified Dependency Injection: Enhanced DI mechanisms for easier and more maintainable code.



### Key Sections:

- **Overview**: Provides a brief description of the project and its purpose.
- **Project Structure**: Explains the feature-by-package design pattern and how the project is organized.
- **Database: Code-First Approach**: Details how Entity Framework Core is used with a code-first approach.
- **Testing**: Describes the testing strategy and how to run tests.
- **.NET 8 Features**: Highlights some of the key benefits of using .NET 8 in this project.

This `README.md` file should serve as a comprehensive guide for anyone looking to understand or contribute to your project.



