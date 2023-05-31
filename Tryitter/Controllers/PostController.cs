using Microsoft.AspNetCore.Mvc;
using tryitter.Repository;
using tryitter.Models;
using tryitter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetMyPosts()
    {
      // var getAllPosts = _repository.GetPosts();
      // return Ok(getAllPosts);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetMyLastPost()
    {
      // var getAllPosts = _repository.GetPosts();
      // return Ok(getAllPosts);
    }

    [HttpGet("/Post/{name}")]
    [AllowAnonymous]
    public IActionResult GetPostByStudentName(string name)
    {
      // if (string.IsNullOrEmpty(name))
      //   {
      //       return GetPosts();
      //   }

      // var matchingPosts = _repository.GetPostByName(name);
      // return Ok(matchingPosts);
    }

    [HttpGet("/Post/{name}")]
    [AllowAnonymous]
    public IActionResult GetLastPostByStudentName(string name)
    {
      // if (string.IsNullOrEmpty(name))
      //   {
      //       return GetPosts();
      //   }

      // var matchingPosts = _repository.GetPostByName(name);
      // return Ok(matchingPosts);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult CreatePost(Post Post)
    {
      // _repository.AddPost(Post);
      // return Ok();
    }

    [HttpPut("/Post/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult UpdatePost(int id, Post PostInfo)
    {
      // var getPost = _repository.GetPostById(id);
      // if (getPost == null)
      //   {
      //       return BadRequest("Post not found!");
      //   }

      // var updatedPost = _repository.UpdatePost(getPost, PostInfo);
      // return Ok(updatedPost);
    }
    
    [HttpDelete("/Post/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult DeletePost(int id)
    {
      // var getPost = _repository.GetPostById(id);
      // if (getPost == null)
      //   {
      //       return BadRequest("Post not found!");
      //   }

      // _repository.DeletePost(id);
      // return Ok();
    }
  }
}