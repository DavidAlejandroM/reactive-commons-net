namespace ReactiveCommonsAsyncCommonsApi;

public interface IGenericHandler<T, M>
{
    T Handler(M var);
}