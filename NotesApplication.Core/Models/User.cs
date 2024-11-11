using System.ComponentModel.DataAnnotations;

namespace NotesApplication.Core.Models;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    [StringLength(100)]
    public string PasswordHash { get; set; }
    
    public ICollection<Note> Notes { get; set; }
}