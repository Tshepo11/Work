namespace StudentManagement.Domain
{
    public class AppSettings
    {
        public Content Content { get; set; }
        public Jwt Jwt { get; set; }
        public Mail Mail { get; set; }
        public string PortalUrl { get; set; }
        public Security Security { get; set; }
    }

    public class Content
    {
        public string CdnBaseUrl { get; set; }
        public string FileStorageDirectory { get; set; }
    }

    public class Jwt
    {
        public int ExpiryInMinutes { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int RefreshExpiryInDays { get; set; }
    }

    public class Mail
    {
        public bool EnableSsl { get; set; }
        public string From { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
    }

    public class Security
    {
        public int AccessFailedCountLimit { get; set; }
        public int AccountLockoutEndInMinutes { get; set; }
    }
}
