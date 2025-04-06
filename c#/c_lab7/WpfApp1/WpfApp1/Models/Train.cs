using System;

namespace WpfApp1.Models
{
    public struct Train
    {
        public string NAZV { get; set; }   
        public int NUMR { get; set; }       
        public DateTime DATE { get; set; }  
        public TimeSpan TIME { get; set; }  

        public override string ToString()
        {
            return $"{NAZV} | Потяг №{NUMR} | Дата: {DATE.ToShortDateString()} | Час: {TIME}";
        }
    }
}