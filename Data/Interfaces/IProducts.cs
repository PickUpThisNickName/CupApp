using CupApplication.Data.Models;
using System.Collections.Generic;

namespace CupApplication.Data.Interfaces
{
    public interface IProducts
    {
        List<Products> GetProducts();
        List<Products> GetAllProductsContent();
        Products getObject(int Id);
        public int? getIdByName(string name);
        public float? GetPortionPrice(int? Id);

    }
}
