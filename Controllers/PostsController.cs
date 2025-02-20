using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prosigliere.Dtos;
using Prosigliere.Models;

namespace Prosigliere.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    /// <summary>
    /// This endpoint should return a list of all blog posts, including their titles and the number of comments associated with each post.
    /// </summary>
    [HttpGet]
    public async Task<List<BlogPost>> GetAllBlogPosts()
    {
        return await _context.BlogPosts
            .Include(post => post.Comments)
            .ToListAsync();
    }

    /// <summary>
    /// Create a new blog post.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<BlogPost>> CreatePost(BlogPost post)
    {
        _context.BlogPosts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }

    /// <summary>
    /// Retrieve a specific blog post by its ID, including its title, content, and a list of associated comments
    /// </summary>
    [HttpGet("{id}")]
    public async Task<BlogPost?> GetPostById(Guid id)
    {
        return await _context.BlogPosts
            .Include(post => post.Comments)
            .FirstOrDefaultAsync(post => post.Id == id);
    }

    /// <summary>
    /// Add a new comment to a specific blog post.
    /// </summary>
    [HttpPost("{id}/comments")]
    public async Task<ActionResult<Comment>> AddCommentToPost(Guid id, CommentDto commentDto)
    {
        if (!await context.BlogPosts.AnyAsync(post => post.Id == id))
        {
            return NotFound("Post not found");
        }
        
        var comment = new Comment
        {
            Id = commentDto.Id ?? Guid.NewGuid(),
            Content = commentDto.Content,
            BlogPostId = id
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(AddCommentToPost), new { id = comment.Id }, comment);
    }
}
