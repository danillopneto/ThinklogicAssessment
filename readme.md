# Calendar Challenge

1.   Create an .NET Core web site using C#.
2.   Create a page that displays a calendar. Default the selected day to the current day.
3.   Create a sql database to store and retrieve events.
4.   Upon selecting a day, refresh a list of calendar events for that date on the same page.
5.   An event should have at minimum the following fields: Start Date, End Date, Title, Location, Description
6.   Allow a user to add events by clicking a button.
7.   Allow a user to edit an event.

# Time Spent

It was spent 2h13min to do it.

# Steps to run/debug the application

1. Run the following commands to start SQL Server:  
    - `docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=DockerSql2019!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU15-ubuntu-20.04`
2. Open the solution with Visual Studio 
3. Run the migrations with `update-database -context ApplicationContext`
4. Click on `► Start`  

# Things to improve

1. Allow the calendar to show other months
2. Do the unit tests
