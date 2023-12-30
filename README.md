# This is a project to learn and demonstrate unit testing with XUnit.

To run this project make sure there is a valid SQLServer connectionstring in appsettings.json (Current string is configured for localhost so it may work by default).

In Package Manager Console:
* Run add-migration MigrationMessage. (May not be nessecary).
* Run Update database.
Then go ahead and start the program.
This will open up Swagger for endpoint testing.

The Frontend is written entierly in Html, CSS and Javascript and will call the backend endpoints when opened in the browser.
Open the Index.html to access the Frontend

## Mocking and test conventions

To be able to unit test Controller methods that rely on external dependancies such as a database context we need to use mocking. The controller methods have been rewritten to use a repository class that handle all database calls and contain very litle logic.

For this project iv chosen to use NSubstitute since it has concise and simple syntax.

## Issues with testing plain CRUD

Testing plain CRUD methods provide very litle value. The project description does not outline any further business logic
