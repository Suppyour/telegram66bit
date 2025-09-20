using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot66bit.Handlers;

public class AboutHandler
{
    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        string aboutText =
            "<b>🏢 О нас</b>\n\n" +
            "📅 Работаем с <b>2004 года</b>\n" +
            "💻 Занимаемся <b>заказной разработкой</b>\n" +
            "📍 Офис в <b>центре Екатеринбурга (ул. Добролюбова 16)</b>\n" +
            "👥 <b>Молодой и дружный коллектив</b>\n" +
            "🍫 Вкусняшки и напитки в офисе\n" +
            "🎉 <b>Корпоративы для всех</b>\n\n" +
            "Присоединяйся к нам — будет интересно!";

        string imageUrl = "https://practice.66bit.ru/static/img/pics/company.png";

        await bot.SendPhoto(
            chatId: chatId,
            photo: InputFile.FromUri(imageUrl),
            caption: aboutText,
            parseMode: ParseMode.Html,
            cancellationToken: token);
    }
}