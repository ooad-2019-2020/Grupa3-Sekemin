using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sekemin.Controllers
{
    public class ZahtjevZaSmjestajController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
