﻿using Microsoft.AspNetCore.Mvc;

namespace endpoint.site.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
