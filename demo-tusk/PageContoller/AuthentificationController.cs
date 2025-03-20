using demo_tusk.Connection;
using demo_tusk.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace demo_tusk.PageContoller
{
    internal class AuthentificationController
    {
        public User FindUserByPhonePassword(string login, string password)
        {
            User? user = null;

            if (login == null || password == null)
            {
                MessageBox.Show(
                    "Ошибка! Введеные данные не могут быть пустыми!"
                    );
            }

            try
            {
                user = DbConnector
                    .conn
                    .Users
                    .Include(role => role.Role)
                    .FirstOrDefault(data => data.Login == login && data.Password == password);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Ошибка соединения с БД" + e.Message
                    );
            }

            if (user == null)
            {
                MessageBox.Show(
                    "Пользователь не найден"
                    );
            }

            return user;
        }

    }
}
