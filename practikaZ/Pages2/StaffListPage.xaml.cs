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
    /// Логика взаимодействия для StaffListPage.xaml
    /// </summary>
    public partial class StaffListPage : Page
    {
        public StaffListPage()
        {
            InitializeComponent();
            RolesColumn.ItemsSource = RoleService.GetRoles();
            LoadData();
            
        }
        private void UsersGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UsersGrid.SelectedItem is User selectedUser)
            {
                var fullUser = UserService.GetUserById(selectedUser.Id); 

                var profileWindow = new ProfileWindow();
                profileWindow.DataContext = fullUser;
                profileWindow.ShowDialog();
            }
        }
        private void LoadData()
        {
            UsersGrid.ItemsSource = UserService.GetAccessibleUsers(UserHelper.user.RoleId);
        }
    }
}

