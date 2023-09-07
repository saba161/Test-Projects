using MediatR;

namespace Application.Movies.Commands.DeleteMovie;

public record DeleteMovieCommand(int Id) : IRequest;