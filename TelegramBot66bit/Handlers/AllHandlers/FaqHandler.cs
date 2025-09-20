using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot66bit.Handlers;

public class FaqHandler
{
    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        await bot.SendMessage(
            chatId: chatId,
            text: "По всем вопросам обращайтесь к @Tatiana66bit или посетите https://practice.66bit.ru",
            cancellationToken: token);
    }
}