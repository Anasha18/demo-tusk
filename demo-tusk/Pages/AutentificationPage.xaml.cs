using demo_tusk.Connection;
using demo_tusk.Model;
using demo_tusk.PageContoller;
using demo_tusk.Pages.AdminPage;
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

namespace demo_tusk.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutentificationPage.xaml
    /// </summary>
    public partial class AutentificationPage : Page
    {

        private AuthentificationController _authentificationController;

        private string _login;
        private string _password;

        public AutentificationPage()
        {
            InitializeComponent();

            _authentificationController = new AuthentificationController();

        }

        private void BtnAutentification_Click(object sender, RoutedEventArgs e)
        {
            _login = TxbLogin.Text;
            _password = PsbPass.Password;

            User user = _authentificationController.FindUserByPhonePassword(_login, _password);

            if (user != null)
            {
                switch (user.Role.Name)
                {
                    case "Admin":
                        {

                            GlobalVariables.Frame.Navigate(new AdminMainPage());

                            break;
                        }
                    case "Manager":
                        {
                            //GlobalVariables.Frame.Navigate(new ManagerPage);

                            break;
                        }
                    default:
                        { break; }
                }
            }
            else
            {
                MessageBox.Show(
                    "Некорректоно веденные данные. Повторите попытку"
                    );
            }
        }
    }
}
