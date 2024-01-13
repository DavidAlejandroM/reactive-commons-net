using Lombok.NET;

namespace ReactiveCommonsAsyncCommonsApi.registered;

public class RegisteredEventListener<T> : IHandler
{
    private string path { get; set; }
    private IEventHandler<T> handler { get; set; }
    private Type inputClass { get; set; }
    
    public RegisteredEventListener(string path, IEventHandler<T> handler, Type inputClass)
    {
        this.path = path;
        this.handler = handler;
        this.inputClass = inputClass;
    }
}