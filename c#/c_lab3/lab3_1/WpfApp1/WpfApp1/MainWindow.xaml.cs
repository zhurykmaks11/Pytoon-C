using System;
using System.Windows;

namespace CharArrayApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputTextBox == null || resultTextBlock == null) return;

            string input = inputTextBox.Text.Trim(); // Видаляємо зайві пробіли
            if (string.IsNullOrEmpty(input))
            {
                resultTextBlock.Text = "Введіть рядок символів!";
                return;
            }

            char[] chars = input.Replace(" ", "").ToCharArray(); // Видаляємо пробіли та перетворюємо в масив
            int index = Array.IndexOf(chars, '#'); // Знаходимо позицію '#'

            if (index == -1)
            {
                resultTextBlock.Text = "Символ '#' не знайдено.";
            }
            else
            {
                int count = chars.Length - index - 1;
                resultTextBlock.Text = $"Символів після '#': {count}";
            }
        }
    }
}