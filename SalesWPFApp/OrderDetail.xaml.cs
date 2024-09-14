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
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public partial class OrderDetail : Window
    {
        private Order order;
        private IOrderDetailRepository orderDetailRepository;
        public OrderDetail(Order order)
        {
            this.order = order;
            orderDetailRepository = new OrderDetailRepository();
            InitializeComponent();
            Load();
        }

        void Load()
        {
            txtId.Text = order.OrderId.ToString();
            txtCustomer.Text = order.Member.Email.ToString();
            txtOrderDate.Text = order.OrderDate.ToString();
            txtRequiredDate.Text = order.RequiredDate.ToString();
            txtShippedDate.Text = order.ShippedDate.ToString();
            txtFreight.Text = order.Freight.ToString();
            dgOrderDetails.ItemsSource = orderDetailRepository.GetOrdersByOrderId(order.OrderId).Select(od => new
            {
                ProductId = od.Product.ProductId,
                ProductName = od.Product.ProductName,
                UnitPrice = od.UnitPrice,
                Quantity = od.Quantity,
                Discount = od.Discount
            }).ToList(); ;
        }
    }
}
