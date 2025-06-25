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
    /// Логика взаимодействия для RegisterUserPage.xaml
    /// </summary>
    public partial class RegisterUserPage : Page
    {
        public RegisterUserPage()
        {
            InitializeComponent();

            RoleBox.ItemsSource = RoleService.GetRoles();
            PostBox.ItemsSource = PostService.GetPosts();
            SpecBox.ItemsSource = SpecializationService.GetSpecializations();
            GenderBox.ItemsSource = GenderService.GetGender();

            RoleBox.SelectedIndex = -1;
            PostBox.SelectedIndex = -1;
            SpecBox.SelectedIndex = -1;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
            string.IsNullOrWhiteSpace(LastNameBox.Text) ||
            string.IsNullOrWhiteSpace(LoginBox.Text) ||
            string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newUser = new User
            {
                FirstName = FirstNameBox.Text.Trim(),
                LastName = LastNameBox.Text.Trim(),
                Patronymic = PatronymicBox.Text.Trim(),
                Login = LoginBox.Text.Trim(),
                Password = PasswordBox.Password,
                PhoneNumber = PhoneBox.Text.Trim(),
                RoleId = (int)RoleBox.SelectedValue,
                PostId = (int)PostBox.SelectedValue,
                SpecializationId = (int)SpecBox.SelectedValue,
                GenderId = (int)GenderBox.SelectedValue,
            };

            UserService.RegUser(newUser);
            MessageBox.Show("Пользователь зарегистрирован!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);           
        }
    }
}
    
