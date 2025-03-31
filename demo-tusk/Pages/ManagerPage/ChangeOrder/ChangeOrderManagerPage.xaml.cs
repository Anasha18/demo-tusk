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
using demo_tusk.Connection;
using demo_tusk.Model;
using demo_tusk.Pages.ManagerPage.MainMenu;

namespace demo_tusk.Pages.ManagerPage
{
    /// <summary>
    /// Логика взаимодействия для ChangeOrderManagerPage.xaml
    /// </summary>
    public partial class ChangeOrderManagerPage : Page
    {
        private Order _currentOrder;

        public ChangeOrderManagerPage(Order order)
        {
            InitializeComponent();
            _currentOrder = order;

            ComboBoxStatus.ItemsSource = DbConnector.conn.Statuses.ToList();
            ComboBoxStatus.DisplayMemberPath = "Name";

            LoadOrder();
        }

        private void LoadOrder()
        {
            textBoxId.Text = _currentOrder.Id.ToString();
            ComboBoxStatus.Text = _currentOrder.Status.Name;
            textBoxDateTime.Text = _currentOrder.FinishOrder.ToString("yyyy-MM-dd");
            textBoxCost.Text = _currentOrder.Cost.ToString();
        }


        private void buttonBackPage_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Frame.Navigate(new ManagerMainMenuPage());
        }

        private void buttonChangeOrderClick_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxCost.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. Цена доставки заказа не может быть пустой"
                );
                return;
            }

            if (textBoxDateTime.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. Дата доставки заказа не может быть пустой"
                );
                return;
            }

            if (ComboBoxStatus.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. Статус заказа не может быть пустым"
                );
                return;
            }

            try
            {
                _currentOrder.Status = (Status)ComboBoxStatus.SelectedItem;
                _currentOrder.FinishOrder = DateTime.Parse(textBoxDateTime.Text);
                _currentOrder.Cost = decimal.Parse(textBoxCost.Text);

                DbConnector
                    .conn
                    .SaveChanges();

                MessageBox.Show(
                    "Обновление данных успешно произошло!"
                );
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Ошибка при работе с БД " + exception.Message
                );
            }
        }
    }
}