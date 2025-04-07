using System;

namespace WpfApp2.Models
{
    public struct Visit
    {
        public string Page { get; set; }
        public string IP { get; set; }
        public string Browser { get; set; }
        public DateTime Date { get; set; }  

        public string GetDayOfWeek()
        {
            return ((int)Date.DayOfWeek == 0 ? 7 : (int)Date.DayOfWeek).ToString();
        }

        public override string ToString()
        {
            return $"Сторінка: {Page} | IP: {IP} | Браузер: {Browser} | {Date:ddMMyyyy} " +
                   $"{Date:HH:mm:ss} | День: {GetDayOfWeek()}";
        }
    }
}