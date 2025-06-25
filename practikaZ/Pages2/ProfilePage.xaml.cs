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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadData();
        }

       

        private void UpdateProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            UserHelper.user.FirstName = NameBox.Text;
            UserHelper.user.LastName = SurnameBox.Text;
            UserHelper.user.Patronymic = PatronymicBox.Text;
            UserHelper.user.Login = LoginBox.Text;
            UserHelper.user.Password = PasswordUserBox.Text;
            UserService.UpdateUser(UserHelper.user);
            MessageBox.Show("Успешно!");
            LoadData();
        }

        private void LoadData()
        {
            bool canEdit = UserHelper.user.RoleId == 1;

            if (!canEdit)
            {
                NameBox.IsReadOnly = true;
                SurnameBox.IsReadOnly =true;
               PatronymicBox.IsReadOnly=true;
                LoginBox.IsReadOnly=true;
                PasswordUserBox.IsReadOnly=true;
                PhoneBox.IsReadOnly=false;
                JobPhoneBox.IsReadOnly= true;
                PostBox.IsReadOnly = true;
                SpecBox.IsReadOnly = true;


            }
            NameBox.Text = UserHelper.user.FirstName;
            SurnameBox.Text = UserHelper.user.LastName;
            PatronymicBox.Text = UserHelper.user.Patronymic;
            LoginBox.Text = UserHelper.user.Login;
            PasswordUserBox.Text = UserHelper.user.Password;
            PhoneBox.Text = UserHelper.user.PhoneNumber;
            JobPhoneBox.Text = UserHelper.user.JobPhoneNumber;
            PostBox.Text = UserHelper.user.Post.PostName;
            SpecBox.Text = UserHelper.user.Specialization.SpecializationName;


        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            QuitClick();
        }

        private void QuitClick()
        {
            UserHelper.user = null;
            NavigationService.GoBack();
            NavigationService.GoBack();
        }      

        private void CheckPassword_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordUserBox.Visibility == Visibility.Visible)
            {
                PasswordUserBox.Visibility = Visibility.Collapsed;
                VisiblePassword.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordUserBox.Visibility = Visibility.Visible;
                VisiblePassword.Visibility = Visibility.Collapsed;
            }
        }

        private void DeleteAcc_Click(object sender, RoutedEventArgs e)
        {

        }
        private void PasswordUserBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            VisiblePassword.Text = PasswordUserBox.Text;
        }

        private void VisiblePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordUserBox.Text = VisiblePassword.Text;
        }
        
       
    }
}
