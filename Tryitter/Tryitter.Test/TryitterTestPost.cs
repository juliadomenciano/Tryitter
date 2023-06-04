using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentAssertions;
using Xunit;

namespace tryitter.Models.Tests
{
    public class TryitterTestPost
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("123456789101112131415161718192021222324252627282930313334")]
        public void Title_ShouldHaveLengthBetween3And50(string title)
        {
            // Arrange
            var post = new Post { Title = title };

            // Act
            Action act = () => post.Title.Should()
                .NotBeNullOrEmpty()
                .And.HaveLengthBetween(3, 50);

            // Assert
            act.Should().Throw<Exception>()
                .WithMessage("Expected post.Title to have a length between 3 and 50, but found " + (title?.Length ?? 0) + ".");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Text_ShouldHaveLengthBetween3And300(string text)
        {
            // Arrange
            var post = new Post { Text = text };

            // Act
            Action act = () => post.Text.Should()
                .NotBeNullOrEmpty()
                .And.HaveLengthBetween(3, 300);

            // Assert
            act.Should().Throw<Exception>()
                .WithMessage("Expected post.Text to have a length between 3 and 300, but found " + (text?.Length ?? 0) + ".");
        }

        [Fact]
        public void Title_ShouldBeRequired()
        {
            // Arrange
            var post = new Post();

            // Act
            Action act = () => post.Title.Should().NotBeNull();

            // Assert
            act.Should().Throw<Exception>()
                .WithMessage("Expected post.Title to not be <null>.");
        }

        [Fact]
        public void Text_ShouldBeRequired()
        {
            // Arrange
            var post = new Post();

            // Act
            Action act = () => post.Text.Should().NotBeNull();

            // Assert
            act.Should().Throw<Exception>()
                .WithMessage("Expected post.Text to not be <null>.");
        }

        [Fact]
        public void StudentId_ShouldHaveForeignKeyAttribute()
        {
            // Arrange
            var propertyInfo = typeof(Post).GetProperty(nameof(Post.StudentId));

            // Act
            var attribute = propertyInfo.GetCustomAttributes(typeof(ForeignKeyAttribute), true);

            // Assert
            attribute.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("Valid Title", "Valid Text", 1)]
        public void ValidPost_ShouldNotThrowException(string title, string text, int studentId)
        {

            var student = new Student
            {
                StudentId = 1,
                Name = "John Doe",
                Email = "john@example.com",
                Password = "password",
                Status = "Active",
                ModuleId = 1,
                Module = new Module(),
                Posts = new List<Post>()
            };
          
            // Arrange
            var post = new Post
            {
                Title = title,
                Text = text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                StudentId = studentId,
                Student = new Student()
            };

            // Act & Assert
            post.Invoking(p => p.Should().BeValid())
                .Should().NotThrow();
        }
    }
}
