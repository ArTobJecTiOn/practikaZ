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
using System.Windows.Shapes;

namespace practikaZ.Pages2
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private User current;

        public ProfileWindow()
        {
            InitializeComponent();
            this.Loaded += ProfileWindow_Loaded;
        }

        private void ProfileWindow_Loaded(object sender, RoutedEventArgs e)
        {
            current = DataContext as User;
            if (current != null)
                LoadRoles();
                LoadData();
            Rolebox.SelectedValue = current.RoleId;
                
        }

        private void LoadData()
        {
            NameBox.Text = current.FirstName;
            SurnameBox.Text = current.LastName;
            PatronymicBox.Text = current.Patronymic;
            LoginBox.Text = current.Login;
            PasswordUserBox.Text = current.Password;
            PhoneBox.Text = current.PhoneNumber;
            JobPhoneBox.Text = current.JobPhoneNumber;
            PostBox.Text = UserHelper.user.Post.PostName;
            SpecBox.Text = UserHelper.user.Specialization.SpecializationName;
        }

        private void UpdateProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            
                if (current == null) return;

                current.FirstName = NameBox.Text;
                current.LastName = SurnameBox.Text;
                current.Patronymic = PatronymicBox.Text;
                current.Login = LoginBox.Text;
                current.Password = PasswordUserBox.Text;
                current.PhoneNumber = PhoneBox.Text;
                current.JobPhoneNumber = JobPhoneBox.Text;

                if (Rolebox.SelectedValue is int selectedRoleId)
                {
                    current.RoleId = selectedRoleId;
                }

                UserService.UpdateUser(current);

                MessageBox.Show("Изменения сохранены!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();           
        }

        private void DeleteAcc_Click(object sender, RoutedEventArgs e)
        {
            if (current == null) return;

            var result = MessageBox.Show(
                $"Вы действительно хотите удалить пользователя «{current.LastName} {current.FirstName}»?", "Подтверждение удаления", 
                MessageBoxButton.YesNo, MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                UserService.DeleteUser(current.Id);
                MessageBox.Show("Пользователь удалён.", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                Close(); 
            }
        }
        private void LoadRoles()
        {
            var isModerator = UserHelper.user.RoleId == 2;
            var roles = RoleService.GetRoles(excludeAdmin: isModerator);

            Rolebox.ItemsSource = roles;
        }
    }
}