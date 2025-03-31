using System.Windows;
using System.Windows.Controls;
using demo_tusk.Connection;
using demo_tusk.Model;
using demo_tusk.Pages.ManagerPage.MainMenu;

namespace demo_tusk.Pages.ManagerPage.CreateClient;

public partial class CreateClientPage : Page
{
    public CreateClientPage()
    {
        InitializeComponent();
    }

    private void ButtonBackPage_OnClick(object sender, RoutedEventArgs e)
    {
        GlobalVariables.Frame.Navigate(new ManagerMainMenuPage());
    }


    private void ButtonCreateClient_OnClick(object sender, RoutedEventArgs e)
    {
        if (textBoxFirstName.Text == null)
        {
            MessageBox.Show(
                "Ошибка. Поле Имя клиента не может быть пустым"
            );
            return;
        }

        if (textBoxLastName.Text == null)
        {
            MessageBox.Show(
                "Ошибка. Поле Фамилия клиента не может быть пустым"
            );
            return;
        }

        if (textBoxPhoneNumber.Text == null)
        {
            MessageBox.Show(
                "Ошибка. Поле Номер телефона не может быть пустым"
            );
            return;
        }

        if (textBoxLogin.Text == null)
        {
            MessageBox.Show(
                "Ошибка. Поле Логин не может быть пустым"
            );
            return;
        }

        if (textBoxLogin.Text == null)
        {
            MessageBox.Show(
                "Ошибка. Поле Пароль не может быть пустым"
            );
            return;
        }

        Client client = new Client()
        {
            FirstName = textBoxFirstName.Text,
            LastName = textBoxLastName.Text,
            PhoneNumber = textBoxPhoneNumber.Text,
            Login = textBoxLogin.Text,
            Password = textBoxPassword.Text
        };

        try
        {
            DbConnector
                .conn
                .Clients
                .Add(client);

            DbConnector
                .conn
                .SaveChanges();
            
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhoneNumber.Clear();
            textBoxLogin.Clear();
            textBoxPassword.Clear();

            MessageBox.Show(
                "Успех. Клиент успешно добавлен"
            );
        }
        catch
        {
            MessageBox.Show(
                "Произошла ошибка при работе с БД"
            );
        }
    }
}