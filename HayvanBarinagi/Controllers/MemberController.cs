using Microsoft.AspNetCore.Mvc;

namespace HayvanBarinagi.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
