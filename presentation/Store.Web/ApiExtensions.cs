using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Store.Web
{
    public static class ApiExtensions
    {

        public static void AddApiAutentification(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
            {

                options.LoginPath = "Autentification/Registration";
                services.AddAuthorization();
            });
        }
    }
}
