using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

class TelegramSearchService
{
    private readonly ITelegramBotClient _botClient;

    public TelegramSearchService(string botToken)
    {
        _botClient = new TelegramBotClient(botToken);
    }

    public async Task<List<Message>> GetAllPostsAsync(string channelName)
    {
        var posts = new List<Message>();

        var updates = await _botClient.GetUpdates(offset: 0, limit: 100, timeout: 0);

        foreach (var update in updates)
        {
            if (update.ChannelPost != null && "@" + update.ChannelPost.Chat.Username == channelName)
            {
                posts.Add(update.ChannelPost);
            }
        }

        return posts;
    }

    public async Task<List<Message>> SearchChannelAsync(string channelName, string searchString)
    {
        var results = new List<Message>();

        var posts = await GetAllPostsAsync(channelName);

        foreach (var post in posts)
        {
            if (post.Text != null && post.Text.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                results.Add(post);
            }
        }

        return results;
    }
}