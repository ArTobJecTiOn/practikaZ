using practikaZ.models;
using practikaZ.Service;
using practikaZ.Windows;
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
    /// Логика взаимодействия для AchievementPage.xaml
    /// </summary>
    public partial class AchievementPage : Page
    {
        public AchievementPage()
        {
            InitializeComponent();
            LoadData();

        }
        private void LoadData()
        {
            if (UserHelper.user != null)
            {
                int userId = UserHelper.user.Id;

                AchiList.ItemsSource = AchivementService.GetAchieves(userId);
            }

        }
        private void AchiList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AchiList.SelectedItem is Achievement selected)
            {
                var window = new ViewAchievementWindow(selected);
                window.ShowDialog();
            }

            AchiList.SelectedItem = null;
        }
    }
}
