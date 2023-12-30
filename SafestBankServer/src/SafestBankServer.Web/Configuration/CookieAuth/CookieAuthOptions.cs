namespace SafestBankServer.Web.Configuration.CookieAuth;

public class CookieAuthOptions
{
    public TimeSpan CookieExpirationTime { get; } = new TimeSpan(0, 0, 60);
}
