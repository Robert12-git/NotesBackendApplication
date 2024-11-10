using NotesApplication.ModelsRequest.Abstractions;

namespace NotesApplication.ModelsRequest;

public class CreateNoteRequest : NoteRequest
{
    public Guid UserId { get; set; }
}