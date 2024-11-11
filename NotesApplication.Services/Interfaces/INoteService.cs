using NotesApplication.Core.Models;
using NotesApplication.Core.ModelsRequest.NoteModels;

namespace NotesApplication.Services.Services.Interfaces;

public interface INoteService
{
    Task<Note?> CreateNote(CreateNoteRequest note);
    Task<Note?> GetNoteById(Guid id);
    Task<Note?> UpdateNote(Guid id, UpdateNoteRequest note);
    Task DeleteNote(Guid id);
    Task<IEnumerable<Note>> GetAllNotesByUser(Guid userId);
}