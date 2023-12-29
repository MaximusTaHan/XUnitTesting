# This is a project to learn and demonstrate unit testing with XUnit.

To run this project make sure there is a valid SQLServer connectionstring in appsettings.json (Current string is configured for localhost so it may work by default).
In Package Manager Console:
* Run add-migration MigrationMessage. (May not be nessecary).
* Run Update database.
Then go ahead and start the program.
This will open up Swagger for endpoint testing.

The Frontend is written entierly in Html, CSS and Javascript and will call the backend endpoints when opened in the browser.
Open the Index.html to access the Frontend
