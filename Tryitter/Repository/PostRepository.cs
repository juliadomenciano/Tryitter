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

    public Post GetPostById(int id)
    {
      return _context.Posts.Where(s => s.PostId == id).First();
    }
    public IEnumerable<Post> GetPosts()
    {
      return _context.Posts.ToList();
    }
    public Post AddPost(Post Post)
    {
      _context.Posts.Add(Post);
      _context.SaveChanges();
      return Post;
    }
    public Post UpdatePost(Post Post, Post PostNewInfo)
    {
      // Post.Name = PostNewInfo.Name;
      // Post.Email = PostNewInfo.Email;
      // Post.Password = PostNewInfo.Password;
      // Post.Status = PostNewInfo.Status;
      // Post.ModuleId = PostNewInfo.ModuleId;
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
    public Post GetPostByName(string name)
    {
      var Post = _context.Posts.Where(s => s.Name.Contains(name)).First();
      return Post;
    }
  }
}