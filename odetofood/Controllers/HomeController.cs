using System;
using Microsoft.AspNetCore.Mvc;
using odetofood.Models;

namespace odetofood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()

        {
            var model = new Restaurant { Id = 1, Name = "The house of Good food" };

            return new ObjectResult(model);
        }
    }
}
