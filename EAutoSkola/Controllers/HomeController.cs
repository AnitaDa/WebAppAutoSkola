using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EAutoSkola.Models;
using Microsoft.AspNetCore.Identity;
using EAutoSkola.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EAutoSkola.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        private readonly UserManager<Korisnik> _userManager;

        public HomeController(MyContext context, RoleManager<Rola> roleManager, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            return View();
        }
        
    }
}
