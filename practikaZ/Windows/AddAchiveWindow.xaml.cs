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
    /// Логика взаимодействия для AddAchiveWindow.xaml
    /// </summary>
    public partial class AddAchiveWindow : Window
    {
        public AddAchiveWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            UserBox.ItemsSource = UserService.GetUsers(); // если есть GetAccessibleUsers, можно использовать его
            AchievementBox.ItemsSource = AchivementService.GetAllAchievements();

            UserBox.SelectedIndex = -1;
            AchievementBox.SelectedIndex = -1;
        }
        
        private void Assign_Click(object sender, RoutedEventArgs e)
        {
            if (UserBox.SelectedValue is int userId && AchievementBox.SelectedValue is int achId)
            {
                AchivementService.AssignAchievement(userId, achId);
                MessageBox.Show("Достижение назначено!");
                Close();
            }
        }
    }
}
