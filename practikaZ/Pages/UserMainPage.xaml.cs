using practikaZ.models;
using practikaZ.Pages2;
using practikaZ.Service;
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
    /// Логика взаимодействия для UserMainPage.xaml
    /// </summary>
    public partial class UserMainPage : Page
    {
        public UserMainPage()
        {
            InitializeComponent();
            //LoadData();
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
            //if (ProfilePannel.Visibility == Visibility.Visible)
            //{
            //    ProfilePannel.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    ProfilePannel.Visibility = Visibility.Visible;
            //}
        }



        private void Achivement_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AchievementPage());
        }

        private void Announcement_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AnnouncementPage());
            if (AnnounsList.Visibility == Visibility.Visible)
            {
                AnnounsList.Visibility = Visibility.Collapsed;
            }
            else
            {
                AnnounsList.Visibility = Visibility.Visible;
            }
        }
        
        private void LoadData()
        {
            if (UserHelper.user != null)
            {
                int UserRoleId = UserHelper.user.RoleId;

                AnnounsList.ItemsSource = AnnouncementService.GetAnnounc(UserRoleId);
            }
        }




        private void Announcement_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AnnounsList.SelectedItem is Announcement selectedAnnouncement)
            {
                var detailWindow = new AnnounceDetailWindow
                {
                    DataContext = new
                    {
                        selectedAnnouncement.Title,
                        selectedAnnouncement.Message,
                        AuthorFullName = $"{selectedAnnouncement.Author.LastName} {selectedAnnouncement.Author.FirstName} {selectedAnnouncement.Author.Patronymic}"
                    }
                };
                detailWindow.ShowDialog();
            }
        }

        private void Create_Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrderPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            
        }
        
    }
}


