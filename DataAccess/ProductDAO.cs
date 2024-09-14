using BusinessObject;
using BusinessObject.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                var myStoreDB = new FStoreContext();
                products = myStoreDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public IEnumerable<Product> GetProductsBySearchKey(string search)
        {
            List<Product> products = new List<Product>();
            try
            {
                var myStoreDB = new FStoreContext();
                products = myStoreDB.Products
                    .Where(p => p.ProductName.Contains(search))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = new Product();
            try
            {
                var myStoreDB = new FStoreContext();
                product = myStoreDB.Products.SingleOrDefault(m => m.ProductId == id);
                if (product == null)
                {
                    throw new Exception("Product not found!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void addProduct(Product product)
        {
            try
            {
                var myStoreDB = new FStoreContext();
                ValidateProduct.CatchExceptionProduct(product);
                Product product1 = myStoreDB.Products.SingleOrDefault(m => m.ProductName == product.ProductName);
                if (product1 != null)
                {
                    throw new Exception("Product is already exist");
                }
                myStoreDB.Products.Add(product);
                myStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            var myStoreDB = new FStoreContext();
            try
            {
                ValidateProduct.CatchExceptionProduct(product);
                Product product1 = GetProductById(product.ProductId);
                if (product1 == null)
                {
                    throw new Exception("Product not exist");
                }
                myStoreDB.Entry<Product>(product).State = EntityState.Modified;
                myStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void deleteProduct(int id)
        {
            try
            {
                var myStoreDB = new FStoreContext();
                Product product1 = GetProductById(id);
                if (product1 == null)
                {
                    throw new Exception("Product is not exist");
                }
                myStoreDB.Products.Remove(product1);
                myStoreDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
