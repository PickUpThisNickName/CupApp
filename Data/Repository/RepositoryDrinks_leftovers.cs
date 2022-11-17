using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;

namespace CupApplication.Data.Repository
{
    public class RepositoryDrinks_leftovers : IDrinks_leftovers
    {
        private readonly AppDBContent content;
        public RepositoryDrinks_leftovers(AppDBContent appDBContent)
        {
            this.content = appDBContent;
        }

        public List<Drinks_leftovers> GetAllDrinks_LeftoversContent()
        {
            return (from p in content.DB_Drinks_leftovers
                    select new Drinks_leftovers
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Amount = p.Amount,
                        Price = p.Price
                    }).ToList();
        }

        Drinks_leftovers IDrinks_leftovers.getObject(int Id)
        {
            return content.DB_Drinks_leftovers.FirstOrDefault(p => p.Id == Id);
        }
    }
}
