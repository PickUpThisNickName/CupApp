using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using CupApplication.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;
using System;
using System.Linq;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "worker, admin")]
    public class WorkerContextController : Controller
    {
        private readonly IDrinks _allDrinks;
        private readonly IProducts _allProducts;
        private readonly IBeneficiaries _allBeneficiaries;

        public WorkerContextController(IDrinks drinks, IProducts products, IBeneficiaries beneficiaries)
        {
            _allDrinks = drinks;
            _allProducts = products;
            _allBeneficiaries = beneficiaries;
        }
        WorkerViewModel obj = new WorkerViewModel();
        [Route("WorkerContent")]
        public ViewResult WorkerObjects()
        {
            obj.AllDrinks = _allDrinks.GetDrinks();
            obj.AllProducts = _allProducts.GetProducts();
            obj.AllBeneficiaries = _allBeneficiaries.GetBeneficiaries();
            return View(obj);
        }
        public void Transact(string alldrinksform, string allproductsform)
        {
            string[] Words1 = alldrinksform.Split(",");
            string[] Words2 = allproductsform.Split(",");
            var name = new List<string>();
            var price = new List<string>();

            foreach (string word in Words1)
            {
                word.Remove(word.Length - 1, 1);
                string[] info = word.Split(" Цена: ");
                name.Add(info[0]);
                price.Add(info[1]);
            }

        }
    }
}
