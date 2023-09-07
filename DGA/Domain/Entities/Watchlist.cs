namespace Domain.Entities;

public class Watchlist
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public List<Movie> Movies { get; set; }
}