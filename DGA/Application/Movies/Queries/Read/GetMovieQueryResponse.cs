namespace Application.Movies.Queries.GetMovie;

public class GetMovieQueryResponse
{
    public string Title { get; set; }

    public int ReleaseYear { get; set; }

    public string Genre { get; set; }

    public string Director { get; set; }


    public decimal Rating { get; set; }

    public string Description { get; set; }
}