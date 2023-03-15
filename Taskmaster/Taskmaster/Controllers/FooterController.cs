using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Taskmaster.Controllers
{
    public class FooterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Howitworks
        public IActionResult How()
        {
            return View();
        }

        // GET: Business
        public IActionResult Business()
        {
            return View();
        }

        // GET: FAQ
        public IActionResult FAQ()
        {
            return View();
        }

        // GET: Guidelines
        public IActionResult Guidelines()
        {
            return View();
        }

        // GET: Terms and Conditions
        public IActionResult Terms()
        {
            return View();
        }

        // GET: Privacy
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
