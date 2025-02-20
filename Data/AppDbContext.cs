using Microsoft.EntityFrameworkCore;
using Prosigliere.Models;

public class AppDbContext : DbContext
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.Use
    }
}