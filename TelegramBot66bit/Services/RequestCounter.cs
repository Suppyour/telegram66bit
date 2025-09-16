namespace TelegramBot66bit.Services;

public class RequestCounter
{
    private int _count = 0;

    public void Increment() => _count++;
    public int GetCount() => _count;
}