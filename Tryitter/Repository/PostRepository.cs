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

    public IEnumerable<Post> GetAllPosts()
    {
      return _context.Posts.ToList();
    }

    public Post GetPostById(int id)
    {
      return _context.Posts.Where(p => p.PostId == id).First();
    }

    public IEnumerable<Post> GetStudentPosts(int id)
    {
      return _context.Posts.Where(p => p.StudentId == id).ToList();
    }
    public Post GetStudentLastPost(int id)
    {
      return _context.Posts.OrderBy(p => p.PostId).LastOrDefault(p => p.StudentId == id);
    }
    public IEnumerable<Post> GetPostByStudentId(int id)
    {
      var posts = _context.Posts.Where(p => p.StudentId == id).ToList();
      return posts;
    }
    public Post GetLastPostByStudentId(int id)
    {
      return _context.Posts.Where(p => p.StudentId == id).OrderBy(p => p.PostId).LastOrDefault();
    }
    public Post AddPost(Post Post)
    {
      _context.Posts.Add(Post);
      _context.SaveChanges();
      return Post;
    }
    public Post UpdatePost(Post Post, Post PostNewInfo)
    {
      Post.Title = PostNewInfo.Title;
      Post.Text = PostNewInfo.Text;
      Post.UpdatedAt = DateTime.Now;

      _context.SaveChanges();
      return Post;
    }
    public Post DeletePost(int id)
    {
      var Post = _context.Posts.Find(id);
      _context.Posts.Remove(Post);
      _context.SaveChanges();
      return Post;
    }
  }
}