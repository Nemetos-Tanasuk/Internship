using OdeToFood.Data.Models;
using System.Collections.Generic;

namespace OdeToFood.Web.Models
{
    public class GreedingViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string MessageToDisplay { get; set; }
        public string Name { get; set; }
    }
}