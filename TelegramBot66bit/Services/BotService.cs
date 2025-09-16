using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot66bit.Config;
using TelegramBot66bit.Handlers;

namespace TelegramBot66bit.Services
{
    public class BotService
    {
        private readonly TelegramBotClient _botClient;
        private readonly CommandHandler _commandHandler;

        public BotService(BotConfiguration config, CommandHandler commandHandler)
        {
            _botClient = new TelegramBotClient(config.Token);
            _commandHandler = commandHandler;
        }

        public async Task StartAsync()
        {
            var cts = new CancellationTokenSource();

            _botClient.StartReceiving(
                async (bot, update, token) =>
                {
                    if (update.Type == UpdateType.Message && update.Message?.Text != null)
                    {
                        await _commandHandler.HandleCommandAsync(update.Message, _botClient, token);
                    }
                },
                (bot, exception, token) =>
                {
                    Console.WriteLine($"Ошибка: {exception.Message}");
                    return Task.CompletedTask;
                },
                new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() },
                cancellationToken: cts.Token
            );

            var me = await _botClient.GetMe();
            Console.WriteLine($"Бот @{me.Username} запущен.");
        }
    }
}