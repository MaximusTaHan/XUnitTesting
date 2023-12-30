using API_Assignment1.Data;
using API_Assignment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API_Assignment1.Repository
{
    public class NoteRepository: INoteRepository
    {
        private readonly NotesContext _context;

        public NoteRepository(NotesContext context)
        {
            _context = context;
        }

        public void ClearCompleted()
        {
            var dbNotes = _context.Notes.Where(n => n.IsDone == true);

            foreach (Note note in dbNotes)
                _context.Remove(note);

            _context.SaveChanges();
        }

        public Note DeleteNote(int id)
        {
            var dbNote = _context.Notes.FirstOrDefault(n => n.Id == id);

            _context.Remove(dbNote);
            _context.SaveChanges();

            return dbNote;
        }

        public Note GetNote(Note httpNote)
        {
            var dbNote = _context.Notes.FirstOrDefault(n => n.Id == httpNote.Id);

            dbNote.IsDone = httpNote.IsDone;

            _context.SaveChanges();

            return dbNote;
        }

        public IEnumerable<Note> GetNotes(bool? completed)
        {
            if (completed == true)
                return _context.Notes.Where(n => n.IsDone == true).ToArray();

            else if (completed == false)
                return _context.Notes.Where(n => n.IsDone == false).ToArray();

            return _context.Notes;
        }

        public int GetRemaining()
        {
            return _context.Notes.Count(n => !n.IsDone);
        }

        public Note PostNote(Note httpNote)
        {
            var dbNote = new Note
            {
                Text = httpNote.Text,
                IsDone = httpNote.IsDone,
            };

            _context.Notes.Add(dbNote);
            _context.SaveChanges();

            return dbNote;
        }

        public void ToggleAllCheckboxes()
        {
            var dbNote = _context.Notes.FirstOrDefault(n => n.IsDone == false);

            if (dbNote != null)
            {
                foreach (Note note in _context.Notes)
                    note.IsDone = true;
            }
            else
            {
                foreach (Note note in _context.Notes)
                    note.IsDone = false;
            }

            _context.SaveChanges();
        }
    }
}
