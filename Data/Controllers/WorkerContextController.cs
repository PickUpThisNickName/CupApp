using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using CupApplication.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Transactions;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CupApplication.Data.Controllers
{
    [Authorize(Roles = "worker, admin")]
    public class WorkerContextController : Controller
    {
        private readonly AppDBContent content;
        private readonly IDrinks _allDrinks;
        private readonly IProducts _allProducts;
        private readonly IBeneficiaries _allBeneficiaries;

        public WorkerContextController(IDrinks drinks, IProducts products, IBeneficiaries beneficiaries, AppDBContent appDBContent)
        {
            _allDrinks = drinks;
            _allProducts = products;
            _allBeneficiaries = beneficiaries;
            this.content = appDBContent;
        }

        public void StartSession()
        {
            HttpContext.Session.GetString("");
        }

        public void CloseSession()
        {

        }


        [Route("WorkerContent")]
        public ViewResult WorkerObjects()
        {
            WorkerViewModel obj = new WorkerViewModel();
            obj.AllDrinks = _allDrinks.GetDrinks();
            obj.AllProducts = _allProducts.GetProducts();
            obj.AllBeneficiaries = _allBeneficiaries.GetBeneficiaries();
            obj.SessionStarted = true;
            return View(obj);
        }

        public List<string> Parser(string arr)
        {
            var ReturnList = new List<string>();

            Regex reg = new Regex(@"[А-я ]+\d+, Цена: \d+,\d+|[А-я ]+, Цена: \d+,\d+", RegexOptions.IgnoreCase);

            if (arr!=null)
            {
                MatchCollection matches = reg.Matches(arr);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        string[] info = match.Value.ToString().Split(", Цена: ");
                        ReturnList.Add(info[0]);
                    }
                }
            }
            return ReturnList;
        }

        public void Transact(string alldrinksform, string allproductsform, string person, string arrDrinks, string arrProducts)
        {
            if (alldrinksform.Any() || allproductsform.Any())
            {
                var Drinksname = Parser(alldrinksform);
                var Productsname = Parser(allproductsform);
                var Uniqdrinks = Parser(arrDrinks);
                var Uniqproducts = Parser(arrProducts);
                int iter = 5 - Uniqdrinks.Count;
                for (int i = 0; i < iter; i++)
                    Uniqdrinks.Add(null);
                iter = 2 - Uniqproducts.Count;
                for (int i = 0; i < iter; i++)
                    Uniqproducts.Add(null);

                var UniqDrinksCount = new List<int>();
                var UniqProductsCount = new List<int>();
                foreach (var item in Uniqdrinks)
                    UniqDrinksCount.Add(0);
                foreach (var item in Uniqproducts)
                    UniqProductsCount.Add(0);

                for (int i = 0; i < Uniqdrinks.Count; i++)
                {
                    foreach (var drinkname in Drinksname)
                        if (drinkname == Uniqdrinks[i])
                            UniqDrinksCount[i]++;
                }

                for (int i = 0; i < Uniqproducts.Count; i++)
                {
                    foreach (var productname in Productsname)
                        if (productname == Uniqproducts[i])
                            UniqProductsCount[i]++;
                }

                Sales Sale = new Sales
                {
                    Time = DateTime.Now,
                    BeneficiariID = _allBeneficiaries.getIdByName(person),
                    Cup1_ID = _allDrinks.getIdByName(Uniqdrinks[0]),
                    Cup1_Amount = UniqDrinksCount[0],
                    Cup2_ID = _allDrinks.getIdByName(Uniqdrinks[1]),
                    Cup2_Amount = UniqDrinksCount[1],
                    Cup3_ID = _allDrinks.getIdByName(Uniqdrinks[2]),
                    Cup3_Amount = UniqDrinksCount[2],
                    Cup4_ID = _allDrinks.getIdByName(Uniqdrinks[3]),
                    Cup4_Amount = UniqDrinksCount[3],
                    Cup5_ID = _allDrinks.getIdByName(Uniqdrinks[4]),
                    Cup5_Amount = UniqDrinksCount[4],
                    Product1_ID = _allProducts.getIdByName(Uniqproducts[0]),
                    Product1_Amount = UniqProductsCount[0],
                    Product2_ID = _allProducts.getIdByName(Uniqproducts[1]),
                    Product2_Amount = UniqProductsCount[1],
                };
                float? Paid = 0;
                Paid += _allDrinks.GetPrice(Sale.Cup1_ID) * (float)Sale.Cup1_Amount;
                Paid += _allDrinks.GetPrice(Sale.Cup2_ID) * (float)Sale.Cup2_Amount;
                Paid += _allDrinks.GetPrice(Sale.Cup3_ID) * (float)Sale.Cup3_Amount;
                Paid += _allDrinks.GetPrice(Sale.Cup4_ID) * (float)Sale.Cup4_Amount;
                Paid += _allDrinks.GetPrice(Sale.Cup5_ID) * (float)Sale.Cup5_Amount;
                Paid += _allProducts.GetPortionPrice(Sale.Product1_ID) * (float)Sale.Product1_Amount;
                Paid += _allProducts.GetPortionPrice(Sale.Product2_ID) * (float)Sale.Product2_Amount;

                

                if (Sale.BeneficiariID != 0)
                    Paid *= _allBeneficiaries.GetKoefficient((int)Sale.BeneficiariID);
                Sale.Paid = Paid;

                content.DB_Sales.Add(Sale);
                //content.SaveChanges();
            }
        }

    }
}
