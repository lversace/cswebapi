using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cswebapi.Controllers
{
    public class SearchController : Controller
    {
        [Route("/search/instruments")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
