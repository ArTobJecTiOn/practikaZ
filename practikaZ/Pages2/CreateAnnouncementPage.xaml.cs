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
    /// Логика взаимодействия для CreateAnnouncementPage.xaml
    /// </summary>
    public partial class CreateAnnouncementPage : Page
    {
        public CreateAnnouncementPage()
        {
            InitializeComponent();
            LoadTargetSelectors();
        }

        private void LoadTargetSelectors()
        {
            TargetRoleBox.ItemsSource = RoleService.GetRoles();
            TargetPostBox.ItemsSource = PostService.GetPosts();
            TargetSpecBox.ItemsSource = SpecializationService.GetSpecializations();
            TargetUserBox.ItemsSource = UserService.GetUsers();

            TargetRoleBox.SelectedIndex = -1;
            TargetPostBox.SelectedIndex = -1;
            TargetSpecBox.SelectedIndex = -1;
            TargetUserBox.SelectedIndex = -1;
        }

        private void PublishButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(ContentBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните и заголовок, и текст объявления.",
                                "Недостаточно данных",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            var announcement = new Announcement
            {
                Title = TitleBox.Text.Trim(),
                Message = ContentBox.Text.Trim(),               
                AuthorId = UserHelper.user.Id,
                TargetRoleId = TargetRoleBox.SelectedValue as int?,
                TargetPostId = TargetPostBox.SelectedValue as int?,
                TargetSpecializationId = TargetSpecBox.SelectedValue as int?,
                TargetUserId = TargetUserBox.SelectedValue as int?
            };

            AnnouncementService.AddAnnouncement(announcement);

            MessageBox.Show("Оповещение успешно опубликовано!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);

            TitleBox.Clear();
            ContentBox.Clear();
            TargetRoleBox.SelectedIndex = -1;
            TargetPostBox.SelectedIndex = -1;
            TargetSpecBox.SelectedIndex = -1;
            TargetUserBox.SelectedIndex = -1;
        }
    }
}