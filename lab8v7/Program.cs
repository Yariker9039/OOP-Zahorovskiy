using System.Text;
using Lab5;
Console.OutputEncoding = Encoding.UTF8;
var notifications = new List<Notification>
{
    new EmailNotification("Роботу прийнято.", "student@example.com"),
    new SMSNotification("Заняття почнеться о 10:00.", "+380000000000"),
    new PushNotification("Додано нове завдання.", "phone-7")
};
var sentMessages = new List<string>();
Console.WriteLine("Навчальна імітація надсилання:");
foreach (Notification notification in notifications)
{
    notification.Send();
    sentMessages.Add(notification.Message);
}
Console.WriteLine("\nУсі відправлені повідомлення:");
foreach (string message in sentMessages)
    Console.WriteLine(message);
Console.WriteLine($"Усього: {sentMessages.Count}");
