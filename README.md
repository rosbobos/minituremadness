# Miniature Madness

### Table Of Contents
1. [Overview](#overview)
2. [Tools Used](#tools-used)
3. [Getting Started](#getting-started)
4. [Visuals](#visuals)
5. [Data Flow](#data-flow)
6. [Model Properties](#model-properties)
7. [Change Log](#change-log)
8. [Authors](#authors)

## Overview

Miniature Madness is a full-stack e-commerce web application.

Miniature Madness supports secure user-registration and login functionality. Users can browse a collection of products stored within a MSSQL database, view detailed information on each product, or choose to "purchase" products!

A user can select products that they wish to purchase, and add them to their Cart. They can then Checkout the items in their cart and purchase them through a designated payment method.

**_Note_**: _Purchases are simulated and do not register through any financial services or providers. Miniature Madness is a school project / demonstration application and is NOT a fully functioning e-commerce site with real products._

## Tools Used

- C#
- ASP.NET Core 3.1
- Visual Studio 2019
- Microsoft SQL Server
- Entity Framework Core
- ASP.NET Core MVC
- ASP.NET Core Razor Pages
- .NET Core Identity

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://github.com/YourRepo/YourProject.git
```

Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2019 to build the web application. The solution file is located in the MiniatureMadness subdirectory at the root of the repository.

```
$ cd MiniatureMadness/MiniatureMadness
$ dotnet build
```

The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:

```
Update-Database
```

Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:

```
$ cd MiniatureMadness/MiniatureMadness
$ dotnet run
```

Unit testing is included in the` MiniatureMadness/MMTests` project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

## Visuals

## Data Flow

## Data Model

## Model Properties

## Change Log

**0.2** - 20200421
- Initial migration complete on ApplicationDbContext.
- Registered UserSecrets file to store DB Connection Strings.
- Registered .NET Core Identity and created ApplicationDbContext.
- ApplicationUser model created to store user data.

**0.1** - 20200420
- Index View returns with rendered dummy text.
- Basic MVC application scaffolded.
- Project / Solution files created.

## Authors

**Rosalyn Johnson**
- GitHub
- LinkedIn

**Robert Nielsen**
- [GitHub](https://github.com/robertjnielsen)
- [LinkedIn](https://www.linkedin.com/in/robertjnielsen)