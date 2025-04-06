using System.Windows;

public interface IBuilding
{
    string Address { get; set; }
    void ShowInfo();
}

public interface IOwner
{
    string OwnerName { get; set; }
    void DisplayOwner();
}

public class Apartment : IBuilding, IOwner
{
    public string Address { get; set; }
    public string OwnerName { get; set; }
    public int Rooms { get; set; }

    public void ShowInfo()
    {
        MessageBox.Show($"Квартира знаходиться за адресою {Address}, має {Rooms} кімнат.");
    }

    public void DisplayOwner()
    {
        MessageBox.Show($"Власник квартири: {OwnerName}");
    }
}

public class Warehouse : IBuilding, IOwner
{
    public string Address { get; set; }
    public string OwnerName { get; set; }
    public int Capacity { get; set; }

    public void ShowInfo()
    {
        MessageBox.Show($"Склад знаходиться за адресою {Address}, місткість: {Capacity} м³.");
    }

    public void DisplayOwner()
    {
        MessageBox.Show($"Власник складу: {OwnerName}");
    }
}
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowApartment(object sender, RoutedEventArgs e)
        {
            Apartment apartment = new Apartment { Address = "вул. Шевченка, 10", OwnerName = "Іван Петренко", Rooms = 3 };
            apartment.ShowInfo();
            apartment.DisplayOwner();
        }

        private void ShowWarehouse(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse { Address = "просп. Незалежності, 25", OwnerName = "ТОВ Логістика", Capacity = 500 };
            warehouse.ShowInfo();
            warehouse.DisplayOwner();
        }
    }
}