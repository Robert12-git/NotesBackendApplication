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
    public async Task<ActionResult<string>> CreateNote([FromBody] CreateNoteRequest? noteRequest)
    {
        if (noteRequest is null)
        {
            return BadRequest("Note cannot be null");
        }

        try
        {
            var note = new Note
            {
                NoteId = Guid.NewGuid().ToString(),
                Title = noteRequest.Title,
                Content = noteRequest.Content,
                CreatedAt = DateTime.Now,
                ModifiedAt = null,
                UserId = noteRequest.UserId
            };
            
            var createdNote = await noteRepository.CreateNoteAsync(note);
            return createdNote == null ? StatusCode(500, "Internal Server Error when creating a note") :
                                        Ok(createdNote.NoteId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while creating a note.");

            return StatusCode(500, "An error occurred while creating the note.");
        }
    }
    
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<IEnumerable<Note>>> GetAllNotesByUser(int userId)
    {
        var notes = await noteRepository.GetAllNotesByUserIdAsync(userId);

        return Ok(notes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNoteById(string? id)
    {
        if (id is null)
        {
            return BadRequest("Invalid id");
        }

        var note = await noteRepository.GetNoteByIdAsync(id);
        if (note is null)
        {
            return NotFound("Note not found");
        }
        
        return Ok(note);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(string id, [FromBody] UpdateNoteRequest? updateNoteRequest)
    {
        if (updateNoteRequest == null)
        {
            return BadRequest("Invalid note data.");
        }

        var existingNote = await noteRepository.GetNoteByIdAsync(id);
        if (existingNote == null)
        {
            return NotFound("Note not found");
        }

        try
        {
            existingNote.Title = updateNoteRequest.Title;
            existingNote.Content = updateNoteRequest.Content;
            existingNote.ModifiedAt = DateTime.Now;
            
            var updatedNote = await noteRepository.UpdateNoteAsync(existingNote);
            if (updatedNote is null)
            {
                return NotFound("Note not found");
            }
            return Ok("Note updated");
        }
        catch
        {
            return StatusCode(500, "An error occurred while updating the note.");
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteById(string id)
    {
        var existingNote = await noteRepository.GetNoteByIdAsync(id);
        if (existingNote == null)
        {
            return NotFound("Note not found");
        }

        try
        {
            var deleted = await noteRepository.DeleteNoteAsync(existingNote);
            return !deleted ? StatusCode(500, "Internal Server Error when deleting the note.") : Ok("Note deleted");
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the note.");
        }
    }
}