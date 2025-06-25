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
    /// Логика взаимодействия для CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        public CreateOrderPage()
        {
            InitializeComponent();
        }

        private void SubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            if (UserHelper.user == null)
            {
                MessageBox.Show("Вы не авторизованы.");
                return;
            }

            if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Укажите корректное количество.");
                return;
            }
            try
            {
                OrderService.CreateOrder(UserHelper.user.Id, quantity, DescriptionBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

           

            MessageBox.Show("Заказ успешно отправлен!", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);

            DescriptionBox.Clear();
            QuantityBox.Clear();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderHistoryPage());
        }
    }
}
