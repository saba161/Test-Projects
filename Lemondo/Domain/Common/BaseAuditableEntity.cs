namespace Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset LastModified { get; set; }
}