# Miniature Madness

### Table Of Contents
1. [Overview](#overview)
2. [Tools Used](#tools-used)
3. [Getting Started](#getting-started)
4. [Visuals](#visuals)
5. [Identity Claims](#identity-claims)
6. [Authors](#authors)

## Overview

#### We Are Deployed To Azure!
[Miniature Madness](https://miniaturemadness.azurewebsites.net/)

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

_**Note:** GitHub link not active at this time. MiniatureMadness is currently under development on a private Azure DevOps repo. Once MiniatureMadness has been finalized and released, the repo will be copied to GitHub, where this link will be updated if necessary, and will become valid._

```
$ git clone https://github.com/MiniatureMadnessE-Commerce/MiniatureMadness.git
```

Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2019 to build the web application. The solution file is located in the MiniatureMadness subdirectory at the root of the repository.

```
$ cd MiniatureMadness/MiniatureMadness
$ dotnet build
```

The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:

```
Update-Database -Context ApplicationDbContext
Update-Database -Context StoreDBContext
```

Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:

```
$ cd MiniatureMadness/MiniatureMadness
$ dotnet run
```

Unit testing is included in the` MiniatureMadness/MiniatureMadnessTests` project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

## Visuals

## Identity Claims

MinionMadness currently makes use of three Claims within the application:
- **FullName**: A custom claim that stores the user's FirstName and LastName properties. This claim is used to personalize the appication and greet logged in users.
- **Email**: This claim grabs the user's email address.
- **DateOfBirth**: This claim grabs the user's Birthdate. It is not currently being implemented, but will be in the future. We are planning on enabling birthday discounts for our users.

## Vulnerability report
[vulnerability-report](https://github.com/rosbobos/minituremadness/blob/Master/vulnerability-report.md)

## Change Log

**0.5** - 20200424
- Unit tests complete and passing for Products and Inventory CRUD operations.
- Shop Index page contains rendered links to each product page.
- Individual Shop product pages render with product details.

**0.4** - 20200423
- User greeted on home page upon successful login.
- Utilized Identity Claims to capture user name and birthdate.

**0.3** - 20200422
- Shop Index page complete, all products render.
- User registration and login complete.

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
- [GitHub](https://github.com/rosbobos)
- [LinkedIn](https://www.linkedin.com/in/rosalyn-johnson-9ab243193/)

**Robert Nielsen**
- [GitHub](https://github.com/robertjnielsen)
- [LinkedIn](https://www.linkedin.com/in/robertjnielsen)
