using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApplication.Models;

public class Note
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
    
    public Guid UserId { get; set; }
    
    // [ForeignKey("UserId")]
    // public User User { get; set; }
}