namespace Prosigliere.Models;

public class Comment
{
    public int Id { get; set; }
    public int BlogPostId { get; set; }
    public required string Content { get; set; }
    public virtual required BlogPost BlogPost { get; set; }
}