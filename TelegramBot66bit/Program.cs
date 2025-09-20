using Microsoft.Extensions.Configuration;
using TelegramBot66bit.Config;
using TelegramBot66bit.Handlers;
using TelegramBot66bit.Parser;
using TelegramBot66bit.Services;

class Program
{
    static async Task Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var botConfig = config.GetSection("BotConfiguration").Get<BotConfiguration>()!;
        var commandHandler = new CommandHandler();

        var botService = new BotService(botConfig, commandHandler);
        await botService.StartAsync();

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}