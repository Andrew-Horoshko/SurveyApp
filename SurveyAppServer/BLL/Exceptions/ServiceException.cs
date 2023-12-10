namespace BLL.Exceptions;

public class ServiceException : Exception 
{
    public int StatusCode { get; set; }

    public ServiceException(string message, int code) : base(message)
    {
        StatusCode = code;
    }
}