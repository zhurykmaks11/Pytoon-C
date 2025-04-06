using System;
using System.Windows;

namespace ComputerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShowInfo_Click(object sender, RoutedEventArgs e)
        {
            double cpu = double.Parse(txtCPU.Text);
            int cores = int.Parse(txtCores.Text);
            int ram = int.Parse(txtRAM.Text);
            int hdd = int.Parse(txtHDD.Text);
            int battery = int.Parse(txtBattery.Text);
            double weight = double.Parse(txtWeight.Text);

            Computer computer = new Computer(cpu, cores, ram, hdd);

            txtOutput.Text = computer.Show() ;
        }
    }
    public class Computer
    {
        protected double CPU;
        protected int Cores, RAM, HDD;

        public Computer(double cpu, int cores, int ram, int hdd)
        {
            CPU = cpu;
            Cores = cores;
            RAM = ram;
            HDD = hdd;
        }

        public virtual double Cost() => (CPU * Cores) / 100 + (RAM / 80) + (HDD / 20);
        public virtual bool Suitability() => CPU >= 2000 && Cores >= 2 && RAM >= 2048 && HDD >= 320;

        public virtual string Show() => $"Комп'ютер: {CPU} МГц, {Cores} ядер, {RAM} МБ, {HDD} ГБ, Вартість: {Cost()}$, Придатність: {Suitability()}";
    }

    
    
}