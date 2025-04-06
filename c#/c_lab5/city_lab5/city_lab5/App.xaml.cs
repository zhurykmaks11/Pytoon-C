using System;
using System.Windows;
using Microsoft.Win32;

namespace city_lab5
{
    public partial class MainWindow : Window
    {
        private City city = new City();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveCity(object sender, RoutedEventArgs e)
        {
            try
            {
                city.CityName = txtCityName.Text;
                city.Country = txtCountry.Text;
                city.CityPopulation = int.Parse(txtPopulation.Text);
                city.Area = double.Parse(txtArea.Text);
                city.Mayor = txtMayor.Text;
                city.FoundedYear = int.Parse(txtFoundedYear.Text);
                city.HasMetro = chkMetro.IsChecked == true;

                city.SaveToFile("city.txt");
                MessageBox.Show("Дані збережено у файл city.txt", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowCityInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(city.ShowInfo(), "Інформація про місто", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        
    }
}