using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot66bit.Handlers;

public class HandleCallbackAsync1
{
    public async Task HandleCallbackAsync(CallbackQuery callback, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = callback.Message.Chat.Id;
        var data = callback.Data;

        if (data.StartsWith("vacancy_"))
        {
            var parts = data.Replace("vacancy_", "").Split('|');
            string title = parts[0];
            string taskUrl = parts.Length > 1 && !string.IsNullOrEmpty(parts[1]) ? parts[1] : null;

            string response =
                $"📌 <b>{title}</b>\n\n" +
                (taskUrl != null
                    ? $"📄 <a href=\"{taskUrl}\">Задание</a>\n"
                    : "📄 Задание не найдено.\n") +
                $"💬 Для записи на практику — напишите @Tatiana66bit";

            await bot.SendMessage(
                chatId,
                response,
                parseMode: ParseMode.Html,
                cancellationToken: token);
        }
    }
}