using CupApplication.Data.Models;
using System.Collections.Generic;

namespace CupApplication.Data.Interfaces
{
    public interface IDrinks
    {
        List<Drinks> GetDrinks();
        List<Drinks> GetAllDrinksContent();
        Drinks getObject(int Id);
    }    
}
