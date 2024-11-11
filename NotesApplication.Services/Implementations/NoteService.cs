using NotesApplication.Core.Models;
using NotesApplication.Core.ModelsRequest.NoteModels;
using NotesApplication.Data.Repositories.Interfaces;
using NotesApplication.Services.Services.Interfaces;

namespace NotesApplication.Services.Implementations;

public class NoteService(INoteRepository noteRepository) : INoteService
{
    public async Task<Note?> CreateNote(CreateNoteRequest noteRequest)
    {
        return await noteRepository.CreateNoteAsync(new Note
        {
            Id = Guid.NewGuid(),
            Title = noteRequest.Title,
            Content = noteRequest.Content,
            CreatedAt = DateTime.Now,
            ModifiedAt = null,
            UserId = noteRequest.UserId
        });
    }

    public async Task<Note?> GetNoteById(Guid id)
    {
        return await noteRepository.GetNoteByIdAsync(id);
    }

    public async Task<Note?> UpdateNote(Guid id, UpdateNoteRequest note)
    {
        var existingNote = await noteRepository.GetNoteByIdAsync(id);
        if (existingNote is null) return null;
        
        existingNote.Title = note.Title;
        existingNote.Content = note.Content;
        existingNote.ModifiedAt = DateTime.Now;
        return await noteRepository.UpdateNoteAsync(existingNote);

    }

    public async Task DeleteNote(Guid id)
    {
        var note = await noteRepository.GetNoteByIdAsync(id);
        if (note is not null)
        {
            await noteRepository.DeleteNoteAsync(note);
        }
    }

    public async Task<IEnumerable<Note>> GetAllNotesByUser(Guid userId)
    {
        return await noteRepository.GetAllNotesByUserIdAsync(userId);
    }
}