using System.Security;
using System.Security.Policy;

namespace Store.Web
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = "secretkeysecretkey";
        public int ExpitesHours { get; set; } = 12; 

    }
}