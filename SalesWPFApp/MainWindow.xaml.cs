using BusinessObject;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isAdmin = false;
        private Member member;
        public MainWindow(bool isAdmin = false, Member member = null)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
            this.member = member;
            SetMenu(isAdmin);
        }

        private void SetMenu(bool isAdmin)
        {
            if (!isAdmin)
            {
                mnProduct.Visibility = Visibility.Collapsed;
                mnReport.Visibility = Visibility.Collapsed;
                mnMember.Visibility = Visibility.Collapsed;
            }
        }

        private void mnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void mnMember_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ManageMemberControl();
        }

        private void mnProduct_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ManageProduct();
        }

        private void mnOrder_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ManageOrderControl(isAdmin, member);
        }

        private void mnReport_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new OrderReportControl();
        }
    }
}
