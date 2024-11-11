using System.ComponentModel.DataAnnotations;

namespace NotesApplication.Core.Models;

public class User
{
    public Guid UserId { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string PasswordHash { get; set; }
    
    public ICollection<Note> Notes { get; set; }
}