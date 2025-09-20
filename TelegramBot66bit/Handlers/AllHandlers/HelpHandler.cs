using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot66bit.Handlers;

public class HelpHandler
{
    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        string helpText =
            "📌 Доступные команды:\n" +
            "/help — список команд\n" +
            "/faq — часто задаваемые вопросы\n" +
            "/vacancies — направления и количество мест\n" +
            "/about — информация о компании\n" +
            "/practice — информация о практике\n" +
            "/contacts — наши контакты";

        await bot.SendMessage(
            chatId: chatId,
            text: helpText,
            cancellationToken: token);
    }
}