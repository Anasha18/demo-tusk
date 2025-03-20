using demo_tusk.Connection;
using demo_tusk.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace demo_tusk.Pages.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();

            try
            {
                dataGridAdmin.ItemsSource = DbConnector.conn.Users.ToList();

                comboBoxRole.ItemsSource = DbConnector.conn.Roles.ToList();
                comboBoxRole.DisplayMemberPath = "Name";
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка! При получении данных с БД"
                    );
            }
        }

        private void dataGridAdmin_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            User selectedUser = (User)dataGridAdmin.SelectedItem;

            if (selectedUser != null)
            {
                textBoxId.Text = selectedUser.Id.ToString();
                textBoxFirstName.Text = selectedUser.FirstName;
                textBoxLastName.Text = selectedUser.LastName;
                textBoxPhoneNumber.Text = selectedUser.PhoneNumber;
                textBoxTaxNumber.Text = selectedUser.TaxNumber;
                textBoxLogin.Text = selectedUser.Login;
                textBoxPassword.Text = selectedUser.Password;
                comboBoxRole.Text = selectedUser.Role?.Name;
            }

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxId.Clear();
            textBoxFirstName.Clear(); ;
            textBoxLastName.Clear(); ;
            textBoxPhoneNumber.Clear(); ;
            textBoxLogin.Clear();
            textBoxPassword.Clear();
            comboBoxRole.SelectedIndex = -1;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxFirstName.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. Имя менеджера не может быть пустым"
                    );
                return;
            }

            if (textBoxLastName.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. Фамилия менеджера не может быть пустым"
                    );
                return;
            }

            if (textBoxPhoneNumber.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. номер телефона менеджера не может быть пустым"
                    );
                return;
            }

            if (textBoxTaxNumber.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. инн менеджера не может быть пустым"
                    );
                return;
            }

            if (textBoxLogin.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. логин менеджера не может быть пустым"
                    );
                return;
            }

            if (textBoxPassword.Text.Length == 0)
            {
                MessageBox.Show(
                    "Ошибка. пароль менеджера не может быть пустым"
                    );
                return;
            }

            User newUser = new User()
            {
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                TaxNumber = textBoxTaxNumber.Text,
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                Role = (Role)comboBoxRole.SelectedItem,
            };

            try
            {
                DbConnector.conn.Users.Add(newUser);

                DbConnector.conn.SaveChanges();

                textBoxId.Clear();
                textBoxFirstName.Clear(); ;
                textBoxLastName.Clear(); ;
                textBoxPhoneNumber.Clear(); ;
                textBoxTaxNumber.Clear();
                textBoxLogin.Clear();
                textBoxPassword.Clear();
                comboBoxRole.SelectedIndex = -1;

                dataGridAdmin.ItemsSource = null;
                dataGridAdmin.ItemsSource = DbConnector.conn.Users.ToList();

                comboBoxRole.SelectedIndex = -1;
                comboBoxRole.ItemsSource = DbConnector.conn.Roles.ToList();
                comboBoxRole.DisplayMemberPath = "Name";

                MessageBox.Show(
              "Успех. Менеджер добавлен"
              );
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка. Не удалось добавить менеджера в БД"
                    );
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            int updatedInt = int.Parse(textBoxId.Text);

            try
            {
                var selectedUser = DbConnector
                    .conn
                    .Users
                    .FirstOrDefault(data => data.Id == updatedInt);

                if (selectedUser != null)
                {
                    selectedUser.FirstName = textBoxFirstName.Text;
                    selectedUser.LastName = textBoxLastName.Text;
                    selectedUser.PhoneNumber = textBoxPhoneNumber.Text;
                    selectedUser.TaxNumber = textBoxTaxNumber.Text;
                    selectedUser.Login = textBoxLogin.Text;
                    selectedUser.Password = textBoxPassword.Text;
                    selectedUser.Role = (Role)comboBoxRole.SelectedItem;

                    DbConnector.conn.SaveChanges();

                    textBoxId.Clear();
                    textBoxFirstName.Clear(); ;
                    textBoxLastName.Clear(); ;
                    textBoxPhoneNumber.Clear(); 
                    textBoxTaxNumber.Clear();
                    textBoxLogin.Clear();
                    textBoxPassword.Clear();
                    comboBoxRole.SelectedIndex = -1;

                    dataGridAdmin.ItemsSource = null;
                    dataGridAdmin.ItemsSource = DbConnector.conn.Users.ToList();

                    comboBoxRole.ItemsSource = DbConnector.conn.Roles.ToList();
                    comboBoxRole.DisplayMemberPath = "Name";
                }
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка. Не получилось обновить данные работника"
                    );
            }

        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Frame.Navigate(new AutentificationPage());
        }
    }
}
