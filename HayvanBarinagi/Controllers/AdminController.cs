using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HayvanBarinagi.Controllers
{
    //Bu SAYFAYA Admin OLAN KİŞİLER GIREBILIR

    //[Authorize(Roles = "admin,manager")]

    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
