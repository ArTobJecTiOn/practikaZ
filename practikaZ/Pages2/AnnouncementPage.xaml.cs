using practikaZ.models;
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

namespace practikaZ.Pages2
{
    /// <summary>
    /// Логика взаимодействия для AnnouncementPage.xaml
    /// </summary>
    public partial class AnnouncementPage : Page
    {
        public AnnouncementPage()
        {
            InitializeComponent();
            LoadData();
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
    }   
}