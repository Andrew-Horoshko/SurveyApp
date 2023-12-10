using System.Net;

namespace BLL.Exceptions;

public class EntityNotFoundException : ServiceException
{
    public EntityNotFoundException(string target) 
        : base($"{target} not found", (int)HttpStatusCode.NotFound) { }
    
    public EntityNotFoundException(string target, int id) 
        : base($"{target} with id {id} is not found", (int)HttpStatusCode.NotFound) { }
}