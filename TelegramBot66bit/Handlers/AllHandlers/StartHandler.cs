using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot66bit.Handlers;

public class StartHandler
{
    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        string startText =
            "<b>👋 Добро пожаловать в Telegram-бот 66bit!</b>\n\n" +
            "Я помогу тебе узнать всё о наших направлениях, практике и компании.\n" +
            "Вот что я умею:\n\n" +
            "📌 <b>/vacancies</b> — список направлений и количество мест\n" +
            "🎓 <b>/practice</b> — как проходит практика\n" +
            "🏢 <b>/about</b> — кто мы такие и чем живём\n" +
            "❓ <b>/faq</b> — часто задаваемые вопросы\n\n" +
            "Для полного списка команд — набери <b>/help</b>\n\n" +
            "Рад, что ты с нами! 🚀";

        await bot.SendMessage(
            chatId: chatId,
            text: startText,
            parseMode: ParseMode.Html,
            cancellationToken: token);
    }
}