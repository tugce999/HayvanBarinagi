
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HayvanBarinagi.Models;
using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContext _context;

        public AdminController(ILogger<HomeController> logger, DbContext context)
        {
            _logger = logger;
            _context = context;
        }

    }
}
