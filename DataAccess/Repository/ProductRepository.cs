using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product product)
        {
            ProductDAO.Instance.addProduct(product);
        }

        public void DeleteProductById(int id)
        {
            ProductDAO.Instance.deleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            return ProductDAO.Instance.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductDAO.Instance.GetProducts();
        }

        public IEnumerable<Product> GetProductsBySearchKey(string search)
        {
            return ProductDAO.Instance.GetProductsBySearchKey(search);
        }

        public void UpdateProduct(Product product)
        {
            ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
