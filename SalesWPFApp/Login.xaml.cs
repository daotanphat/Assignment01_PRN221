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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public IMemberRepository memberRepository;
        public Login()
        {
            InitializeComponent();
            memberRepository = new MemberRepository();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = new Member
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Password
                };
                if (memberRepository.isAdmin(member))
                {
                    MainWindow main = new MainWindow(true);
                    main.Show();
                    this.Close();
                }
                else
                {
                    Member member1 = memberRepository.verifyMember(member);
                    if (member1 != null)
                    {
                        MainWindow main = new MainWindow(false, member1);
                        main.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Message");
            }
        }
    }
}
