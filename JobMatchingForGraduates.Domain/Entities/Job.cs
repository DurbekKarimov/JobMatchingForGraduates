using JobMatchingForGraduates.Domain.Commons;

namespace JobMatchingForGraduates.Domain.Entities;

public class Job : Auditable
{
    public long Id { get; set; }

    public string JobName { get; set; }

    public decimal Price { get; set; }

    public long ? CompanyId { get; set; }

    public long ? StudentId { get; set; }
}
