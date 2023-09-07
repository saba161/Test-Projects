using MediatR;

namespace Application.Movies.Commands.Create;

public record CreateMovieCommand : IRequest<int>
{
    public string Title { get; set; }
    
    public int ReleaseYear { get; set; }

    public string Genre { get; set; }

    public string Director { get; set; }
    

    public decimal Rating { get; set; }
    
    public string Description { get; set; }
}