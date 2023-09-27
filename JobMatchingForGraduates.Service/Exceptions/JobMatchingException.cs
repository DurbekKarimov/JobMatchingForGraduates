namespace JobMatchingForGraduates.Service.Exceptions;

public class JobMatchingException : Exception
{
    public int StatusCode { get; set; }

    public JobMatchingException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
