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
        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }
        
        return note;
    }

    public async Task<Note?> GetNoteByIdAsync(string id)
    {
        return await context.Notes.FindAsync(id);
    }

    public async Task<Note?> UpdateNoteAsync(Note note)
    {
        context.Notes.Update(note);
        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }

        return note;
    }

    public async Task<bool> DeleteNoteAsync(Note note)
    {
        try
        {
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return false;
        }

        return true;
    }

    public async Task<IEnumerable<Note>> GetAllNotesByUserIdAsync(int userId)
    {
        return await context.Notes.Where(n => n.UserId == userId).ToListAsync();
    }
}