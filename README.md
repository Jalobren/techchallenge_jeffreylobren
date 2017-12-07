# techchallenge_jeffreylobren
Tech challenge

Architecture:
- RaceDay.Contracts: Contains all the Service Client interface and Data transfer Objects
- RaceDay.BL: Is the Business logic layer has dependency on RaceDay.Contracts and RaceDay.Entity
- RaceDay.Entity: Is a code first entity framework to access the database
- RaceDay.Api: Is a WebApi application that has the additional endpoints
- RaceDay.Client: Is used by RaceDay.WebApp to connect and get data from an api
- RaceDay.WebApp: Is an MVC application that shows the Races and other details.

How To Setup
- Make sure you have the following installed
 - Visual Studio 2015
 - SQL Server with default instance
- Open RaceDay.sln using Visual Studio 2015
- Build the solution
- Go on "Tools/NuGet Package Manager/Package Manager Console"
- On the Solution right click the RaceDay.Api project and click "Set As Startup Project"
- On the console set "Default Project" on the console to "RaceDay.Entity"
- Type in "udpate-database" to generate the tables

To Run the Web Api
 - On the Solution right click the RaceDay.Api project and click "Set As Startup Project"
 - Click Run/ Play button on Visual Studio

To Run the Web Application/ Website
 - On the Solution right click the "RaceDay.WebApp" project and click "Set As Startup Project"
 - Click Run/Play button on Visual Studio
 
 Web Api End points
 1. list of customers
 url: http://localhost:50890/api/customer/get
 2. total bets placed for a customer
 url: http://localhost:50890/api/customer/get/{customerId}/TotalBets
 3.	total amount bet per customer
 url: http://localhost:50890/api/customer/get/{customerId}/TotalAmountBets
 4.	total amount bet for all customers
 url: http://localhost:50890/api/bet/getAll/TotalAmount
 5.	at risk customer (customers that have bet over $200)
 url: http://localhost:50890/api/customer/getAll/AtRisk

 
 
