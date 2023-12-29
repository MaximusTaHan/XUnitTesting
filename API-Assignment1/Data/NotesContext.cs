using API_Assignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Assignment1.Data
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
