# NuGet Packages
As of 12.11.2019 we are using Pomelo.EntityFrameworkCore.MySql v3.0.0-rc3 as MySql.Data.EntityFrameworkCore v8.0.18 and older versions of Pomelo.EntityFrameworkCore.MySql are not compatible with EFCore 3.0.
Install with `Install-Package Pomelo.EntityFrameworkCore.MySql -Version 3.0.0-rc3.final`
See [StackOverflow](https://stackoverflow.com/questions/57836886/configure-mysql-with-efcore-3-0)

# Modifying the database
To make changes to the database schema follow these steps:
1. Apply changes of the model definitions to Entities.Models and other database changes (e.g. adding or dropping ForeignKeys / Indexes) to Database.
2. In order to add a new migration, select the project that references `Database`, `EFCore.Design` and supplies a .NET Core runtime as StartUp Project.
3. Run `add-migration <migration name>` in Package Manager. This will add a migration to Database.
4. Modify the Up() and Down() method in the newly created migration in Database.
5. Run `update-database` in Package Manager to update your local database.

# How to setup a solution like this with EFCore3.0
Create a new solution and follow these steps:
1. Create a Class Library (.NET Standard) named `Entities` for the model definitions. Start from scratch or use EFCore's `scaffold` command with an existing database.
2. Create a Class Library (.NET Standard) named `Database` for the database context. Add References to `Entities`, `EFCore3.0`, `EFCore.Tools` and the EFCore database driver (e.g. `EFCore.InMemory`).
3. Create a ASP.NET Core Web Application named `<database name>DBI` providing REST endpoints for accessing the database. Add reference to `Database` and `EFCore.Design`.
4. If you skipped the previous step, add a Project with a .NET Core or .NET Framework runtime, e.g. a Console App (.NET Core), that references `Database` and `EFCore.Design`. This is required to configure migrations.
For more information see this [Guide](https://garywoodfine.com/using-ef-core-in-a-separate-class-library-project/)

# Pitfalls when setting up a project like this
- `Add-migration XXXX` with Database as startup project throws error Like `Startup project 'ProjectName' targets framework '.NETStandard'.`
Fix: Use any(!) executable project as startup project that references Microsoft.EntityFrameworkCore.Design, or create a new one just for this. The migrations will still end up in the same place, the executable project just provides the required runtime environment.

