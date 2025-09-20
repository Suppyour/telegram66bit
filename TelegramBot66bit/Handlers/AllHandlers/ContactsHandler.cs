using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot66bit.Handlers;

public class ContactsHandler
{
    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        string contactsText =
            "<b>📞 Контакты</b>\n\n" +
            "📱 Телефон: <b>+7 343 290 84 76</b>\n" +
            "📧 Email: <b>info@66bit.ru</b>\n\n" +
            "🌐 Сайт: <a href=\"https://practice.66bit.ru\">practice.66bit.ru</a>\n" +
            "💬 Telegram: <a href=\"https://t.me/Tatiana66bit\">@Tatiana66bit</a>";

        await bot.SendMessage(
            chatId: chatId,
            text: contactsText,
            parseMode: ParseMode.Html,
            cancellationToken: token);
    }
}