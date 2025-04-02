using demo_tusk.Connection;
using demo_tusk.Model;
using Microsoft.EntityFrameworkCore;
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
using demo_tusk.Pages.ManagerPage.CreateClient;
using demo_tusk.Pages.ManagerPage.CreateOrder;
using demo_tusk.Pages.ManagerPage.MoreDetailsOrder;

namespace demo_tusk.Pages.ManagerPage.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для ManagerMainMenuPage.xaml
    /// </summary>
    public partial class ManagerMainMenuPage : Page
    {
        public ManagerMainMenuPage()
        {
            InitializeComponent();

            dataGridManager.ItemsSource = DbConnector
                .conn
                .Orders
                .Include(s => s.Status)
                .Include(cl => cl.ClientFrom)
                .ToList();
        }


        private void ButtonMoreDetailsOrder_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Frame.Navigate(new MoreDetailsOrderPage());
        }

        private void ButtonChangeOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxId.Text))
            {
                MessageBox.Show(
                    "Ошибка. Для изменения данных заказа поле не должно быть пустым, введите id"
                );
                return;
            }

            if (!int.TryParse(textBoxId.Text, out int id))
            {
                MessageBox.Show(
                    "Ошибка. ID заказа должен быть числом"
                );
                return;
            }

            Order? selectedOrder = null;
            try
            {
                selectedOrder =
                    DbConnector
                        .conn
                        .Orders
                        .FirstOrDefault(o => o.Id == id);
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка при работе с БД"
                );
                return;
            }

            if (selectedOrder == null)
            {
                MessageBox.Show(
                    "Такого заказа нет"
                );
                return;
            }

            GlobalVariables.Frame.Navigate(new ChangeOrderManagerPage(selectedOrder));
        }

        private void buttonCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Frame.Navigate(new CreateOrderPage());
        }

        private void buttonCreateClient_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Frame.Navigate(new CreateClientPage());
        }

        private void buttonSelectOrderOnPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridManager.ItemsSource =
                    DbConnector
                        .conn
                        .Orders
                        .Where(order => order.ClientFrom.PhoneNumber == textBoxInputPhoneNumber.Text)
                        .ToList();

                textBoxInputPhoneNumber.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при работе с БД "
                    + ex.Message);
            }
        }

        private void buttonBackToMenu_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            GlobalVariables.Frame.Navigate(new AutentificationPage());
        }
    }
}