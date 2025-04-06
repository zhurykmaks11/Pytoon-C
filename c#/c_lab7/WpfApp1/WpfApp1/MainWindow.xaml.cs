using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private List<Train> ROZKLAD = new List<Train>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddTrain_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nazv = NazvBox.Text;
                int numr = int.Parse(NumrBox.Text);
                DateTime date = DatePicker.SelectedDate ?? DateTime.Now;
                TimeSpan time = TimeSpan.Parse(TimeBox.Text);

                ROZKLAD.Add(new Train { NAZV = nazv, NUMR = numr, DATE = date, TIME = time });
                DisplayTrains(ROZKLAD);
            }
            catch
            {
                MessageBox.Show("Невірні вхідні дані. Перевірте формат.");
            }
        }

        private void SortTrains_Click(object sender, RoutedEventArgs e)
        {
            var sorted = ROZKLAD.OrderBy(t => t.NAZV).ToList();
            DisplayTrains(sorted);
        }

        private void FilterTrains_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime filterDate = FilterDate.SelectedDate ?? DateTime.Now;
                TimeSpan filterTime = TimeSpan.Parse(FilterTimeBox.Text);

                var filtered = ROZKLAD.Where(t =>
                    t.DATE > filterDate || (t.DATE == filterDate && t.TIME > filterTime)).ToList();

                if (filtered.Any())
                    DisplayTrains(filtered);
                else
                    MessageBox.Show("Немає потягів після заданого часу.");
            }
            catch
            {
                MessageBox.Show("Невірний формат дати або часу.");
            }
        }

        private void DisplayTrains(List<Train> trains)
        {
            TrainList.Items.Clear();
            foreach (var train in trains)
            {
                TrainList.Items.Add(train.ToString());
            }
        }
    }
}
