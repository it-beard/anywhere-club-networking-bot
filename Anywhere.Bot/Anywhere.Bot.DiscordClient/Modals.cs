

using Anywhere.Bot.DiscordClient;
using Discord;

namespace Anywhere.DiscordBot;

public static class Modals
{
    public static Modal UserInfoCardRu()
    {
        var mb = new ModalBuilder()
            .WithCustomId(Settings.MODAL_USERCARD_RU)
            .WithTitle("Расскажи о себе")
            .AddTextInput(
                label: "Как тебя зовут?", 
                customId: "name",
                placeholder: "Дженкинс Вебстер",
                required: true)
            .AddTextInput(
                label: "Кем ты работаешь?", 
                customId: "specialization", 
                style: TextInputStyle.Paragraph,
                placeholder:"Комьюнити-менеджер",
                required: true)
            .AddTextInput(
                label: "Какой у тебя опыт?",
                placeholder: "Опиши несколькими фразами свой опыт и знания, " +
                       "а также чем ты можешь быть полезен community", 
                customId: "experience", 
                style: TextInputStyle.Paragraph,
                required: true)
            .AddTextInput(
                label: "С кем бы хотел познакомиться?", 
                customId: "kind_of_request", 
                style: TextInputStyle.Paragraph,
                placeholder: "Расскажи кого и для чего ищешь в нашем комьюнити",
                required: true);
        return mb.Build();
    }
}