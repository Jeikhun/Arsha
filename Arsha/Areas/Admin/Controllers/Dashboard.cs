﻿using Microsoft.AspNetCore.Mvc;

namespace Arsha.Areas.Admin.Controllers
{
    public class Dashboard : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
