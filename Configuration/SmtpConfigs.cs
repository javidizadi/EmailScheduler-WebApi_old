namespace Email_Scheduler_WebApi.Configuration;

public class SmtpConfigs
{
    public string? Host { get; set; }

    public int Port { get; set; }

    public string? From { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}