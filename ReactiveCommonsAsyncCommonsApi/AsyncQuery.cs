using Lombok.NET;

namespace ReactiveCommons.api;

[ToString]
[AllArgsConstructor]
public partial class AsyncQuery<T>
{
    [Property] private string resource;
    [Property] private T queryData;
}