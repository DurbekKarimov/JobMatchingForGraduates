using JobMatchingForGraduates.Domain.Commons;

namespace JobMatchingForGraduates.Domain.Entities;

public class Company : Auditable
{
    public long Id { get; set; }

    public string CompanyName { get; set; }

    public string Email {  get; set; }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }
}
