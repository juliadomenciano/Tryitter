// using FluentAssertions;
// using Xunit;

// namespace Tryitter.Test
// {
//     [TestFixture]
//     public class TryitterTestStudent
//     {
//         [Theory]
//         [InlineData(1, "John Doe", "johndoe@example.com", "Some Module", "Active", "12345678")]
//         [InlineData(2, "Jane Smith", "janesmith@example.com", "Another Module", "Inactive", "abcdefgh")]
//         [DisplayName("CreateStudent_ValidData_Success")]
//         public void CreateStudent_ValidData_Success(int id, string name, string email, string moduleName, string status, string password)
//         {
//             // Arrange
//             var module = new Module
//             {
//                 ModuleId = id,
//                 Name = moduleName
//             };

//             var student = new Student
//             {
//                 StudentId = id,
//                 Name = name,
//                 Email = email,
//                 Module = module,
//                 Status = status,
//                 Password = password,
//                 Posts = new List<Post>()
//             };

//             // Act
//             // No action needed for this test case

//             // Assert
//             student.StudentId.Should().Be(id);
//             student.Name.Should().Be(name);
//             student.Email.Should().Be(email);
//             student.Module.Should().Be(module);
//             student.Status.Should().Be(status);
//             student.Password.Should().Be(password);
//             student.Posts.Should().NotBeNull();
//         }



//         [Theory]
//         [InlineData(1, "John Doe", "johndoexample.com", "Some Module", "Active", "12345678")]
//         [InlineData(2, "Jane Smith", "janesmith.example.com", "Another Module", "Inactive", "abcdefgh")]
//         [DisplayName("CreateStudent_InvalidEmail_Fails")]
//         public void CreateStudent_InvalidEmail_Fails(int id, string name, string email, string moduleName, string status, string password)
//         {
//             // Arrange
//             var module = new Module
//             {
//                 ModuleId = id,
//                 Name = moduleName
//             };

//             var student = new Student
//             {
//                 StudentId = id,
//                 Name = name,
//                 Email = email,
//                 Module = module,
//                 Status = status,
//                 Password = password,
//                 Posts = new List<Post>()
//             };

//             // Act
//             // No action needed for this test case

//             // Assert
//             Action act = () => student.Email.Should().NotBeNullOrEmpty().And.MatchRegex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
//             act.Should().Throw<ArgumentException>();
//         }

//         [Theory]
//         [InlineData(1, "", "johndoe@example.com", "Some Module", "Active", "12345678")]
//         [InlineData(2, "Jane Smith da Silva Jardim Bueno Mascarenhas Trindade", "janesmith", "Another Module", "Inactive", "abcdefgh")]
//         [DisplayName("CreateStudent_InvalidName_Fails")]
//         public void CreateStudent_InvalidName_Fails(int id, string name, string email, string moduleName, string status, string password)
//         {
//             // Arrange
//             var module = new Module
//             {
//                 ModuleId = id,
//                 Name = moduleName
//             };

//             var student = new Student
//             {
//                 StudentId = id,
//                 Name = name,
//                 Email = email,
//                 Module = module,
//                 Status = status,
//                 Password = password,
//                 Posts = new List<Post>()
//             };

//             // Act
//             // No action needed for this test case

//             // Assert
//             Action act = () => student.Name.Should().NotBeNullOrEmpty().And.HaveLengthGreaterThan(0);
//             act.Should().Throw<ArgumentException>();
//         }

//         [Theory]
//         [InlineData(1, "John Doe", "johndoe@example.com", "Some Module", "Active", "123456")]
//         [InlineData(2, "Jane Smith", "janesmith@example.com", "Another Module", "Inactive", "123")] // Invalid password length
//         [DisplayName("CreateStudent_InvalidPassword_Fails")]
//         public void CreateStudent_InvalidPassword_Fails(int id, string name, string email, string moduleName, string status, string password)
//         {
//             // Arrange
//             var module = new Module
//             {
//                 ModuleId = id,
//                 Name = moduleName
//             };

//             var student = new Student
//             {
//                 StudentId = id,
//                 Name = name,
//                 Email = email,
//                 Module = module,
//                 Status = status,
//                 Password = password,
//                 Posts = new List<Post>()
//             };

//             // Act
//             // No action needed for this test case

//             // Assert
//             Action act = () => student.Password.Should().NotBeNullOrEmpty().And.HaveLengthLessThan(8);
//             act.Should().Throw<ArgumentException>();
//         }

//     }
// }
