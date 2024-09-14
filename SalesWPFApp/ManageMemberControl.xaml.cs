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
    /// Interaction logic for ManageMemberControl.xaml
    /// </summary>
    public partial class ManageMemberControl : UserControl
    {
        IMemberRepository memberRepository;
        public ManageMemberControl()
        {
            InitializeComponent();
            memberRepository = new MemberRepository();
            LoadMember();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memberRepository.deleteMember(int.Parse(txtId.Text));
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete member");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Member member = new Member
            {
                Email = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text
            };
            try
            {
                memberRepository.AddMember(member);
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add member");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memberRepository.UpdateMember(GetMemberFromInput());
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update member");
            }
        }

        public void LoadMember()
        {
            try
            {
                lvMebers.ItemsSource = memberRepository.GetMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load members");
            }
        }

        public Member GetMemberFromInput()
        {
            Member member = new Member
            {
                MemberId = int.Parse(txtId.Text),
                Email = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Password = txtPassword.Text
            };
            return member;
        }
    }
}
