using practikaZ.Pages2;
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
    /// Логика взаимодействия для StaffMainPage.xaml
    /// </summary>
    public partial class StaffMainPage : Page
    {
        public StaffMainPage()
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

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModeratorOrdersPage());
        }

        private void Announcement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnnouncementPage());
            
        }

        private void StaffList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StaffListPage());
        }
    }
}
