using System.ComponentModel.DataAnnotations;

namespace Prosigliere.Models;

public class Comment
{
    public Guid Id { get; set; }
    public Guid BlogPostId { get; set; }
    [MaxLength(5000)]
    public required string Content { get; set; }
    public virtual BlogPost? BlogPost { get; set; }
}