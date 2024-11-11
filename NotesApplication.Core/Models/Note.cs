using System.ComponentModel.DataAnnotations;

namespace NotesApplication.Core.Models;

public class Note
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
    
    public Guid UserId { get; set; }
    
    // [ForeignKey("UserId")]
    // public User User { get; set; }
}