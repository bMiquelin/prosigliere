using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        await Task.CompletedTask;
        return [];
    }

    /// <summary>
    /// Create a new blog post.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<BlogPost>> CreatePost(BlogPost post)
    {
        await Task.CompletedTask;
        return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
    }

    /// <summary>
    /// Retrieve a specific blog post by its ID, including its title, content, and a list of associated comments
    /// </summary>
    [HttpGet("{id}")]
    public async Task<BlogPost> GetPostById(Guid id)
    {
        await Task.CompletedTask;
        return new BlogPost { Id = id, Title = "Test Post", Content = "This is a test post." };
    }

    /// <summary>
    /// Add a new comment to a specific blog post.
    /// </summary>
    [HttpPost("{id}/comments")]
    public async Task<ActionResult<Comment>> AddCommentToPost(Guid id, Comment comment)
    {
        await Task.CompletedTask;
        return CreatedAtAction(nameof(Comment), new { id = comment.Id }, comment);
    }
}
