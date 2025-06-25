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

namespace practikaZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (loginbox.Text == null || pwdbox.Text == null)
                {
                    MessageBox.Show("Некоторые поля пустые!");
                }
                else
                {
                    User? user = UserService.GetUser(loginbox.Text, pwdbox.Text.ToString());
                    if (user == null)
                    {
                        MessageBox.Show("Неправильный логин или пароль!");
                    }
                    else if (user.RoleId == 2)
                    {
                        NavigationService.Navigate(new StaffMainPage());
                        UserHelper.user = user;
                    }
                    else if (user.RoleId == 3)
                    {
                        {
                            NavigationService.Navigate(new UserMainPage());
                            UserHelper.user = user;
                        }
                    }
                    else if (user.RoleId == 1)
                    {
                        {
                            NavigationService.Navigate(new AdminsMainPage());
                            UserHelper.user = user;
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

