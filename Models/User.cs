using System.ComponentModel.DataAnnotations;

namespace NotesApplication.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Username { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    [StringLength(100)]
    public string PasswordHash { get; set; }
    
    public virtual ICollection<Note> Notes { get; set; }
}