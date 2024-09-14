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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for SelectProduct.xaml
    /// </summary>
    public partial class SelectProduct : Window
    {
        public List<int> selectedProducts { get; set; }
        private IProductRepository productRepository;
        public SelectProduct()
        {
            InitializeComponent();
            selectedProducts = new List<int>();
            productRepository = new ProductRepository();
            Load();
        }

        void Load()
        {
            dgProducts.ItemsSource = productRepository.GetProducts();
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            selectedProducts.Clear();
            string test = "";
            foreach (var item in dgProducts.ItemsSource)
            {
                var product = item as Product;
                if (product != null)
                {
                    var checkBox = dgProducts.Columns[0].GetCellContent(item) as CheckBox;
                    if (checkBox != null && checkBox.IsChecked == true)
                    {
                        selectedProducts.Add(product.ProductId);
                        test += product.ProductId + " - ";
                    }
                }
            }
            DialogResult = true;
            this.Close();
        }
    }
}
