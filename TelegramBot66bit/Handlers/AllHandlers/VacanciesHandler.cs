using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using TelegramBot66bit.Parser;

namespace TelegramBot66bit.Handlers;

public class VacanciesHandler
{
    private readonly VacancyParser _parser;

    public VacanciesHandler(VacancyParser parser)
    {
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    public async Task HandleAsync(Message message, ITelegramBotClient bot, CancellationToken token)
    {
        var chatId = message.Chat.Id;

        await bot.SendMessage(
            chatId: chatId,
            text: "⏳ Загружаю направления...\n🔍 Идёт поиск актуальных вакансий...",
            cancellationToken: token);

        await Task.Delay(1500, token);

        var vacancies = await _parser.GetVacancyListAsync();

        if (vacancies.Count == 0)
        {
            await bot.SendMessage(chatId,
                "Вакансий не найдено.",
                cancellationToken: token);
            return;
        }

        string messageText = "<b>📋 Список направлений:</b>\n\n";
        int index = 1;
        foreach (var v in vacancies)
        {
            messageText += $"{index}. {v.Title} — мест: {v.Count}\n";
            index++;
        }

        var buttons = vacancies
            .Where(v => !string.IsNullOrEmpty(v.TaskUrl))
            .Select(v => new[] { InlineKeyboardButton.WithUrl($"📄 {v.Title}", v.TaskUrl) });

        var keyboard = new InlineKeyboardMarkup(buttons);

        await bot.SendMessage(
            chatId: chatId,
            text: messageText,
            parseMode: ParseMode.Html,
            replyMarkup: keyboard,
            cancellationToken: token);
    }
}