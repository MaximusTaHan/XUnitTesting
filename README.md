# This is a project to learn and demonstrate unit testing with XUnit.

To run this project make sure there is a valid SQLServer connectionstring in appsettings.json (Current string is configured for localhost so it may work by default).

In Package Manager Console:
* Run add-migration -MigrationMessage-. (May not be nessecary).
* Run Update database.
Then go ahead and start the program.
This will open up Swagger for endpoint testing.

The Frontend is written entierly in Html, CSS and Javascript and will call the backend endpoints when opened in the browser.
Open the Index.html manually from the project files to access the Frontend

## Mocking and test conventions

To be able to unit test Controller methods that rely on external dependancies such as a database context we need to use mocking. The controller methods have been rewritten to use a repository class that handle all database calls and contain very litle logic.

For this project iv chosen to use NSubstitute since it has concise and simple syntax.

## Issues with testing plain CRUD

Testing plain CRUD methods provide very litle value. The tests included mainly use mocking to ensure that the controller method returns correct notes. If further logic would be added to the controller methods these tests would provide more value in ensuring correct data.

Example:

Test to ensure list of notes get returned
```csharp
        [Fact]
        public void GetNotes_ShouldReturnNotes_WhenNotesExist()
        {
            // Arrange
            bool completed = true;
            string milk = "Milk";
            string cereal = "Cereal";
            List<Note> notes = new List<Note>
            {
                new Note() { Id = 1, IsDone = true, Text = "Milk" },
                new Note() { Id = 2, IsDone = true, Text = "Cereal" },
            };
            
            _noteRepository.GetNotes(completed).Returns(notes);

            // Act
            Note[] result = _sut.GetNotes(completed).Value.ToArray();

            // Assert
            Assert.Equal(milk, result[0].Text);
            Assert.Equal(cereal, result[1].Text);
        }
```
Functioning:

![Skärmbild 2023-12-29 154752](https://github.com/MaximusTaHan/XUnitTesting/assets/91058022/b21e9922-1558-4d2a-bf3a-293a464503ca)

Failing due to unwanted behaviour:

![Skärmbild 2023-12-29 154730](https://github.com/MaximusTaHan/XUnitTesting/assets/91058022/83011b62-8325-49d7-a87f-89730e5c39b5)
