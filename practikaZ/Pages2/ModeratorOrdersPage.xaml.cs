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
    /// Логика взаимодействия для ModeratorOrdersPage.xaml
    /// </summary>
    public partial class ModeratorOrdersPage : Page
    {
        public ModeratorOrdersPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var orders = OrderService.GetAllOrders();
            OrdersGrid.ItemsSource = orders;
        }


        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedOrderStatus("Принят");
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectedOrderStatus("Отклонён");
        }

        private void UpdateSelectedOrderStatus(string status)
        {
            if (OrdersGrid.SelectedItem is Order selected)
            {
                OrderService.UpdateOrderStatus(selected.Id, status);
                MessageBox.Show($"Статус обновлён на: {status}", "Завершен", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
        }
    }
}