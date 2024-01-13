namespace ReactiveCommons.api;

public class From
{
    private string ReplyId { get; set; }
    private string CorrelationId { get; set; }

    public From(string replyId, string correlationId)
    {
        this.ReplyId = replyId;
        this.CorrelationId = correlationId;
    }

    public void SetReplyId(string replyId)
    {
        this.ReplyId = replyId;
    }

    public void SetCorrelationId(string correlationId)
    {
        this.CorrelationId = correlationId;
    }
}