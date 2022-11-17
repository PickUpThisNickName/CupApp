using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class Drinks_leftoversController : Controller
    {
        private readonly IDrinks_leftovers _drinks_Leftovers;

        public Drinks_leftoversController(IDrinks_leftovers drinks_Leftovers)
        {
            _drinks_Leftovers = drinks_Leftovers;
        }
        [Route("Table3")]
        public ViewResult Table()
        {
            return View(_drinks_Leftovers.GetAllDrinks_LeftoversContent());
        }
    }
}
