using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using tryitter.Models;
using tryitter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace tryitter.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PostController : Controller
  {
    private readonly PostRepository _repository;
    public PostController(PostRepository repository)
    {
      _repository = repository;
    }

    [HttpGet("/myPosts")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetMyPosts()
    {
      var studentIdClaim = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
      int studentId = int.Parse(studentIdClaim.Value);
      var getAllPosts = _repository.GetStudentPosts(studentId);
      return Ok(getAllPosts);
    }

    [HttpGet("/myLastPost")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetMyLastPost()
    {
      var studentIdClaim = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier);
      int studentId = int.Parse(studentIdClaim.Value);
      var getAllPosts = _repository.GetStudentLastPost(studentId);
      return Ok(getAllPosts);
    }

    [HttpGet("/Post/{id}")]
    [AllowAnonymous]
    public IActionResult GetPostByStudentId(int id)
    {
      var getAllPosts = _repository.GetPostByStudentId(id);
      return Ok(getAllPosts);
    }

    [HttpGet("/lastPost/{id}")]
    [AllowAnonymous]
    public IActionResult GetLastPostByStudentId(int id)
    {
      var getLastPost = _repository.GetLastPostByStudentId(id);
      return Ok(getLastPost);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult CreatePost(Post Post)
    {
      var newPost = _repository.AddPost(Post);
      return Ok(newPost);
    }

    [HttpPut("/Post/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult UpdatePost(int id, Post PostInfo)
    {
      var getPost = _repository.GetPostById(id);
      if (getPost == null)
        {
            return BadRequest("Post not found!");
        }

      var updatedPost = _repository.UpdatePost(getPost, PostInfo);
      return Ok(updatedPost);
    }
    
    [HttpDelete("/Post/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult DeletePost(int id)
    {
      var getPost = _repository.GetPostById(id);
      if (getPost == null)
        {
            return BadRequest("Post not found!");
        }

      _repository.DeletePost(id);
      return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetAllPosts()
    {
      var posts = _repository.GetAllPosts();
      return Ok(posts);
    }
  }
}