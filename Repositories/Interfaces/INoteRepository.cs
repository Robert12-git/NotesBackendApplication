using NotesApplication.Models;

namespace NotesApplication.Repositories.Interfaces;

public interface INoteRepository
{
    Task<Note?> CreateNoteAsync(Note note);
    Task<Note?> GetNoteByIdAsync(string id);
    Task<Note?> UpdateNoteAsync(Note note);
    Task<bool> DeleteNoteAsync(Note note);
    Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(int userId);
}