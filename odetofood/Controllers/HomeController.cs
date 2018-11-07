using System;
using Microsoft.AspNetCore.Mvc;
using odetofood.Entities;
using odetofood.Services;
using odetofood.ViewModel;

namespace odetofood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _resturantData;
        private IGreeter _greeter;
        public HomeController(IRestaurantData resturantData, IGreeter greeter)
        {
            _resturantData = resturantData;
            _greeter = greeter;
        }
        public IActionResult Index()

        {
            var model = new HomePageViewModel();
            model.Restaurants = _resturantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
            //  return new ObjectResult(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _resturantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestuarantEditViewModel model)
        {
            var resturant = _resturantData.Get(id);
            if(ModelState.IsValid)
            {
                resturant.Cuisine = model.Cuisine;
                resturant.Name = model.Name;
                _resturantData.Commit();
                //
               
            }
            return RedirectToAction("Details", new { id = resturant.Id });
        }
        public IActionResult Details(int id)
        {
            var model = _resturantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create( RestuarantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;

                newRestaurant = _resturantData.Add(newRestaurant);
                _resturantData.Commit();
                return RedirectToAction("Details", new { id = newRestaurant.Id });

            }
            return View();
        }

    }
}
