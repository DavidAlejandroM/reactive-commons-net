using Lombok.NET;

namespace ReactiveCommonsAsyncCommonsApi.registered;

public class RegisteredQueryHandler<T, C> : IHandler
{
    private string path { get; set; }
    private IQueryHandlerDelegate<T, C> handler { get; set; }
    private Type inputClass { get; set; }
    
    public RegisteredQueryHandler(string path, IQueryHandlerDelegate<T, C> handler, Type inputClass)
    {
        this.path = path;
        this.handler = handler;
        this.inputClass = inputClass;
    }
}