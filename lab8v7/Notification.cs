namespace Lab5;

public class Notification
{
    public string Message { get; }
    public Notification(string message) => Message = message;
    public virtual void Send() => Console.WriteLine($"Повідомлення: {Message}");
}

public class EmailNotification : Notification
{
    public string RecipientEmail { get; }
    public EmailNotification(string message, string recipientEmail) : base(message)
        => RecipientEmail = recipientEmail;
    public override void Send() => Console.WriteLine($"Email для {RecipientEmail}: {Message}");
}

public class SMSNotification : Notification
{
    public string PhoneNumber { get; }
    public SMSNotification(string message, string phoneNumber) : base(message)
        => PhoneNumber = phoneNumber;
    public override void Send() => Console.WriteLine($"SMS для {PhoneNumber}: {Message}");
}

public class PushNotification : Notification
{
    public string DeviceId { get; }
    public PushNotification(string message, string deviceId) : base(message)
        => DeviceId = deviceId;
    public override void Send() => Console.WriteLine($"Push для {DeviceId}: {Message}");
}
