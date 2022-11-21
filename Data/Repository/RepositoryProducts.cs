using System.Collections.Generic;
using System.Linq;
using CupApplication.Data.Interfaces;
using CupApplication.Data.Models;

namespace CupApplication.Data.Repository
{
    public class RepositoryProducts : IProducts
    {
        private readonly AppDBContent content;
        public RepositoryProducts(AppDBContent appDBContent)
        {
            this.content = appDBContent;
        }

        public List<Products> GetAllProductsContent()
        {
            return (from p in content.DB_Products
                    select new Products
                    {
                        Id = p.Id,
                        Name = p.Name,
                        VolumeInStock = p.VolumeInStock,
                        Price = p.Price,
                        PortionVolume = p.PortionVolume,
                        PortionPrice = p.PortionPrice
                    }).ToList();
        }

        Products IProducts.getObject(int Id)
        {
            return content.DB_Products.FirstOrDefault(p => p.Id == Id);
        }

        List<Products> IProducts.GetProducts()
        {
            return (from p in content.DB_Products
                    select new Products
                    {
                        Name = p.Name,
                        PortionPrice = p.PortionPrice
                    }).ToList();
        }
        public int? getIdByName(string name)
        {
            Products product = new Products();
            if (name != null)
                product = content.DB_Products.FirstOrDefault(p => p.Name == name);
            return product.Id;
        }

    }

}
