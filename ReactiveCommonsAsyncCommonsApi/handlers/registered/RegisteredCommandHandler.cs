using Lombok.NET;

namespace ReactiveCommonsAsyncCommonsApi.registered;


public partial class RegisteredCommandHandler<T> : IHandler
{
    private string path { get; set; }
    private ICommandHandler<T> handler { get; set; }
    private Type inputClass { get; set; }
    
    public RegisteredCommandHandler(string path, ICommandHandler<T> handler, Type inputClass)
    {
        this.path = path;
        this.handler = handler;
        this.inputClass = inputClass;
    }
}