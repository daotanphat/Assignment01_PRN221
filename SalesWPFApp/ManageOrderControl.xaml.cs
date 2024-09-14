using BusinessObject;
using BusinessObject.Exception;
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
    /// Interaction logic for ManageOrderControl.xaml
    /// </summary>
    public partial class ManageOrderControl : UserControl
    {
        private bool isAdmin = true;
        private Member member;
        private IMemberRepository memberRepository;
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;
        List<Product> selectedProducts;
        public ManageOrderControl(bool isAdmin, Member member)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.member = member;
            display();
            memberRepository = new MemberRepository();
            orderRepository = new OrderRepository();
            productRepository = new ProductRepository();
            selectedProducts = new List<Product>();
            Load();
        }

        private void display()
        {
            if (!isAdmin)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                btnUpdate.Visibility = Visibility.Collapsed;
                btnChooseProducts.Visibility = Visibility.Collapsed;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order
                {
                    MemberId = cboCustomer.SelectedValue != null ? (int?)cboCustomer.SelectedValue : null,
                    OrderDate = DateTime.Now,
                    RequiredDate = txtRequiredDate.SelectedDate.HasValue ? txtRequiredDate.SelectedDate : null,
                    ShippedDate = txtShippedDate.SelectedDate.HasValue ? txtShippedDate.SelectedDate : null,
                    Freight = decimal.TryParse(txtFreight.Text, out decimal freight) ? freight : 0
                };
                ValidateOrder.CatchExceptionOrder(order);
                //orderRepository.CreateOrder(order, selectedProducts);
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Order");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = new Order
                {
                    OrderId = int.Parse(txtId.Text),
                    MemberId = cboCustomer.SelectedValue != null ? (int?)cboCustomer.SelectedValue : null,
                    OrderDate = DateTime.Now,
                    RequiredDate = txtRequiredDate.SelectedDate.HasValue ? txtRequiredDate.SelectedDate : null,
                    ShippedDate = txtShippedDate.SelectedDate.HasValue ? txtShippedDate.SelectedDate : null,
                    Freight = decimal.TryParse(txtFreight.Text, out decimal freight) ? freight : 0
                };
                ValidateOrder.CatchExceptionOrder(order);
                //orderRepository.CreateOrder(order, selectedProducts);
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Order");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orderRepository.DeleteOrder(int.Parse(txtId.Text));
                Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Order");
            }
        }

        private void Load()
        {
            if (isAdmin)
            {
                List<Order> orders = (List<Order>)orderRepository.GetOrders();
                List<Member> members = (List<Member>)memberRepository.GetMembers();
                lvOrders.ItemsSource = orders;
                cboCustomer.ItemsSource = members;
            }
            else
            {
                lvOrders.ItemsSource = orderRepository.GetOrdersByMemberId(member.MemberId);
            }

        }

        private void btnChooseProducts_Click(object sender, RoutedEventArgs e)
        {
            List<Product> products = (List<Product>)productRepository.GetProducts();
            var selectedProductWindow = new SelectProduct();
            if (selectedProductWindow.ShowDialog() == true)
            {
                var selectedProductIds = selectedProductWindow.selectedProducts;
                selectedProducts = products.Where(p => selectedProductIds.Contains(p.ProductId)).ToList();
            }
        }

        private void lvOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedOrder = lvOrders.SelectedItem as Order;
            if (selectedOrder != null)
            {
                OrderDetail detail = new OrderDetail(selectedOrder);
                detail.ShowDialog();
            }
        }
    }
}