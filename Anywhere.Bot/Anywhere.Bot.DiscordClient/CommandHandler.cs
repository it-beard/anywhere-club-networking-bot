using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;

namespace Anywhere.Bot.DiscordClient;

public class CommandHandler
{
    private readonly DiscordSocketClient client;
    private readonly CommandService commands;

    public CommandHandler(DiscordSocketClient client, CommandService commands)
    {
        this.commands = commands;
        this.client = client;
    }
    
    public async Task InstallCommandsAsync()
    {
        client.MessageReceived += HandleCommandAsync;
        await commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
    }

    private async Task HandleCommandAsync(SocketMessage messageParam)
    {
        // Don't process the command if it was a system message
        if (messageParam is not SocketUserMessage message)
        {
            return;
        }
        
        // Don't process non DM (direct message) messages
        if (message.Channel is not SocketDMChannel)
        {
            return;
        }

        // Determine if the message is a command based on the prefix
        // and make sure no bots trigger commands
        var argPos = 0;
        if (!(message.HasCharPrefix('!', ref argPos) ||
              message.HasMentionPrefix(client.CurrentUser, ref argPos)) ||
            message.Author.IsBot)
        {
            return;
        }

        // Create a WebSocket-based command context based on the message
        var context = new SocketCommandContext(client, message);

        // Execute the command
        await commands.ExecuteAsync(context, argPos, null);
    }
}