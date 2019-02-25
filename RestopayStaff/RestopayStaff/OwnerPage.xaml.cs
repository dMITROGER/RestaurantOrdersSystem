using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RestopayStaff
{
    public partial class OwnerPage : Page
    {
        
        ProductsDatabaseEntities _db = new ProductsDatabaseEntities();
        private static ObservableCollection<OrdersInProgress> oipItems;
        public OwnerPage()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            _db.SaveChanges();
            
            var query = from o in _db.OrdersInProgresses select o;
            oipItems = new ObservableCollection<OrdersInProgress>();
            foreach (var item in query)
            {
               
                    string statusC;
                    string statusB;
                if (item.Category != "Bar")
                {
                    statusC = item.CookStatus_;
                    statusB = "";
                }
                else
                {
                    statusC = "";
                    statusB = item.BartenderStatus_;
                }


                    oipItems.Add(new OrdersInProgress
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Quantity = item.Quantity,
                        OrderNumber = item.OrderNumber,
                        DateTime = item.DateTime,
                        TableNumber = item.TableNumber,
                        CookStatus_ = statusC,
                        BartenderStatus_ = statusB,

                    });
                

            }
            grid.ItemsSource = oipItems;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            oipItems.Clear();
            Load();
            grid.Items.Refresh();

        }

        private void RemoveRaw(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = (grid.SelectedItem as OrdersInProgress).Id;
                var query = from o in _db.OrdersInProgresses where o.Id == id select o;
                foreach (var item in query)
                {
                    item.WaiterStatus_ = "Completed";
                    item.CookStatus_ = "Completed";
                    item.BartenderStatus_ = "Completed";
                    ArchivedOrder archOrder = new ArchivedOrder();
                    archOrder.OrderNumber = item.OrderNumber;
                    archOrder.DateTime = item.DateTime;
                    archOrder.Name = item.Name;
                    archOrder.Price = item.Price;
                    archOrder.Quantity = item.Quantity;
                    archOrder.Amount = item.Amount;
                    archOrder.Category = item.Category;
                    archOrder.TableNumber = item.TableNumber;

                    _db.ArchivedOrders.Add(archOrder);
                    _db.OrdersInProgresses.Remove(item);
                }
                _db.SaveChanges();
                oipItems.Remove(grid.SelectedItem as OrdersInProgress);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }
        
        private void ButtonMenuClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }

        private void ButtonExitClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StaffPage());
        }

        private void ArchidedOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrdersArchivePage());
        }
    }
}
