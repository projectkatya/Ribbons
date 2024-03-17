using System.ComponentModel.DataAnnotations;

namespace Ribbons.Users.Authentication.Models
{
    public sealed class CookieSettings
    {
        [Required]
        public string DomainCookieName { get; set; }

        [Required]
        public string SessionIdCookieNameTemplate { get; set; }

        [Required]
        public string SessionSecretCookieNameTemplate { get; set; }

        public string SessionIdCookieName(string domain)
        {
            return string.Format(SessionIdCookieNameTemplate, domain);
        }

        public string SessionSecretCookieName(string domain)
        {
            return string.Format(SessionSecretCookieNameTemplate, domain);
        }
    }
}