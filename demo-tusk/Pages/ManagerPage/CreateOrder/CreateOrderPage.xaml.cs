using System.Windows;
using System.Windows.Controls;
using demo_tusk.Connection;
using demo_tusk.Model;
using demo_tusk.Pages.ManagerPage.MainMenu;

namespace demo_tusk.Pages.ManagerPage.CreateOrder;

public partial class CreateOrderPage : Page
{
    public CreateOrderPage()
    {
        InitializeComponent();
        
        ComboBoxStatus.ItemsSource = DbConnector.conn.Statuses.ToList();
        ComboBoxStatus.DisplayMemberPath = "Name";

        ComboBoxUser.ItemsSource = DbConnector.conn.Users.ToList();
        ComboBoxUser.DisplayMemberPath = "LastName";

        ComboBoxClientFrom.ItemsSource = DbConnector.conn.Clients.ToList();
        ComboBoxClientFrom.DisplayMemberPath = "LastName";

        ComboBoxOnClient.ItemsSource = DbConnector.conn.Clients.ToList();
        ComboBoxOnClient.DisplayMemberPath = "LastName";

        ComboBoxTypeItemOrder.ItemsSource = DbConnector.conn.TypeOrders.ToList();
        ComboBoxTypeItemOrder.DisplayMemberPath = "Name";
    }

    private void buttonCreateOrderPage_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (ComboBoxStatus.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле статус не может быть пустым"
            );
            return;
        }

        if (ComboBoxUser.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле работник не может быть пустым"
            );
            return;
        }

        if (textBoxAddress.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле адрес не может быть пустым"
            );
            return;
        }

        if (ComboBoxClientFrom.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле кто отправляет не может быть пустым"
            );
            return;
        }

        if (ComboBoxOnClient.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле кто получает не может быть пустым"
            );
            return;
        }

        if (textBoxFinishDateOrder.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле дата доставки не может быть пустым"
            );
            return;
        }

        if (textBoxLengthItem.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле длина товара не может быть пустым"
            );
            return;
        }

        if (textBoxWidthItem.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле ширина товара не может быть пустым"
            );
            return;
        }

        if (textBoxWeightItem.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле вес товара не может быть пустым"
            );
            return;
        }

        if (textBoxCostOrder.Text == null)
        {
            MessageBox.Show(
                "Ошибка, стоимость доставки не может быть пустым"
            );
            return;
        }

        if (ComboBoxTypeItemOrder.Text == null)
        {
            MessageBox.Show(
                "Ошибка, поле тип товара не может быть пустым"
            );
            return;
        }

        Order newOrder = new Order()
        {
            Status = (Status)ComboBoxStatus.SelectedItem,
            User = (User)ComboBoxUser.SelectedItem,
            Address = textBoxAddress.Text,
            ClientFrom = (Client)ComboBoxClientFrom.SelectedItem,
            ClientTo = (Client)ComboBoxOnClient.SelectedItem,
            FinishOrder = DateTime.Parse(textBoxFinishDateOrder.Text),
            Length = decimal.Parse(textBoxLengthItem.Text),
            Width = Decimal.Parse(textBoxWidthItem.Text),
            Weight = decimal.Parse(textBoxWeightItem.Text),
            Cost = decimal.Parse(textBoxCostOrder.Text),
            Type = (TypeOrder)ComboBoxTypeItemOrder.SelectedItem
        };

        try
        {
            DbConnector
                .conn
                .Orders
                .Add(newOrder);

            DbConnector
                .conn
                .SaveChanges();

            MessageBox.Show(
                "Заказ успешно создан"
            );
        }
        catch
        {
            MessageBox.Show(
                "Произошла ошибка при работе с БД"
            );
            
        }
    }

    private void buttonBackPage_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        GlobalVariables.Frame.Navigate(new ManagerMainMenuPage());
    }
}