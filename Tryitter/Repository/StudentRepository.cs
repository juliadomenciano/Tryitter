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
    public StudentResponse GetStudentById(int id)
    {
      var student = _context.Students.Where(s => s.StudentId == id).First();
      return new StudentResponse
      {
        StudentId = student.StudentId,
        Name = student.Name,
        Status = student.Status,
        ModuleId = student.ModuleId
      };
    }
    public IEnumerable<StudentResponse> GetStudents()
    {
      var students = _context.Students.ToList();
      var response = new List<StudentResponse>();
      foreach (Student student in students)
            {
                response.Add(new StudentResponse
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Status = student.Status,
                    ModuleId = student.ModuleId
                });
            }
      return response;

    }
    public string AddStudent(Student Student)
    {
      _context.Students.Add(Student);
      _context.SaveChanges();
      return "Student created";
    }
    public string UpdateStudent(int id, Student studentNewInfo)
    {
      var student = _context.Students.Where(s => s.StudentId == id).First();
      student.Name = studentNewInfo.Name;
      student.Email = studentNewInfo.Email;
      student.Password = studentNewInfo.Password;
      student.Status = studentNewInfo.Status;
      student.ModuleId = studentNewInfo.ModuleId;
      _context.SaveChanges();
      return "Student updated";
    }
    public string DeleteStudent(int id)
    {
      var student = _context.Students.Find(id);
      _context.Students.Remove(student);
      _context.SaveChanges();
      return "Student deleted";
    }
    public StudentResponse GetStudentByName(string name)
    {
      var student = _context.Students.Where(s => s.Name.Contains(name)).First();
      return new StudentResponse
      {
        StudentId = student.StudentId,
        Name = student.Name,
        Status = student.Status,
        ModuleId = student.ModuleId
      };
    }
  }
}