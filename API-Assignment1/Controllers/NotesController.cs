using API_Assignment1.Data;
using API_Assignment1.Models;
using API_Assignment1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Assignment1.Controllers
{
    [ApiController]
    [Route("")]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository repository)
        {
            _noteRepository = repository;
        }

        [HttpGet("notes")]
        public ActionResult<IEnumerable<Note>> GetNotes(bool? completed)
        {
            var notes = _noteRepository.GetNotes(completed).ToArray();

            return notes;
        }

        [HttpPost("notes")]
        public ActionResult<Note> PostNote(Note httpNote)
        {
            Note dbNote = _noteRepository.PostNote(httpNote);

            return Ok(dbNote);
        }

        [HttpGet("remaining")]
        public ActionResult<int> GetRemaining()
        {
            return _noteRepository.GetRemaining();
        }

        [HttpPut("notes/{id}")]
        public ActionResult<Note> GetNote(Note httpNote)
        {
            Note dbNote = _noteRepository.GetNote(httpNote);

            return dbNote;
        }

        [HttpDelete("notes/{id}")]
        public ActionResult<Note> DeleteNote(int id)
        {
            Note dbNote = _noteRepository.DeleteNote(id);

            return dbNote;
        }

        [HttpPost("toggle-all")]
        public ActionResult<IEnumerable<Note>> ToggleAllCheckboxes()
        {
            _noteRepository.ToggleAllCheckboxes();

            return Ok();
        }

        [HttpPost("clear-completed")]
        public ActionResult ClearCompleted()
        {
            _noteRepository.ClearCompleted();

            return Ok();
        }
    }
}