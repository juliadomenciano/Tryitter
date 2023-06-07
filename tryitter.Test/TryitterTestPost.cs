using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentAssertions;
using Xunit;

namespace tryitter.Models.Tests
{
    public class TryitterTestPost
    {

        [Fact]
        public void Title_ShouldBeRequired()
        {
            // Arrange
            var post = new Post();

            // Act
            Action act = () => post.Title.Should().NotBeNull();

            // Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Text_ShouldBeRequired()
        {
            // Arrange
            var post = new Post();

            // Act
            Action act = () => post.Text.Should().NotBeNull();

            // Assert
            act.Should().Throw<Exception>();
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

        // [Theory]
        // [InlineData("Valid Title", "Valid Text", 1)]
        // public void ValidPost_ShouldNotThrowException(string title, string text, int studentId)
        // {

        //     var student = new Student
        //     {
        //         StudentId = 1,
        //         Name = "John Doe",
        //         Email = "john@example.com",
        //         Password = "password",
        //         Status = "Active",
        //         ModuleId = 1,
        //         Module = new Module(),
        //         Posts = new List<Post>()
        //     };
          
        //     // Arrange
        //     var post = new Post
        //     {
        //         Title = title,
        //         Text = text,
        //         CreatedAt = DateTime.Now,
        //         UpdatedAt = DateTime.Now,
        //         StudentId = studentId,
        //         Student = new Student()
        //     };

        //     // Act & Assert
        //     post.Invoking(p => p.Should().BeValid())
        //         .Should().NotThrow();
        // }
    }
}
