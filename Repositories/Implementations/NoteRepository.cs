using Microsoft.EntityFrameworkCore;
using NotesApplication.Data;
using NotesApplication.Models;
using NotesApplication.Repositories.Interfaces;

namespace NotesApplication.Repositories.Implementations;

public class NoteRepository(ApplicationDbContext context, ILogger<NoteRepository> logger) : INoteRepository
{
    public async Task<Note?> CreateNoteAsync(Note note)
    {
        context.Notes.Add(note);
        await context.SaveChangesAsync();
        
        return note;
    }

    public async Task<Note?> GetNoteByIdAsync(Guid id)
    {
        return await context.Notes.FindAsync(id);
    }

    public async Task<Note?> UpdateNoteAsync(Note note)
    {
        context.Notes.Update(note);
        await context.SaveChangesAsync();

        return note;
    }

    public async Task DeleteNoteAsync(Note note)
    {
        context.Notes.Remove(note);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(Guid userId)
    {
        return await context.Notes.Where(n => n.UserId == userId).ToListAsync();
    }
}