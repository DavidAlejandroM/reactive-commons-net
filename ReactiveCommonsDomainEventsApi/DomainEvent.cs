using Lombok.NET;

namespace ReactiveCommonsDomainEventsApi;

[ToString]
[AllArgsConstructor]
public partial class DomainEvent<T>
{
    [Property]
    private string name;
    [Property]
    private string eventId;
    [Property]
    private T data;
}