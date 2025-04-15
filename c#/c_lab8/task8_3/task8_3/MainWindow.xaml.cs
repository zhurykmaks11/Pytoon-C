using System;
using System.Collections.Generic;
using System.Windows;

namespace QuizApp
{
    public partial class MainWindow : Window
    {
        enum OS
        {
            Windows,
            Linux,
            macOS,
            Android,
            iOS
        }

        Dictionary<OS, string> osInfo = new Dictionary<OS, string>
        {
            { OS.Windows, "Microsoft (1985)" },
            { OS.Linux, "Linus Benedict Torvalds (1991)" },
            { OS.macOS, "Apple (1984)" },
            { OS.Android, "Open Handset Alliance & Google (2008)" },
            { OS.iOS, "Apple Inc. (2007)" }
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string input = InputBox.Text.Trim();
            bool repeat = true;

            while (repeat)
            {
                if (Enum.TryParse(input, true, out OS selectedOS))
                {
                    switch (selectedOS)
                    {
                        case OS.Windows:
                        case OS.Linux:
                        case OS.macOS:
                        case OS.Android:
                        case OS.iOS:
                            ResultText.Text = $"Розробник і рік: {osInfo[selectedOS]}";
                            break;
                        default:
                            ResultText.Text = "ОС не знайдено.";
                            break;
                    }
                }
                else
                {
                    ResultText.Text = "Невірне введення! Спробуйте ще раз.";
                }

                // Далі запитаємо користувача чи продовжити — в GUI це не while знову, а просто очікування дій
                repeat = false; // щоб вийти з циклу після 1 запуску через GUI
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "";
            ResultText.Text = "";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
