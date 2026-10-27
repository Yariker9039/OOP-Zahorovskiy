namespace Lab6;

public abstract class Authenticator
{
    public abstract bool Authenticate(string username, string password);
    public void LogAttempt(string username, bool success)
    {
        Console.WriteLine($"Користувач {username}: {(success ? "вхід успішний" : "вхід відхилено")}");
    }
}

// Навчальні дані в пам'яті, без справжнього підключення до бази.
public class DatabaseAuthenticator : Authenticator
{
    private readonly Dictionary<string, string> _users = new()
    {
        { "yaroslav", "study123" }
    };

    public override bool Authenticate(string username, string password)
    {
        return _users.TryGetValue(username, out string? savedPassword)
            && savedPassword == password;
    }
}

// Імітація каталогу LDAP. Для входу потрібне ім'я з доменом college.
public class LdapAuthenticator : Authenticator
{
    private readonly Dictionary<string, string> _users = new()
    {
        { @"college\yaroslav", "ldap123" }
    };

    public override bool Authenticate(string username, string password)
    {
        return _users.TryGetValue(username, out string? savedPassword)
            && savedPassword == password;
    }
}
