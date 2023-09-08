using Domain.Common;

namespace Domain.Entities;

public class Watchlist : BaseAuditableEntity
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public int MovieID { get; set; }
    public bool Watch { get; set; }
    public Movie Movie { get; set; }
}