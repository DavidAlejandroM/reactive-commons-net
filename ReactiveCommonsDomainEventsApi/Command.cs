using Lombok.NET;

namespace ReactiveCommonsDomainEventsApi;

[ToString]
[AllArgsConstructor]
public partial class Command<T>
{
    [Property]
    private string name;
    [Property]
    private string commandId;
    [Property]
    private T data;
}