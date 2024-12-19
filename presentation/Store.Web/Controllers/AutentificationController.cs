using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace Store.Web.Controllers
{
    public class AutentificationController : Controller
    {
        public IUserRepository UserRepository { get; set; }
        public IJwtProvider JwtProvider { get; set; }

        public AutentificationController(IUserRepository userRepository,IJwtProvider jwtProvider)
        { 
            UserRepository = userRepository; 
            JwtProvider = jwtProvider; 
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Authorization(User user)
        {
            return View(user);
        }
        [HttpPost]
        public IActionResult AddNewUser(string username, string password, string email)
        {
            string stringtoken;
            User? new_user = UserRepository.GetAll().Where(i=>i.Email==email).FirstOrDefault();
            if (new_user != null)
            {

                return View("Authorization",new_user);
            }
            else
            {
                new_user=UserRepository.Create(username,email,password);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,"Cookies");

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Entry(string email,string password) 
        {
            User? new_user = UserRepository.GetAll().Where(i => i.Email == email).FirstOrDefault();
            if (new_user != null)
            {
                if (new_user.Password != password)
                {
                    new_user.Errors = new Dictionary<string, string>() { { "ErrorPass", "Неверный пароль" } };
                    return View("Authorization",new_user);
                }
                else
                {
                    var token = JwtProvider.GenerateToken(new_user);
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, email) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
              


                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                return RedirectToAction("Registration", "Autentification");
            }
        }

    }
}
