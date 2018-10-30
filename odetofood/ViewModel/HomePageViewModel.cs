using System;
using System.Collections.Generic;
using odetofood.Entities;

namespace odetofood.ViewModel
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
