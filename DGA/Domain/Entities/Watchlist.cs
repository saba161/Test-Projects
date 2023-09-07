using Domain.Common;

namespace Domain.Entities;

public class Watchlist : BaseAuditableEntity
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public int MovieID { get; set; }
    
    public Movie Movie { get; set; }
}