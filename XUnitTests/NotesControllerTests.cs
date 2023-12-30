using API_Assignment1.Controllers;
using API_Assignment1.Models;
using API_Assignment1.Repository;
using NSubstitute;

namespace XUnitTests
{
    public class NotesControllerTests
    {
        private readonly NotesController _sut;
        private readonly INoteRepository _noteRepository = Substitute.For<INoteRepository>();
        public NotesControllerTests()
        {
            _sut = new NotesController(_noteRepository);
        }

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

        [Fact]
        public void GetCount_ShouldReturnThree_WhenThreeNotesExist()
        {
            // Arrange
            int expected = 3;

            _noteRepository.GetRemaining().Returns(3);

            // Act
            int result = _sut.GetRemaining().Value;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteNote_ShouldReturnDeletedNote_WhenIdExists()
        {
            // Arrange
            int id = 1;
            Note note = new() { Id = 1, IsDone = true, Text = "Milk" };

            _noteRepository.DeleteNote(id).Returns(note);

            // Act
            Note result = _sut.DeleteNote(id).Value;

            // Assert
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public void PostNote_ShouldReturnNoteWithEmptyText_WhenInputTextIsEmpty()
        {
            // Arrange
            string empty = "";
            Note note = new() { Id = 1, IsDone = true, Text = "" };

            _noteRepository.PostNote(note).Returns(note);

            // Act
            Note result = _sut.PostNote(note).Value;

            // Assert
            Assert.Equal(empty, result.Text);
        }

        [Fact]
        public void ReverseText_ShouldReverseText_WhenNoteIsPosted()
        {
            // Arrange
            string expected = "kliM";
            Note note = new() { Id = 1, IsDone = true, Text = "Milk" };

            // Act
            string result = _sut.ReverseText(note);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}