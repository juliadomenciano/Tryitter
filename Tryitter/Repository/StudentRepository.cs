using tryitter.Models;

namespace tryitter.Repository
{
  public class StudentRepository
  {
    private readonly TryitterContext _context;
    public StudentRepository (TryitterContext context)
    {
      _context = context;
    }
    public Student GetStudentById(int id)
    {
      return _context.Students.Find(id);
    }
    public IEnumerable<Student> GetStudents()
    {
      return _context.Students;
    }
    public Student AddStudent(Student Student)
    {
      _context.Students.Add(Student);
      _context.SaveChanges();
      return Student;
    }
    public Student UpdateStudent(Student Student)
    {
      _context.Students.Update(Student);
      _context.SaveChanges();
      return Student;
    }
    public Student DeleteStudent(int id)
    {
      var student = _context.Students.Find(id);
      _context.Students.Remove(student);
      _context.SaveChanges();
      return student;
    }
  }
}