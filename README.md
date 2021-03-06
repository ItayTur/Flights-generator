# Flights-generator

Flights-generator project is made of two client-side apps and one server app. The first generating flights the second showing their path in the air-port stations. The clients are Flights-generator and Flights-radar.Flights-generator is a console app.
It generates flights and send them to the server via http calls. Flights-radar is a UWP app. It shows the flights, 
their movement between the stations and their current positions.
It is implemented using MVVM pattern. The calls from the server is maid by signalR.
The server is an ASP.net web-API app implementing RESTfull Services. It's build with 2 libraries each one act as a separate layer.
The libraries are: .net framework library - DAL, .net framework library - BL.
The FlightsController receives the generated flights through  http calls, validate their data and pass it to the FlightsManager in the BL.
The BL manager receives the data and process it into the app logic.
While doing so, it is passing the Flight entity to the FlightsRepository in the DAL, which adding it to the database.
Any state change like: flight position, flight movement, flight delay ect, is being reflected to the Flights-radar using SignalR nuget-package.
The app works with SQL database using SQL server, and entity-framework for code-integration. We created the database using code-first work-flow.
To unable future modifications in a simple manner the app implement dependency injection using SimpleInjector nuget package. This way all the classes  are connected with loosely coupling approach. 

### Prerequisites

visual studio 2017, SQL Server 

## Built With

* [Visual Studio 2017 Community](https://visualstudio.microsoft.com/downloads/) - IDE
* [UWP](https://docs.microsoft.com/en-us/windows/uwp/design/basics/design-and-ui-intro) - UI
* [ASP.NET Web API](https://www.asp.net/web-api) - Server
* [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) - SQL Database

## Authors

* **Avi Hadad** - *client and server development* - [Avi Hadad](https://github.com/avih75)
* **Itay Tur** - *infrastructure, database management and server development* - [Itay Tur](https://github.com/ItayTur)

## Acknowledgments

* [Sela college](https://www.sela.co.il/)


