using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingNetNetCore.Controllers
{
    public class BhusanController : Controller
    {
        // GET: Bhusan
        public IActionResult AboutMe()
        {
            return View();
        }

    }
}