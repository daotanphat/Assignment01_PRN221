using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsBySearchKey(string search);
        void CreateProduct(Product product);
        Product GetProductById(int id);
        void DeleteProductById(int id);
        void UpdateProduct(Product product);
    }
}
