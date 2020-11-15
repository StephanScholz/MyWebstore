using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebstore.Data;
using MyWebstore.Models;

namespace MyWebstore.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(MyWebstoreContext context) : base(context) { }

        public IActionResult Index()
        {
            return View(cartViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
