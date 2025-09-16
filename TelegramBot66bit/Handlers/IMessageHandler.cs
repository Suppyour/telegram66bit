using Telegram.Bot;

namespace TelegramBot66bit.Handlers;

public interface IMessageHandler
{
    bool CanHandle(string message);
    Task Handle(string message, long chatId, ITelegramBotClient bot);
}