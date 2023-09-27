using JobMatchingForGraduates.Domain.Commons;

namespace JobMatchingForGraduates.Domain.Entities;

public class Student : Auditable
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Direction { get; set; }
}
