using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot66bit.Handlers;

public class StartHandler : IMessageHandler
{
    public bool CanHandle(string message) =>
        message.StartsWith("/start", StringComparison.OrdinalIgnoreCase);

    public async Task Handle(string message, long chatId, ITelegramBotClient bot)
    {
        await bot.SendMessage(chatId, "<b>Привет, я бот образовательных программ 66бит!</b>",
            ParseMode.Html,
            protectContent: true);
        await Task.Delay(1000);

        await bot.SendMessage(chatId, "Смотрите /help для доступных команд");
    }
}