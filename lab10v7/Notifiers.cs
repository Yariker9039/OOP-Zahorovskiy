namespace Lab6;

public interface INotifier
{
    void SendNotification(string message);
}

public class EmailNotifier : INotifier
{
    public void SendNotification(string message) => Console.WriteLine($"Email: {message}");
}

public class SmsNotifier : INotifier
{
    public void SendNotification(string message) => Console.WriteLine($"SMS: {message}");
}
