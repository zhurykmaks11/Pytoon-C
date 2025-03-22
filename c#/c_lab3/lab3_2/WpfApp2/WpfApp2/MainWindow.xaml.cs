using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace TextInsertApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessText_Click(object sender, RoutedEventArgs e)
        {
            string firstText = firstTextBox.Text;
            string secondText = secondTextBox.Text;
            string word = wordTextBox.Text;

            if (string.IsNullOrWhiteSpace(firstText) || string.IsNullOrWhiteSpace(secondText) || string.IsNullOrWhiteSpace(word))
            {
                MessageBox.Show("Введіть всі дані!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
           
            string pattern = $@"\b{Regex.Escape(word)}\b";
            string result = Regex.Replace(firstText, pattern, match => match.Value + " " + secondText);

            resultTextBox.Text = result;
        }
        
    }
}