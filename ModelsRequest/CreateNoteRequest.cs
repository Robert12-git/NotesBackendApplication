using NotesApplication.ModelsRequest.Abstractions;

namespace NotesApplication.ModelsRequest;

public class CreateNoteRequest : NoteRequest
{
    public int UserId { get; set; }
}