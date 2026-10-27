using System.Text;
using Lab6;
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Повідомлення через INotifier (імітація):");
List<INotifier> notifiers = new() { new EmailNotifier(), new SmsNotifier() };
foreach (INotifier notifier in notifiers)
    notifier.SendNotification("Нове завдання з ООП.");

List<Authenticator> authenticators = new()
{
    new DatabaseAuthenticator(), new LdapAuthenticator()
};
var attempts = new[]
{
    (Username: "yaroslav", Password: "study123"),
    (Username: @"college\yaroslav", Password: "ldap123"),
    (Username: "yaroslav", Password: "wrong")
};
foreach (Authenticator authenticator in authenticators)
{
    Console.WriteLine($"\n{authenticator.GetType().Name} (імітація):");
    foreach (var attempt in attempts)
    {
        bool success = authenticator.Authenticate(attempt.Username, attempt.Password);
        authenticator.LogAttempt(attempt.Username, success);
    }
}
