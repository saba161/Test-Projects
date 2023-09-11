using API.Controllers;
using Application.Blogs.Commands.Create;
using Application.Blogs.Commands.Delete;
using Application.Blogs.Commands.Update;
using Application.Blogs.Queries.GetById;
using Application.Blogs.Queries.Search;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exception.Blog;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test;

public class BlogControllerTests
{
    [Fact]
    public async Task CreateBlog_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);
        var command = new CreateBlogCommand { Title = "Test Blog", Description = "Test Description" };

        // Act
        var result = await controller.CreateBlog(command);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetBlogById_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var blogId = 999; // Replace with an invalid blog ID

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();
        var mockContext = new Mock<IApplicationDbContext>();
        var mockMapper = new Mock<IMapper>();

        mockContext.Setup(c => c.Blogs.FindAsync(blogId))
            .ReturnsAsync((Blog)null); // Mock that the blog is not found

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);
        var query = new GetBlogQuery { Id = blogId };

        // Act
        var result = await controller.GetBlogById(query);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteBlog_ValidId_ReturnsOk()
    {
        // Arrange
        var blogId = 1; // Replace with a valid blog ID

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        mockMediator.Setup(m => m.Send(It.IsAny<DeleteBlogCommand>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);

        // Act
        var result = await controller.DeleteBlog(blogId);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        mockMediator.Verify(m => m.Send(It.IsAny<DeleteBlogCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteBlog_InvalidId_ReturnsBadRequest()
    {
        // Arrange
        var blogId = 999; // Replace with an invalid blog ID

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        // Simulate that DeleteBlogCommand might throw BlogNotFoundException
        mockMediator.Setup(m => m.Send(It.IsAny<DeleteBlogCommand>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new BlogNotFoundException(blogId));

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);

        // Act
        var result = await controller.DeleteBlog(blogId);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task UpdateBlog_ValidRequest_ReturnsOk()
    {
        // Arrange
        var updateCommand = new UpdateBlogCommand
        {
            // Set properties in the updateCommand to represent a valid update request
        };

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        mockMediator.Setup(m => m.Send(updateCommand, It.IsAny<CancellationToken>()))
            .Verifiable();

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);

        // Act
        var result = await controller.UpdateBlog(updateCommand);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        mockMediator.Verify(m => m.Send(updateCommand, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateBlog_InvalidRequest_ReturnsBadRequest()
    {
        // Arrange
        var updateCommand = new UpdateBlogCommand
        {
            // Set properties in the updateCommand to represent an invalid update request
        };

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        // Simulate that _mediator.Send might throw an exception
        mockMediator.Setup(m => m.Send(updateCommand, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Some error message"));

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);

        // Act
        var result = await controller.UpdateBlog(updateCommand);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task GetAllBlogs_ValidQuery_ReturnsOk()
    {
        // Arrange
        var searchQuery = new SearchBlogQuery
        {
            // Set properties in the searchQuery to represent a valid query
        };

        var expectedResult = new List<SearchBlogQueryResponse>
        {
            // Create and add valid response objects to represent the expected result
        };

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        mockMediator.Setup(m => m.Send(searchQuery, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);

        // Act
        var result = await controller.GetAllBlogs(searchQuery);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<List<SearchBlogQueryResponse>>(okResult.Value);
        Assert.Equal(expectedResult, response);
    }

    [Fact]
    public async Task GetAllBlogs_InvalidQuery_ReturnsBadRequest()
    {
        // Arrange
        var searchQuery = new SearchBlogQuery
        {
            // Set properties in the searchQuery to represent an invalid query
        };

        var mockMediator = new Mock<IMediator>();
        var mockLogger = new Mock<ILogger<BlogController>>();

        // Simulate that _mediator.Send might throw an exception
        mockMediator.Setup(m => m.Send(searchQuery, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Some error message"));

        var controller = new BlogController(mockMediator.Object, mockLogger.Object);

        // Act
        var result = await controller.GetAllBlogs(searchQuery);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestResult>(result);
    }
}