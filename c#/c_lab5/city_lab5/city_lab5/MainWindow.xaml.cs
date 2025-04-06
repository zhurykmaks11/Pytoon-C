using System;
using System.IO;

namespace city_lab5
{
    public class City
    {
        private bool hasMetro;
        private double area;
        private string cityName;
        private int cityPopulation;
        private string country;
        private string mayor;
        private int foundedYear;

        // Властивості (Get/Set)
        public bool HasMetro
        {
            get { return hasMetro; }
            set { hasMetro = value; }
        }

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        public int CityPopulation
        {
            get { return cityPopulation; }
            set { cityPopulation = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string Mayor
        {
            get { return mayor; }
            set { mayor = value; }
        }

        public int FoundedYear
        {
            get { return foundedYear; }
            set { foundedYear = value; }
        }

        // Конструктор без параметрів
        public City() { }

        // Метод виводу інформації
        public string ShowInfo()
        {
            return $"Назва міста: {cityName}, {country}\n" +
                   $"Населення: {cityPopulation}\n" +
                   $"Площа: {area} км²\n" +
                   $"Мер: {mayor}\n" +
                   $"Рік заснування: {foundedYear}\n" +
                   $"Метро: {(hasMetro ? "Є" : "Немає")}";
        }

        // Метод підрахунку густоти населення
        public double PopulationDensity()
        {
            return area > 0 ? cityPopulation / area : 0;
        }

        // Метод збереження в файл
        public void SaveToFile(string filePath)
        {
            string data = $"{cityName},{country},{mayor},{foundedYear},{hasMetro},{area},{cityPopulation}";
            File.WriteAllText(filePath, data);
        }
    }
}
