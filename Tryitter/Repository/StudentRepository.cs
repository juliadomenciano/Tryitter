using tryitter.Models;

namespace tryitter.Repository
{
  public class StudentRepository
  {
    protected readonly TryitterContext _context;
    public StudentRepository (TryitterContext context)
    {
      _context = context;
    }

    public Student Login(string email, string password)
    {
      return _context.Students.Where(s => s.Email == email && s.Password == password).First();
    }
    public Student GetStudentById(int id)
    {
      return _context.Students.Where(s => s.StudentId == id).First();
    }
    public IEnumerable<Student> GetStudents()
    {
      return _context.Students.ToList();
    }
    public Student AddStudent(Student Student)
    {
      _context.Students.Add(Student);
      _context.SaveChanges();
      return Student;
    }
    public Student UpdateStudent(Student student, Student studentNewInfo)
    {
      student.Name = studentNewInfo.Name;
      student.Email = studentNewInfo.Email;
      student.Password = studentNewInfo.Password;
      student.Status = studentNewInfo.Status;
      student.ModuleId = studentNewInfo.ModuleId;
      _context.SaveChanges();
      return student;
    }
    public Student DeleteStudent(int id)
    {
      var student = _context.Students.Find(id);
      _context.Students.Remove(student);
      _context.SaveChanges();
      return student;
    }
    public Student GetStudentByName(string name)
    {
      var student = _context.Students.Where(s => s.Name.Contains(name)).First();
      return student;
    }
  }
}