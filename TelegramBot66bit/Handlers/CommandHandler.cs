using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot66bit.Parser;

namespace TelegramBot66bit.Handlers
{
    public class CommandHandler
    {
        private readonly VacancyParser _parser;

        public CommandHandler(VacancyParser parser)
        {
            _parser = parser;
        }

        public async Task HandleCommandAsync(Message message, ITelegramBotClient bot, CancellationToken token)
        {
            var chatId = message.Chat.Id;
            var text = message.Text!.ToLower();

            if (text.StartsWith("/start"))
            {
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

                await bot.SendMessage(chatId, startText, ParseMode.Html, cancellationToken: token);
            }
            else if (text.StartsWith("/help"))
            {
                string helpText =
                    "📌 Доступные команды:\n" +
                    "/help — список команд\n" +
                    "/faq — часто задаваемые вопросы\n" +
                    "/vacancies — направления и количество мест\n" +
                    "/about — информация о компании\n" +
                    "/practice — информация о практике\n" +
                    "/contacts — наши контакты";

                await bot.SendMessage(chatId, helpText, cancellationToken: token);
            }
            else if (text.StartsWith("/faq"))
            {
                await bot.SendMessage(chatId,
                    "По всем вопросам обращайтесь к @Tatiana66bit или https://practice.66bit.ru",
                    cancellationToken: token);
            }
            else if (text.StartsWith("/vacancies"))
            {
                await bot.SendMessage(chatId,
                    "⏳ Загружаю направления...\n🔍 Идёт поиск актуальных вакансий...",
                    cancellationToken: token);

                await Task.Delay(1500); // 1.5 секунда

                var info = await _parser.GetVacancyInfoAsync();

                await bot.SendMessage(chatId, info, cancellationToken: token);
            }

            else if (text.StartsWith("/about"))
            {
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

            else if (text.StartsWith("/practice"))
            {
                string practiceText =
                    "<b>🎓 О практике</b>\n\n" +
                    "📅 <b>Ты сам выбираешь дату</b> прохождения практики\n" +
                    "🏠 Практику можно пройти <b>в офисе</b> или <b>удалённо</b>\n" +
                    "💼 При успешном прохождении — <b>трудоустройство с гибким графиком</b> (от 20 часов в неделю)\n" +
                    "🧭 У тебя будет <b>куратор</b>, который поможет и направит\n\n" +
                    "Погружаемся в реальную разработку — с поддержкой и перспективой!";

                await bot.SendMessage(chatId, practiceText, ParseMode.Html, cancellationToken: token);
            }
            else if (text.StartsWith("/contacts"))
            {
                string contactsText =
                    "<b>📞 Контакты</b>\n\n" +
                    "📱 Телефон: <b>+7 343 290 84 76</b>\n" +
                    "📧 Email: <b>info@66bit.ru</b>\n\n" +
                    "🌐 Сайт: <a href=\"https://practice.66bit.ru\">practice.66bit.ru</a>\n" +
                    "💬 Telegram: <a href=\"https://t.me/Tatiana66bit\">@Tatiana66bit</a>";

                await bot.SendMessage(
                    chatId,
                    contactsText,
                    parseMode: ParseMode.Html,
                    cancellationToken: token);
            }

            else
            {
                await bot.SendMessage(chatId,
                    "Неизвестная команда. Используйте /help для списка доступных команд.", cancellationToken: token);
            }
        }
    }
}