using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot66bit.Handlers;

public class PracticeHandler
{
    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        string practiceText =
            "<b>🎓 О практике</b>\n\n" +
            "📅 <b>Ты сам выбираешь дату</b> прохождения практики\n" +
            "🏠 Практику можно пройти <b>в офисе</b> или <b>удалённо</b>\n" +
            "💼 При успешном прохождении — <b>трудоустройство с гибким графиком</b> (от 20 часов в неделю)\n" +
            "🧭 У тебя будет <b>куратор</b>, который поможет и направит\n\n" +
            "Погружаемся в реальную разработку — с поддержкой и перспективой!";

        await bot.SendMessage(
            chatId: chatId,
            text: practiceText,
            parseMode: ParseMode.Html,
            cancellationToken: token);
    }
}