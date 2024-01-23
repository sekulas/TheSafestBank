namespace SafestBankServer.Web.Configuration.Session;

public class SessionConfiguration
{
    public TimeSpan SessionExpirationTime { get; } = new TimeSpan(0, 5, 0);
}
