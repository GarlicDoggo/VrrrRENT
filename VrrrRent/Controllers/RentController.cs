using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Controllers
{
    public class RentController : Controller
    {
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
