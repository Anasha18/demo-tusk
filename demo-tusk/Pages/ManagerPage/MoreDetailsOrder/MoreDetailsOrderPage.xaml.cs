using System.Windows;
using System.Windows.Controls;
using demo_tusk.Connection;
using demo_tusk.Model;
using demo_tusk.Pages.ManagerPage.MainMenu;

namespace demo_tusk.Pages.ManagerPage.MoreDetailsOrder;

public partial class MoreDetailsOrderPage : Page
{
    public MoreDetailsOrderPage()
    {
        InitializeComponent();

        try
        {
            DataGridMoreDetailsOrder
                    .ItemsSource =
                DbConnector
                    .conn
                    .Orders
                    .ToList();
        }
        catch (Exception e)
        {
            MessageBox.Show(
                "Произошла ошибка при работе с БД"
            );
        }
    }


    private void ButtonBackPage_OnClick(object sender, RoutedEventArgs e)
    {
        GlobalVariables.Frame.Navigate(new ManagerMainMenuPage());
    }
}