using API_Assignment1.Models;

namespace API_Assignment1.Repository
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotes(bool? completed);
        Note PostNote(Note httpNote);
        int GetRemaining();
        Note GetNote(Note httpNote);
        Note DeleteNote(int id);
        void ToggleAllCheckboxes();
        void ClearCompleted();
    }
}
