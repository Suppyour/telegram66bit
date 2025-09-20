using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot66bit.Parser;

namespace TelegramBot66bit.Handlers
{
    public class CommandHandler
    {
        private readonly StartHandler _start;
        private readonly HelpHandler _help;
        private readonly FaqHandler _faq;
        private readonly VacanciesHandler _vacancies;
        private readonly AboutHandler _about;
        private readonly PracticeHandler _practice;
        private readonly ContactsHandler _contacts;

        public CommandHandler()
        {
            var parser = new VacancyParser();
            
            _start = new StartHandler();
            _help = new HelpHandler();
            _faq = new FaqHandler();
            _vacancies = new VacanciesHandler(parser);
            _about = new AboutHandler();
            _practice = new PracticeHandler();
            _contacts = new ContactsHandler();
        }

        public async Task HandleCommandAsync(Message message, ITelegramBotClient bot, CancellationToken token)
        {
            var text = message.Text?.ToLower() ?? "";

            if (text.StartsWith("/start"))
                await _start.HandleAsync(message, bot, token);

            else if (text.StartsWith("/help"))
                await _help.HandleAsync(message, bot, token);

            else if (text.StartsWith("/faq"))
                await _faq.HandleAsync(message, bot, token);

            else if (text.StartsWith("/vacancies"))
                await _vacancies.HandleAsync(message, bot, token);

            else if (text.StartsWith("/about"))
                await _about.HandleAsync(message, bot, token);

            else if (text.StartsWith("/practice"))
                await _practice.HandleAsync(message, bot, token);

            else if (text.StartsWith("/contacts"))
                await _contacts.HandleAsync(message, bot, token);

            else
                await bot.SendMessage(
                    message.Chat.Id,
                    "Неизвестная команда. Используйте /help для списка доступных команд.",
                    cancellationToken: token);
        }

    }
}
