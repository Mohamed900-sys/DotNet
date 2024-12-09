using Microsoft.AspNetCore.Mvc;

namespace ProjetDotNet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
