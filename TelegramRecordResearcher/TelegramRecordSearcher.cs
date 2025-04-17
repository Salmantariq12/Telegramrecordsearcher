using TelegramRecordSearcher.Models;

namespace TelegramRecordSearcher
{
    public class TelegramRecordSearcher
    {
        private readonly string _botToken;

        public TelegramRecordSearcher(string botToken)
        {
            _botToken = botToken;
        }

        public async Task<List<MessageMatch>> GetMessagesAsync(string channelName)
        {
            var handler = new TelegramSearchService(_botToken);

            var messages = await handler.GetAllPostsAsync(channelName);

            var messageMatches = messages.Select(message => new MessageMatch
            {
                Content = message.Text ?? "No content",
                Date = message.Date,
                User = message.Chat.Title ?? "Unknown"
            }).ToList();

            return messageMatches;
        }

        public async Task<List<MessageMatch>> SearchMessagesAsync(string channelName, string searchString)
        {
            var handler = new TelegramSearchService(_botToken);

            var searchResults = await handler.SearchChannelAsync(channelName, searchString);

            var messageMatches = searchResults.Select(message => new MessageMatch
            {
                Content = message.Text ?? "No content",
                Date = message.Date,
                User = message.Chat.Title ?? "Unknown"
            }).ToList();

            return messageMatches;
        }
    }
}
