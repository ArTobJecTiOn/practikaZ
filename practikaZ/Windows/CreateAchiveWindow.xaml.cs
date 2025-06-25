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

namespace practikaZ.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateAchiveWindow.xaml
    /// </summary>
    public partial class CreateAchiveWindow : Window
    {
        public CreateAchiveWindow()
        {
            InitializeComponent();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(DescriptionBox.Text))
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var achievement = new Achievement
            {
                Name = NameBox.Text.Trim(),
                Description = DescriptionBox.Text.Trim()
            };

            AchivementService.AddAchievement(achievement);

            MessageBox.Show("Достижение создано!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
