using practikaZ.models;
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
    /// Логика взаимодействия для ViewAchievementWindow.xaml
    /// </summary>
    public partial class ViewAchievementWindow : Window
    {
        public ViewAchievementWindow(Achievement achievement)
        {
            InitializeComponent();

            TitleBlock.Text = achievement.Name;
            DescriptionBlock.Text = achievement.Description;
        }
    }
}