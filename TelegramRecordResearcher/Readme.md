📚 README for Telegram Record Searcher

📝 Project Overview
	This project allows you to:
		Fetch all messages from a Telegram channel after adding the bot. Search through those messages using a keyword.

🚀 Setup Instructions
	1: Create a Telegram Bot
	   Before you can use this bot, you need to create one via BotFather on Telegram.
		Step 1: Open BotFather
			Open Telegram and search for BotFather.
			Start a chat with BotFather: BotFather
		Step 2: Create a New Bot
			Send the command /newbot.
			Follow the instructions to give your bot a name and a username (must end with "bot", e.g., MyCoolBot).
		Step 3: Get the Bot Token
			Once the bot is created, BotFather will send you a message with the bot’s API token. It will look something like this:
			123456789:ABCDabcdEFGHijklMNOpqrstuvWxyz
			Save this token — you'll need it to interact with the Telegram Bot.
	2: Add Your Bot to a Channel
		Step 1: Open Your Channel
			Open your Telegram app and navigate to your channel.
			If it’s a private channel, you need to invite your bot to the channel and grant the "Read Messages" permission.
		Step 2: Add the Bot to the Channel
			Open your channel settings. Select Administrators. Click on Add Admin. Search for your bot (by its username, e.g., @MyCoolBot). Add it as an admin and give it permissions to read messages.
			💡 Important: The bot can only read messages in the channel after it’s added. It cannot fetch historical messages that were sent before it joined.


Example Code to Call TelegramRecordSearcher:

var botToken = "YOUR_BOT_TOKEN_HERE";  // Replace with your bot token
var service = new TelegramRecordSearcher(botToken);

var channelName = "your_channel_name";  // Replace with the channel's username (without @)
var searchString = "your search text";  // Replace with the text you want to search for

// Fetch all messages from the channel
var results = await service.GetMessagesAsync(channelName);

// Search messages in the channel for a specific string
var searchResults = await service.SearchMessagesAsync(channelName, searchString);

Methods Explained:
GetMessagesAsync(channelName)
This method retrieves all messages from a specified channel and stores them in memory.

SearchMessagesAsync(channelName, searchString)
This method allows you to search through the stored messages for a specific string.