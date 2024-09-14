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
    /// Interaction logic for OrderReportControl.xaml
    /// </summary>
    public partial class OrderReportControl : UserControl
    {
        private IOrderDetailRepository orderDetailRepository;
        public OrderReportControl()
        {
            InitializeComponent();
            orderDetailRepository = new OrderDetailRepository();
            dtpStartDate.SelectedDate = DateTime.Now;
            dtpToDate.SelectedDate = DateTime.Now;
            Load(DateTime.Now, DateTime.Now);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = dtpStartDate.SelectedDate.Value;
            DateTime toDate = dtpToDate.SelectedDate.Value;
            Load(startDate, toDate);
        }

        void Load(DateTime startDate, DateTime toDate)
        {
            dgOrderDetails.ItemsSource = orderDetailRepository.GetOrderDetailReport(startDate, toDate);
            MessageBox.Show(orderDetailRepository.GetOrderDetailReport(startDate, toDate).Count().ToString());
        }
    }
}
