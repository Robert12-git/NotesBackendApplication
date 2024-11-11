using Microsoft.AspNetCore.Mvc;
using NotesApplication.Core.Models;
using NotesApplication.Core.ModelsRequest.NoteModels;
using NotesApplication.Services.Services.Interfaces;

namespace NotesApplication.API.Controllers;

[Route("api/notes")]
[ApiController]
public class NotesController(INoteService noteService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteRequest noteRequest)
    {
        var createdNote = await noteService.CreateNote(noteRequest);
        ArgumentNullException.ThrowIfNull(createdNote);
            
        return Ok(createdNote.Id);
    }
    
    [HttpGet("users/{userId}")]
    public async Task<ActionResult<IEnumerable<Note>>> GetAllNotesByUser(Guid userId)
    {
        var notes = await noteService.GetAllNotesByUser(userId);
        return Ok(notes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNoteById(Guid id)
    {
        var note = await noteService.GetNoteById(id);
        ArgumentNullException.ThrowIfNull(note);
        
        return Ok(note);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(Guid id, [FromBody] UpdateNoteRequest updateNoteRequest)
    {
        var updatedNode = await noteService.UpdateNote(id, updateNoteRequest);
        ArgumentNullException.ThrowIfNull(updatedNode);

        return Ok(updatedNode);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteById(Guid id)
    {
        await noteService.DeleteNote(id);
        return Ok("Note deleted");
    }
}