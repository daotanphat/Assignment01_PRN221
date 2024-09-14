using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ManageProduct.xaml
    /// </summary>
    public partial class ManageProduct : UserControl
    {
        private IProductRepository productRepository;
        public ManageProduct()
        {
            InitializeComponent();
            productRepository = new ProductRepository();
            Load();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product
                {
                    CategoryId = int.Parse(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text)
                };
                productRepository.CreateProduct(product);
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productRepository.UpdateProduct(GetProduct());
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                productRepository.DeleteProductById(int.Parse(txtId.Text));
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }

        private Product GetProduct()
        {
            return new Product
            {
                ProductId = int.Parse(txtId.Text),
                CategoryId = int.Parse(txtCategoryId.Text),
                ProductName = txtProductName.Text,
                Weight = txtWeight.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                UnitsInStock = int.Parse(txtUnitsInStock.Text)
            };
        }

        private void Load()
        {
            lvProducts.ItemsSource = productRepository.GetProducts();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchKey = txtSearch.Text == null ? "" : txtSearch.Text;
            lvProducts.ItemsSource = productRepository.GetProductsBySearchKey(searchKey);
        }


        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
