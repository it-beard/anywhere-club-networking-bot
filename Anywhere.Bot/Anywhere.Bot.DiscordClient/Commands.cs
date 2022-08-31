using Discord;
using Discord.Commands;

namespace Anywhere.Bot.DiscordClient.Modules;

public class Commands : ModuleBase<SocketCommandContext>
{
    [Command("старт")]
    public async Task Start()
    {
        var builder = new ComponentBuilder()
            .WithButton("Начать!", Settings.BUTTON_START_RU);

        await ReplyAsync(
            "Привет! " + Environment.NewLine +
            "Я нетворкинг-мастер сервера \"Anywhere Club\" и помогу попасть тебе в закрытые каналы для нетворкинга." + Environment.NewLine +
            "Чтобы попасть на эти каналы, мне нужно немного лучше узнать тебя." + Environment.NewLine +
            "Нажми на кнопку \"**Начать!**\" и ответь на несколько вопросов." + Environment.NewLine +
            "После этого я смогу добавить тебя в наши нетворкинг-каналы :blush:", components: builder.Build());
    }
}