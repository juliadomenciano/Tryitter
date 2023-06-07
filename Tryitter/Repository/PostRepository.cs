using tryitter.Models;

namespace tryitter.Repository
{
  public class PostRepository
  {
    protected readonly TryitterContext _context;
    public PostRepository (TryitterContext context)
    {
      _context = context;
    }

    public IEnumerable<PostResponse> GetAllPosts()
    {
      var posts = _context.Posts.ToList();
      var response = new List<PostResponse>();
      foreach (Post post in posts)
        {
          response.Add(new PostResponse
            {
                PostId = post.PostId,
                Title = post.Title,
                Text = post.Text,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                StudentId = post.StudentId
            });
        }
      return response;
    }

    public PostResponse GetPostById(int id)
    {
      var post = _context.Posts.Where(p => p.PostId == id).First();
      return new PostResponse
      {
        PostId = post.PostId,
        Title = post.Title,
        Text = post.Text,
        CreatedAt = post.CreatedAt,
        UpdatedAt = post.UpdatedAt,
        StudentId = post.StudentId
      };
    }

    public IEnumerable<PostResponse> GetStudentPosts(int id)
    {
      var posts = _context.Posts.Where(p => p.StudentId == id).ToList();
      var response = new List<PostResponse>();
      foreach (Post post in posts)
        {
          response.Add(new PostResponse
            {
                PostId = post.PostId,
                Title = post.Title,
                Text = post.Text,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                StudentId = post.StudentId
            });
        }
      return response;
    }
    public PostResponse GetStudentLastPost(int id)
    {
      var post = _context.Posts.OrderBy(p => p.PostId).LastOrDefault(p => p.StudentId == id);
      return new PostResponse
      {
        PostId = post.PostId,
        Title = post.Title,
        Text = post.Text,
        CreatedAt = post.CreatedAt,
        UpdatedAt = post.UpdatedAt,
        StudentId = post.StudentId
      };
    }
    public IEnumerable<PostResponse> GetPostByStudentId(int id)
    {
      var posts = _context.Posts.Where(p => p.StudentId == id).ToList();
      var response = new List<PostResponse>();
      foreach (Post post in posts)
        {
          response.Add(new PostResponse
            {
                PostId = post.PostId,
                Title = post.Title,
                Text = post.Text,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                StudentId = post.StudentId
            });
        }
      return response;
    }
    public PostResponse GetLastPostByStudentId(int id)
    {
      var post = _context.Posts.Where(p => p.StudentId == id).OrderBy(p => p.PostId).LastOrDefault();
      return new PostResponse
      {
        PostId = post.PostId,
        Title = post.Title,
        Text = post.Text,
        CreatedAt = post.CreatedAt,
        UpdatedAt = post.UpdatedAt,
        StudentId = post.StudentId
      };
    }
    public string AddPost(Post Post)
    {
      _context.Posts.Add(Post);
      _context.SaveChanges();
      return "Post Created";
    }
    public string UpdatePost(int id, Post PostNewInfo)
    {
      var post = _context.Posts.Where(p => p.PostId == id).First();
      post.Title = PostNewInfo.Title;
      post.Text = PostNewInfo.Text;
      post.UpdatedAt = DateTime.Now;

      _context.SaveChanges();
      return "Post updated";
    }
    public string DeletePost(int id)
    {
      var Post = _context.Posts.Find(id);
      _context.Posts.Remove(Post);
      _context.SaveChanges();
      return "Post deleted";
    }
  }
}