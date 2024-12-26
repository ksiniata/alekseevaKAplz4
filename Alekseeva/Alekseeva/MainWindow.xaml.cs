using System.Security.Claims;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System;
using System.Linq;
using Alekseeva.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.RightsManagement;

namespace Alekseeva
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using (var context = new AlekseevaKaContext())
                {
                    var user = await context.User
                    .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

                    if (user != null)
                    {
                        if (user.IsLocked == true)
                        {
                            MessageBox.Show("Ваш аккаунт заблокирован. Пожалуйста, обратитесь к администратору.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                            if (user.IsFirstLogin == true)
                            {
                                user.IsFirstLogin = false;
                                var changePasswordWindow = new ChangePasswordWindow(user.Id);
                                changePasswordWindow.Show();
                            }
                            else
                            {
                                if (user.Role == "admin")
                                {
                                    var adminPanelWindow = new Admin();
                                    adminPanelWindow.Show();
                                }
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверные логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при подключении к базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}