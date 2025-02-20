using System.ComponentModel.DataAnnotations;

namespace Prosigliere.Models;

public class BlogPost
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public required string Title { get; set; }
    [MaxLength(20000)]
    public required string Content { get; set; }
    public List<Comment> Comments { get; set; } = [];
}