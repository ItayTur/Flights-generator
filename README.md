# Flights-generator

Flights-generator is an app generating flights and also showing their path in the air-port stations.
The app is build from 2 clients and 1 server. The clients are Flights-generator and Flights-radar.Flights-generator is a console app.
It generates flights and send them to the server. Flights-radar is a UWP app. It shows the flights, 
their movement between the stations and their current positions.
It is implemented using MVVM pattern. The calls from the server is maid by signalR.
The server is an ASP.net web-API app for REST Services. It's build with 2 libraries each one act as a separate layer.
The libraries are: .net framework library - DAL, .net framework library - BL.
The FlightsController receives the generated flights through  http calls, validate their data and pass it to the FlightsManager in the BL.
The BL manager receives the data and process it into the app logic.
While doing so, it is passing the Flight entity to the FlightsRepository in the DAL, which adding it to the database.
It's a SQL database using SQL server, and entity-framework for code-integration. We created the database using code-first work-flow.

### Prerequisites

To run the app visual studio 2017 is needed, and windows 10.
SQL Server 
SQL Server Management Studio (SSMS)

## Built With

* [Visual Studio 2017 Community](https://visualstudio.microsoft.com/downloads/) - IDE
* [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) - SQL Database

## Authors

* **Avi Hadad** - *client and server development* - [Avi Hadad](https://github.com/avih75)
* **Itay Tur** - *infrastructure, database management and server development* - [Itay Tur](https://github.com/ItayTur)

## Acknowledgments

* Sela college(https://www.sela.co.il/)



