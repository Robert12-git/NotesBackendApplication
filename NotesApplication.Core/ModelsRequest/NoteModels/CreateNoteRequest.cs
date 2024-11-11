using NotesApplication.Core.ModelsRequest.Abstractions;

namespace NotesApplication.Core.ModelsRequest.NoteModels;

public class CreateNoteRequest : NoteRequest
{
    public Guid UserId { get; set; }
}