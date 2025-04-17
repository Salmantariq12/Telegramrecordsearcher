namespace TelegramRecordSearcher.Models;

public class MessageMatch
{
    public string Content { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string User { get; set; } = string.Empty;
}
