// using System.ComponentModel.DataAnnotations;
// using FluentAssertions;
// using Xunit;

// namespace tryitter.Models.Tests
// {
//     public class TryitterTestLogin
//     {
//         [Fact]
//         public void Email_ShouldBeRequired()
//         {
//             // Arrange
//             var login = new Login();

//             // Act
//             var result = login.ValidateProperty(nameof(Login.Email));

//             // Assert
//             result.Should().ContainSingle()
//                 .Which.ErrorMessage.Should().Be("The Email field is required.");
//         }

//         [Theory]
//         [InlineData("invalidemail")]
//         [InlineData("emailwithoutat.com")]
//         public void Email_ShouldBeValidEmailAddress(string email)
//         {
//             // Arrange
//             var login = new Login
//             {
//                 Email = email
//             };

//             // Act
//             var result = login.ValidateProperty(nameof(Login.Email));

//             // Assert
//             result.Should().ContainSingle()
//                 .Which.ErrorMessage.Should().Be("The Email field is not a valid e-mail address.");
//         }

//         [Fact]
//         public void Password_ShouldBeRequired()
//         {
//             // Arrange
//             var login = new Login();

//             // Act
//             var result = login.ValidateProperty(nameof(Login.Password));

//             // Assert
//             result.Should().ContainSingle()
//                 .Which.ErrorMessage.Should().Be("The Password field is required.");
//         }

//         [Theory]
//         [InlineData("short")]
//         [InlineData("1234567")]
//         public void Password_ShouldHaveMinLengthOfEight(string password)
//         {
//             // Arrange
//             var login = new Login
//             {
//                 Password = password
//             };

//             // Act
//             var result = login.ValidateProperty(nameof(Login.Password));

//             // Assert
//             result.Should().ContainSingle()
//                 .Which.ErrorMessage.Should().Be("Password must be at least 8 characters long");
//         }
//     }
// }
