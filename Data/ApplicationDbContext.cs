using Microsoft.EntityFrameworkCore;
using NotesApplication.Models;

namespace NotesApplication.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // modelBuilder.Entity<User>()
        //     .HasMany(u => u.Notes)
        //     .WithOne(n => n.User)
        //     .HasForeignKey(n => n.UserId);
    }
}