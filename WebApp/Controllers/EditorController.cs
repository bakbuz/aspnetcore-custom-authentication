﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Editor")]
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
