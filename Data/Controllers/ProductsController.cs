using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }
        [Route("Table5")]
        public ViewResult Table()
        {
            return View(_products.GetAllProductsContent());
        }
    }
}
