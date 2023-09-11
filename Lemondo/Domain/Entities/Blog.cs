using Domain.Common;

namespace Domain.Entities;

public class Blog : BaseAuditableEntity
{
    public string Title { get; set; }

    public string Description { get; set; }
}