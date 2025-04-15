using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace StreetWatering
{
    public partial class MainWindow : Window
    {
        private List<(string Name, double Length, int Buildings, string Surface)> streets = new();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void AddStreet_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            if (!double.TryParse(LengthBox.Text, out double length) || length <= 0)
            {
                MessageBox.Show("Неправильна довжина!");
                return;
            }
            if (!int.TryParse(BuildingsBox.Text, out int buildings))
            {
                MessageBox.Show("Неправильна кількість будинків!");
                return;
            }
            string surface = SurfaceBox.Text;

            streets.Add((name, length, buildings, surface));

            ClearInputs();
            MessageBox.Show("Вулицю додано!");
        }

        private void ClearInputs()
        {
            NameBox.Text = "";
            LengthBox.Text = "";
            BuildingsBox.Text = "";
            SurfaceBox.Text = "";
        }
        
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            StreetList.Items.Clear();
            foreach (var s in streets)
            {
                StreetList.Items.Add($"{s.Name}, {s.Length} км, {s.Buildings} будинків, {s.Surface}");
            }
        }
        
        private void ShowDoubleWatering_Click(object sender, RoutedEventArgs e)
        {
            StreetList.Items.Clear();
            if (streets.Count == 0)
            {
                StreetList.Items.Add("Немає даних.");
                return;
            }

            double avg = streets.Average(s => s.Length);
            var filtered = streets.Where(s => s.Length > avg).ToList();

            StreetList.Items.Add($"Середня довжина: {avg:F2} км");
            StreetList.Items.Add("Вулиці з довжиною > середньої:");

            foreach (var s in filtered)
            {
                StreetList.Items.Add($"{s.Name} ({s.Length} км)");
            }
        }
        
        private void ShowElementByIndex_Click(object sender, RoutedEventArgs e)
        {
            StreetList.Items.Clear();

            if (streets.Count == 0)
            {
                StreetList.Items.Add("Немає записів.");
                return;
            }

            if (!int.TryParse(IndexBox.Text, out int index) || index < 0 || index > 3)
            {
                StreetList.Items.Add("Індекс має бути від 0 до 3.");
                return;
            }

            var s = streets[0];
            string result = index switch
            {
                0 => $"Назва: {s.Name}",
                1 => $"Довжина: {s.Length} км",
                2 => $"Будинки: {s.Buildings}",
                3 => $"Покриття: {s.Surface}",
                _ => "Індекс поза межами"
            };

            StreetList.Items.Add(result);
        }
    }
}
