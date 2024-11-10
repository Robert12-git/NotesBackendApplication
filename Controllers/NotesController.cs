using Microsoft.AspNetCore.Mvc;
using NotesApplication.Models;
using NotesApplication.ModelsRequest;
using NotesApplication.Repositories.Interfaces;

namespace NotesApplication.Controllers;

[Route("api/notes")]
[ApiController]
public class NotesController(ILogger<NotesController> logger, INoteRepository noteRepository) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteRequest noteRequest)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            Title = noteRequest.Title,
            Content = noteRequest.Content,
            CreatedAt = DateTime.Now,
            ModifiedAt = null,
            UserId = noteRequest.UserId
        };
            
        var createdNote = await noteRepository.CreateNoteAsync(note);
        ArgumentNullException.ThrowIfNull(createdNote);
            
        return Ok(createdNote.Id);
    }
    
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<IEnumerable<Note>>> GetAllNotesByUser(Guid userId)
    {
        var notes = await noteRepository.GetAllNotesByUserIdAsync(userId);
        return Ok(notes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNoteById(Guid id)
    {
        var note = await noteRepository.GetNoteByIdAsync(id);
        ArgumentNullException.ThrowIfNull(note);
        
        return Ok(note);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(Guid id, [FromBody] UpdateNoteRequest updateNoteRequest)
    {
        var existingNote = await noteRepository.GetNoteByIdAsync(id);
        ArgumentNullException.ThrowIfNull(existingNote);

        existingNote.Title = updateNoteRequest.Title;
        existingNote.Content = updateNoteRequest.Content;
        existingNote.ModifiedAt = DateTime.Now;
            
        var updatedNode = await noteRepository.UpdateNoteAsync(existingNote);
        ArgumentNullException.ThrowIfNull(updatedNode);

        return Ok(updatedNode);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteById(Guid id)
    {
        var existingNote = await noteRepository.GetNoteByIdAsync(id);
        ArgumentNullException.ThrowIfNull(existingNote);

        await noteRepository.DeleteNoteAsync(existingNote);
        return Ok("Note deleted");
    }
}