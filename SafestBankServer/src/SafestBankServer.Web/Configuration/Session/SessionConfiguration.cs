namespace SafestBankServer.Web.Configuration.Session;

//TODO - CHANGE TO RECORD
public class SessionConfiguration
{
    public TimeSpan SessionExpirationTime { get; } = new TimeSpan(0, 1, 0);
}
