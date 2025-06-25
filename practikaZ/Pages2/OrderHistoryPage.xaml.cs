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
    /// Логика взаимодействия для OrderHistoryPage.xaml
    /// </summary>
    public partial class OrderHistoryPage : Page
    {
        public OrderHistoryPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            if (UserHelper.user != null)
            {
                var orders = OrderService.GetOrders(UserHelper.user.Id);
                OrdersList.ItemsSource = orders;
            }
        }
    }
}
