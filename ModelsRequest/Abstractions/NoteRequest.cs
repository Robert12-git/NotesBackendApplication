namespace NotesApplication.ModelsRequest.Abstractions;

public abstract class NoteRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
}