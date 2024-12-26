using Alekseeva.Models;
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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Alekseeva
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            try
            {
                using (var context = new AlekseevaKaContext())
                {
                    var users = await context.User.ToListAsync();
                    UsersListBox.Items.Clear();
                    foreach (var user in users)
                    {
                        var userItem = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Margin = new Thickness(5)
                        };

                        var textBlock = new TextBlock
                        {
                            Text = $"{user.Lastname}, {user.Firstname} ({user.Username}) - {user.Email} — ",
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        var checkBox = new CheckBox
                        {
                            Content = "Заблокирован",
                            IsChecked = user.IsLocked,
                            Tag = user.Id,
                            VerticalAlignment = VerticalAlignment.Center
                        };
                        checkBox.Click += LockUserCheckbox_Click;

                        userItem.Children.Add(textBlock);
                        userItem.Children.Add(checkBox);
                        UsersListBox.Items.Add(userItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при загрузке пользователей: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenAddEmployeeWindow(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new AddUser();
            addEmployeeWindow.ShowDialog();
            LoadUsers();
        }

        private void OpenChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is StackPanel selectedItem)
            {
                var checkBox = selectedItem.Children.OfType<CheckBox>().FirstOrDefault();
                if (checkBox != null)
                {
                    var userId = (int)checkBox.Tag;
                    var changePasswordWindow = new ChangePasswordWindow(userId);
                    changePasswordWindow.ShowDialog();
                    LoadUsers();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для изменения пароля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is StackPanel selectedItem)
            {
                var checkBox = selectedItem.Children.OfType<CheckBox>().FirstOrDefault();
                if (checkBox != null)
                {
                    var userId = (int)checkBox.Tag;

                    var result = MessageBox.Show("Вы уверены, что хотите удалить этого пользователя?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            using (var context = new AlekseevaKaContext())
                            {
                                var user = await context.User.FirstOrDefaultAsync(u => u.Id == userId);
                                if (user != null)
                                {
                                    context.User.Remove(user);
                                    await context.SaveChangesAsync();
                                    MessageBox.Show("Пользователь успешно удален.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                                    LoadUsers();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Произошла ошибка при удалении пользователя: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LockUserCheckbox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                var userId = (int)checkBox.Tag;
                bool isLocked = checkBox.IsChecked ?? false;
                await UpdateUserLockStatus(userId, isLocked);
                LoadUsers();
            }
        }

        private async Task UpdateUserLockStatus(int userId, bool isLocked)
        {
            try
            {
                using (var context = new AlekseevaKaContext())
                {
                    var user = await context.User.FirstOrDefaultAsync(u => u.Id == userId);
                    if (user != null)
                    {
                        user.IsLocked = isLocked;
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при обновлении статуса блокировки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


