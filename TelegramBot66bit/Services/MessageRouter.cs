using Telegram.Bot;
using TelegramBot66bit.Config;
using TelegramBot66bit.Handlers;

namespace TelegramBot66bit.Services;

public class MessageRouter
{
    private readonly List<IMessageHandler> _handlers = new();
    private readonly RequestCounter _counter = new();

    public MessageRouter(BotConfiguration config)
    {
        _handlers.Add(new StartHandler());
        
    }

    public async Task RouteAsync(string message, long chatId, ITelegramBotClient bot)
    {
        _counter.Increment();

        var handler = _handlers.First(h => h.CanHandle(message));
        await handler.Handle(message, chatId, bot);

        Console.WriteLine($"Обработано запросов: {_counter.GetCount()}");
    }
}