﻿using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public IEnumerable<Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
