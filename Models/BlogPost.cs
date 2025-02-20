namespace Prosigliere.Models;

public class BlogPost
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public List<Comment>? Comments { get; set; }
}