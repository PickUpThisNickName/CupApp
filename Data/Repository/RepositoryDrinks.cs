using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CupApplication.Data.Repository
{
    public class RepositoryDrinks : IDrinks
    {
        private readonly AppDBContent content;
        public RepositoryDrinks(AppDBContent appDBContent)
        {
            this.content = appDBContent;
        }

        public List<Drinks> GetAllDrinksContent()
        {
            return (from p in content.DB_Drinks
                    select new Drinks
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Cup = p.Cup,
                        Source1 = p.Source1,
                        Source2 = p.Source2,
                        Source3 = p.Source3
                    }).ToList();
        }

        public List<Drinks> GetDrinks()
        {
            return (from p in content.DB_Drinks
                    select new Drinks
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToList();
        }

        public Drinks getObject(int Id)
        {
            return content.DB_Drinks.FirstOrDefault(p => p.Id == Id);
        }
        public int? getIdByName(string name)
        {
            Drinks drink = new Drinks();
            if (name != null)
                drink = content.DB_Drinks.FirstOrDefault(p => p.Name == name);
            return drink.Id;
        }
        public float? GetPrice(int? Id)
        {
            Drinks drink = new Drinks();
            if (Id != null)
                drink = content.DB_Drinks.FirstOrDefault(p => p.Id == Id);
            if (drink != null)
                return drink.Price;
            else
                return 0;
        }

    }
}
