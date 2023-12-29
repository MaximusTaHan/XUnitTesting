using API_Assignment1.Data;
using API_Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Assignment1.Controllers
{
    [ApiController]
    [Route("")]
    public class NotesController : ControllerBase
    {
        private readonly NotesContext _notesContext;

        public NotesController(NotesContext notesContext)
        {
            _notesContext = notesContext;
        }

        [HttpGet("notes")]
        public ActionResult<IEnumerable<Note>> GetNotes(bool? completed)
        {
            if (completed == true)
                return _notesContext.Notes.Where(n => n.IsDone == true).ToArray();

            else if(completed == false)
                return _notesContext.Notes.Where(n => n.IsDone == false).ToArray();

            return _notesContext.Notes;
        }

        [HttpPost("notes")]
        public ActionResult<Note> PostNote(Note httpNote)
        {
            var dbNote = new Note
            {
                Text = httpNote.Text,
                IsDone = httpNote.IsDone,
            };

            _notesContext.Notes.Add(dbNote);
            _notesContext.SaveChanges();

            return Ok();
        }

        [HttpGet("remaining")]
        public ActionResult<int> GetRemaining()
        {
            return _notesContext.Notes.Count(n => !n.IsDone);
        }

        [HttpPut("notes/{id}")]
        public ActionResult<Note> GetNote(Note httpNote)
        {
            var dbNote = _notesContext.Notes.FirstOrDefault(n => n.Id == httpNote.Id);

            dbNote.IsDone = httpNote.IsDone;

            _notesContext.SaveChanges();

            return dbNote;
        }

        [HttpDelete("notes/{id}")]
        public ActionResult DeleteNote(int id)
        {
            var dbNote = _notesContext.Notes.FirstOrDefault(n => n.Id == id);

            _notesContext.Remove(dbNote);
            _notesContext.SaveChanges();

            return Ok();
        }

        [HttpPost("toggle-all")]
        public ActionResult<IEnumerable<Note>> ToggleAllCheckboxes()
        {
            var dbNote = _notesContext.Notes.FirstOrDefault(n => n.IsDone == false);

            if(dbNote != null)
            {
                foreach(Note note in _notesContext.Notes)
                    note.IsDone = true;
            }
            else
            {
                foreach(Note note in _notesContext.Notes)
                    note.IsDone = false;
            }

            _notesContext.SaveChanges();

            return Ok();
        }

        [HttpPost("clear-completed")]
        public ActionResult ClearCompleted()
        {
            var dbNotes = _notesContext.Notes.Where(n => n.IsDone == true);

            foreach (Note note in dbNotes)
                _notesContext.Remove(note);

            _notesContext.SaveChanges();

            return Ok();
        }
    }
}