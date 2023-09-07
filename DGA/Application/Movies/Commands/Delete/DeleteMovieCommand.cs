using MediatR;

namespace Application.Movies.Commands.Delete;

public record DeleteMovieCommand(int Id) : IRequest;