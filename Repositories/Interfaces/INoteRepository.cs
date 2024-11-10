using NotesApplication.Models;

namespace NotesApplication.Repositories.Interfaces;

public interface INoteRepository
{
    Task<Note?> CreateNoteAsync(Note note);
    Task<Note?> GetNoteByIdAsync(Guid id);
    Task<Note?> UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(Note note);
    Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(Guid userId);
}