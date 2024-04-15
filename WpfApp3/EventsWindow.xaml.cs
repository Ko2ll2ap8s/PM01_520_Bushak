using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        private merEntities2 db = new merEntities2();

        public EventsWindow()
        {
            InitializeComponent();
            LoadData(); // Загрузка данных при инициализации окна
        }

        private void LoadData()
        {
            var realties = db.Activ.ToList();
            lvEvents.ItemsSource = realties;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            // Подгружаем данные фигурирующие в базе
            var filteredRealties = db.Activ
                .Where(r =>
                    r.ID.ToString().Contains(searchText) || r.NameActiv.ToLower().Contains(searchText) ||
                    r.Data.ToString().Contains(searchText) || r.Time.ToString().Contains(searchText) ||
                    r.Juri.ToString().Contains(searchText) || r.Win.ToLower().Contains(searchText)
                )
                .ToList();

            lvEvents.ItemsSource = filteredRealties;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e) => LoadData();
    }
}
