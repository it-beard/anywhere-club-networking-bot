using Anywhere.DiscordBot;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Anywhere.Bot.DiscordClient;

public class Program
{
    public static Task Main() => new Program().MainAsync();
    private DiscordSocketClient client;
    private async Task MainAsync()
    {
        client = new DiscordSocketClient();
        client.Log += Log;
        
        var token = Environment.GetEnvironmentVariable("ANYWHERE_DISCORD_BOT_KEY");

        await client.LoginAsync(TokenType.Bot, token);
        await client.StartAsync();
        client.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };
        client.ButtonExecuted += ButtonsHandler;
        client.ModalSubmitted += ModalHandler;
        
        // Create, initialize (and start) command handler
        var commandService = new CommandService();
        var commandHandler = new CommandHandler(client, commandService);
        await commandHandler.InstallCommandsAsync();

        // Block boot app until the program is closed.
        await Task.Delay(-1);
    }

    private async Task ButtonsHandler(SocketMessageComponent component)
    {
        switch(component.Data.CustomId)
        {
            case Settings.BUTTON_START_RU:
                await component.RespondWithModalAsync(Modals.UserInfoCardRu());
                break;
        }
    }
    
    private async Task ModalHandler(SocketModal modal)
    {
        switch (modal.Data.CustomId)
        {
            case Settings.MODAL_USERCARD_RU:
                // Create User Info card.
                List<SocketMessageComponentData> components =
                    modal.Data.Components.ToList();
                var name = components
                    .First(x => x.CustomId == "name").Value;
                var specialization = components
                    .First(x => x.CustomId == "specialization").Value;
                var experience = components
                    .First(x => x.CustomId == "experience").Value;
                var kindOfRequest = components
                    .First(x => x.CustomId == "kind_of_request").Value;

                var userInfoCard =
                    $"Имя: {name} ({modal.User.Mention})" + Environment.NewLine +
                    $"Род занятий: {specialization}" + Environment.NewLine +
                    $"Опыт: {experience}" + Environment.NewLine +
                    $"Что ищет: {kindOfRequest}";
                
                // Add "networker" role to user
                var guild = client.GetGuild(Settings.ANYWHERE_GUILD_ID);
                var allUsers = await guild.GetUsersAsync().ToListAsync();
                var user = allUsers[0].FirstOrDefault(u=>u.Id == modal.User.Id);
        
                var role = guild.Roles.FirstOrDefault(x => x.Name.ToString() == Settings.NETWORKER_ROLE_NAME);
                await user.AddRoleAsync(role);
                
                // Respond to the chat with the User Info card.
                var channel = guild.GetChannel(Settings.CARD_CHANNEL_ID) as IMessageChannel;
                await channel.SendMessageAsync(userInfoCard);
                
                // Respond to the user.
                await modal.RespondAsync(
                    $"Спасибо! Твой меседж опубликован в канале #{channel.Name}. " + Environment.NewLine + 
                    $"Запрыгивай, может кто то, кто будет тебе интересен, уже оставил свой месседж :sunglasses:");
                break;
        }
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}