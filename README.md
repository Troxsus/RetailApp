# RetailApp

## Overview
This is a project for a retail application that uses GRPC for it's services that are exposed through an API. For the database, Entitiy Framework Core is being used.

## Steps to set up locally

1. Clone or download the github repository on your local machine.

2. Open the RetailApp.sln file with Visual Studio

3. You will need to change the connection strings so they can work for you
Only the Service projects have connection strings. They are in the appsettings.json file.

4. From the Solution explorer in Visual Studio right click on one of these three projects (listed down below)
Then hit the option "Set as Startup Project"
**_NOTE!_ This needs to be done only for one of the three projects**
- RetailApp.OrderService
- RetailApp.PaymentService
- RetailApp.ProductService


5. From the "Tools" dropdown found in the Visual Studio navigation.
Select "NuGet Package Manager" -> "Package Manager Console".

6. After the package manager console is open you'll need to type in these commands in the order they are shown
```
Add-Migration Initial

Update-Database
```

7. To start the project just start individually the projects in this order
- RetailApp.OrderService
- RetailApp.PaymentService
- RetailApp.ProductService
- RetailApp.API
