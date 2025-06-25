using practikaZ.Pages2;
using practikaZ.Windows;
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

namespace practikaZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminsMainPage.xaml
    /// </summary>
    public partial class AdminsMainPage : Page
    {
        public AdminsMainPage()
        {
            InitializeComponent();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void Achivement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AchievementPage());
        }

        private void Announcement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnnouncementPage());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModeratorOrdersPage());
        }

        private void StaffList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffListPage());
        }

        private void CreateAnnounce_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateAnnouncementPage());
        }

        private void AddAchieve_Click(object sender, RoutedEventArgs e)
        {
            var AddAchiveWindow = new AddAchiveWindow();
            AddAchiveWindow.ShowDialog();
        }

        private void CreateAchive_Click(object sender, RoutedEventArgs e)
        {
            var CreateAchiveWindow = new CreateAchiveWindow();
            CreateAchiveWindow.ShowDialog();
        }

        private void RegUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterUserPage());
        }
    }
}
