using CupApplication.Data.Models;
using System.Collections.Generic;

namespace CupApplication.Data.Interfaces
{
    public interface IDrinks_leftovers
    {
        List<Drinks_leftovers> GetAllDrinks_LeftoversContent();
        Drinks_leftovers getObject(int Id);

    }
}
