using System;
using Microsoft.AspNetCore.Mvc;
using odetofood.Models;
using odetofood.Services;

namespace odetofood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _resturantData;
        public HomeController(IRestaurantData resturantData)
        {
            _resturantData = resturantData;
        }
        public IActionResult Index()

        {
            var model = _resturantData.GetAll();

            return View(model);
          //  return new ObjectResult(model);
        }
    }
}
