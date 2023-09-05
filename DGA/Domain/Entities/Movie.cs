using Domain.Common;

namespace Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public int Id { get; set; }
}