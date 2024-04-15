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

namespace WpfApp3
{
    public partial class LoginWindow : Window
    {
        private merEntities2 db = new merEntities2(); 

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Password;

            var user = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            // Провека по роли, используется идентификатор
            if (user != null)
            {
                switch (user.Role)
                {
                    case 1:
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                        break;
                    case 2:
                        ClientWindow clientWindow = new ClientWindow();
                        clientWindow.Show();
                        this.Close();
                        break;
                    case 3:
                        OrgWindow orgWindow = new OrgWindow();
                        orgWindow.Show();
                        this.Close();
                        break;
                    case 4:
                        UserWindow userWindow = new UserWindow();
                        userWindow.Show();
                        this.Close();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Проверки
        private void TxtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLogin.Text == "Логин")
            {
                txtLogin.Text = "";
                txtLogin.Foreground = Brushes.Black;
            }
        }

        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "Логин")
            {
                txtLogin.Text = "";
                txtLogin.Foreground = Brushes.Black;
            }
        }

        private void AddPlaceholder(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                txtLogin.Text = "Логин";
                txtLogin.Foreground = Brushes.Gray;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
