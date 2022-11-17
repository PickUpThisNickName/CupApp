using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class DrinksController : Controller
    {
        private readonly IDrinks _allDrinks;

        public DrinksController(IDrinks drinks)
        {
            _allDrinks = drinks;
        }
        [Route("Table4")]
        public ViewResult Table()
        {
            return View(_allDrinks.GetAllDrinksContent());
        }
    }
}
