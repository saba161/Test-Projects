using Application.Blogs.Commands.Create;
using Application.Interfaces;
using FluentValidation;
using Moq;

namespace Test;

public class CreateBlogCommandHandlerTests
{
    [Fact]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Arrange
        var mockDbContext = new Mock<IApplicationDbContext>();
        var handler = new CreateBlogCommandHandler(mockDbContext.Object);
        var command = new CreateBlogCommand(); // Invalid request with missing Title and Description

        // Act & Assert
        await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));
        mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}