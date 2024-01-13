using Microsoft.Extensions.Logging;

namespace ReactiveCommonsAsyncCommons.utils;

public class LoggerSubscriber<T> : IObserver<T>
{
    private static readonly ILogger Logger = CreateLogger();
    private readonly string _flowName;
    private static readonly string OnCompleteMsg = "{0}: ##On Complete Hook!!";
    private static readonly string OnErrorMsg = "{0}: ##On Error Hook!!";
    private static readonly string OnCancelMsg = "{0}: ##On Cancel Hook!!";
    private static readonly string OnFinallyMsg = "{0}: ##On Finally Hook! Signal type: {1}";

    public LoggerSubscriber(string flowName)
    {
        _flowName = flowName;
    }

    public void OnCompleted()
    {
        Logger.LogWarning(Format(OnCompleteMsg));
    }

    public void OnError(Exception error)
    {
        Logger.LogError(error, Format(OnErrorMsg));
    }

    public void OnNext(T value)
    {
        // Implementa la lógica para manejar un nuevo elemento
    }

    private string Format(string msg, params object[] args)
    {
        return string.Format(msg, ArrayUtils.PrefixArray(_flowName, args));
    }

    private static ILogger<LoggerSubscriber<T>> CreateLogger()
    {
        var loggerFactory = LoggerFactory.Create(builder => { builder.SetMinimumLevel(LogLevel.Information); });

        return loggerFactory.CreateLogger<LoggerSubscriber<T>>();
    }
}